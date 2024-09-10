namespace EsportsProfileWebApi.Web.Repository;

using Dapper;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.User;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

public class UserRepository(IConfiguration configuration) : IUserRepository
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();

    public async Task<UserEntity?> RegisterUser(UserRegisterRequestModel request)
    {
        Guid user_id = Guid.NewGuid();
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new();
        parameters.Add("p_username", request.Username, DbType.String);
        parameters.Add("p_password", Helpers.PasswordHashing.HashPassword(request.Password), DbType.String);
        parameters.Add("p_email", request.Email, DbType.String);
        parameters.Add("p_user_id",user_id.ToString(), dbType: DbType.String);

        await connection.ExecuteAsync("register", parameters, commandType: CommandType.StoredProcedure);

        var user_Id = parameters.Get<string>("p_user_id");

        await connection.CloseAsync();

        var user = new UserEntity()
        {
            Id = user_Id,
            Role = "User"
        };

        return user;
    }

    public async Task<UserEntity?> LoginUser(UserLoginRequestModel request)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new ();
        parameters.Add("p_username", request.Username, DbType.String);
        parameters.Add("p_password", Helpers.PasswordHashing.HashPassword(request.Password), DbType.String);
        parameters.Add("p_user_id", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("p_user_role", dbType: DbType.String, direction: ParameterDirection.Output);

        await connection.ExecuteAsync("login", parameters, commandType: CommandType.StoredProcedure);

        string user_Id = parameters.Get<string>("p_user_id");
        string user_role = parameters.Get<string>("p_user_role");
        
        await connection.CloseAsync();

        if (user_Id == null || user_role == null)
            return null;

        return new UserEntity{
            Id = user_Id,
            Role = user_role
        };
    }
}