namespace EsportsProfileWebApi.Web.Repository;

using Dapper;
using EsportsProfileWebApi.Web.Requests.User;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Security.Claims;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();
    }

    public async Task<bool> CheckIfUserExists(string username, string email)
    {
        using var connection = new SqlConnection(_connectionString);

        var parameters = new DynamicParameters();
        parameters.Add("@Username", username);
        parameters.Add("@Email", email);

        var result = await connection.QueryAsync<string>(
            "CheckIfUserExists",
            parameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: 10
        );

        return await Task.FromResult(result.Any());
    }

    public async Task<IEnumerable<Claim>> RegisterUser(RegisterRequest request, string id)
    {
        using var connection = new SqlConnection(_connectionString);

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", id);
        parameters.Add("@Username", request.Username);
        parameters.Add("@PasswordHash", request.Password);
        parameters.Add("@Email", request.Email);

        return await connection.QueryAsync<Claim>(
            "RegisterUser",
            parameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: 10
        );
    }

    public async Task<IEnumerable<Claim>> LoginUser(LoginRequest request)
    {
        using var connection = new SqlConnection(_connectionString);

        var parameters = new DynamicParameters();
        parameters.Add("@Username", request.Username);
        parameters.Add("@PasswordHash", request.Password);

        return await connection.QueryAsync<Claim>(
            "LoginUser",
            parameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: 10
        );
    }
}