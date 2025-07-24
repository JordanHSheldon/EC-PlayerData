namespace EsportsProfileWebApi.Web.Repository;

using Dapper;
using Orchestrators.Models.User;
using Microsoft.Extensions.Configuration;
using System.Data;
using EsportsProfileWebApi.Web.Orchestrators;
using Microsoft.Data.SqlClient;

public class UserRepository(IConfiguration configuration) : IUserRepository
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")
                                                ?? throw new NotImplementedException();

    public async Task<int> RegisterUser(UserRegisterRequestModel request)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new();
        parameters.Add("@username", request.Username, DbType.String);
        parameters.Add("@password", Helpers.PasswordHashing.HashPassword(request.Password), DbType.String);
        parameters.Add("@email", request.Email, DbType.String);
        parameters.Add("@UserId", direction: ParameterDirection.Output, dbType: DbType.Int32);
        
        await connection.ExecuteAsync("dbo.register_user", parameters, commandType: CommandType.StoredProcedure);

        int userId = parameters.Get<int>("@UserId");

        await connection.CloseAsync();

        return userId;
    }

    public async Task<int> LoginUser(UserLoginRequestModel request)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new ();
        parameters.Add("@password", Helpers.PasswordHashing.HashPassword(request.Password), DbType.String);
        parameters.Add("@email", request.Email, DbType.String);
        parameters.Add("@UserId", direction: ParameterDirection.Output, dbType: DbType.Int32);

        await connection.ExecuteAsync("dbo.login_user", parameters, commandType: CommandType.StoredProcedure);

        int userId = parameters.Get<int>("@UserId");

        await connection.CloseAsync();  

        return userId;
    }   

    public async Task<int> DiscordLogin(DiscordUserData discordUserData)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new ();
        parameters.Add("@email", discordUserData.email, DbType.String);
        parameters.Add("@username", discordUserData.username, DbType.String);
        parameters.Add("@discord_id", discordUserData.id, DbType.String);

        var userId = await connection.QueryFirstOrDefaultAsync<int>("discord_login_user", parameters, commandType: CommandType.StoredProcedure);
        
        await connection.CloseAsync();  

        return userId;
    }
}