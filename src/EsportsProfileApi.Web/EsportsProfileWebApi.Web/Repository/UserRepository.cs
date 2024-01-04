namespace EsportsProfileWebApi.Web.Repository;

using Dapper;
using EsportsProfileWebApi.Web.Requests.User;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

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
        await connection.OpenAsync();

        var parameters = new DynamicParameters();
        parameters.Add("@Username", username);
        parameters.Add("@Email", email);

        var result = await connection.QueryAsync<int>(
            "CheckIfUserExists",
            parameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: 10
        );
        connection.Close();
        return await Task.FromResult(result.Count().Equals(0));
    }

    public async Task<bool> RegisterUser(RegisterRequest request)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var parameters = new DynamicParameters();
        parameters.Add("@Username", request.Username);
        parameters.Add("@PasswordHash", request.Password);
        parameters.Add("@Email", request.Email);

        var result = await connection.QueryAsync<int>(
            "RegisterUser",
            parameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: 10
        );

        return true;
    }
}