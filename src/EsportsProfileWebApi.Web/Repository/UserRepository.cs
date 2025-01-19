using Microsoft.Data.SqlClient;

namespace EsportsProfileWebApi.Web.Repository;

using Dapper;
using Orchestrators.Models.User;
using Entities.User;
using Microsoft.Extensions.Configuration;
using System.Data;

public class UserRepository(IConfiguration configuration) : IUserRepository
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")
                                                ?? throw new NotImplementedException();

    public async Task<UserEntity?> RegisterUser(UserRegisterRequestModel request)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new();
        parameters.Add("@user_name", request.Username, DbType.String);
        parameters.Add("@user_password", Helpers.PasswordHashing.HashPassword(request.Password), DbType.String);
        parameters.Add("@user_email", request.Email, DbType.String);
        
        var userId = await connection.QueryFirstOrDefaultAsync<int>("register_user", parameters,commandType: CommandType.StoredProcedure);
        
        await connection.CloseAsync();

        var user = new UserEntity
        {
            Id = userId.ToString()
        };

        return user;
    }

    public async Task<UserEntity?> LoginUser(UserLoginRequestModel request)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new ();
        parameters.Add("@user_password", Helpers.PasswordHashing.HashPassword(request.Password), DbType.String);
        parameters.Add("@user_email", request.Email, DbType.String);

        var userId = await connection.QueryFirstOrDefaultAsync<int>("login_user", parameters, commandType: CommandType.StoredProcedure);
        
        await connection.CloseAsync();  

        return new UserEntity{
            Id = userId.ToString()
        }; 
    }   
}