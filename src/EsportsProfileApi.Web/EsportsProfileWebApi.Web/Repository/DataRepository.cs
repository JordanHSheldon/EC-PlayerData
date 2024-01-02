namespace EsportsProfileWebApi.INFRASTRUCTURE;

using Microsoft.Data.SqlClient;
using Dapper;
using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;
using EsportsProfileWebApi.Web.Controllers;
using MongoDB.Driver;

public class DataRepository : IDataRepository
{
    private readonly IMongoCollection<users> _userCollection;
    private readonly MongoClient _mongoClient;
    private static string _connectionString = string.Empty;
    List<GetDataResponse> data = new ()
    {
        new GetDataResponse() {
            Dpi = 800,
            Sensitivity = 1,
            ResolutionX = 1920,
            ResolutionY = 1080,
            ResolutionType = "Native",
            Monitor = "Benq",
            Mouse = "Gprowireless",
            MousePad = "Aqua Control PLus",
            KeyBoard = "Wooting 60HE",
            HeadSet = "SteelSeries Arctis Nova Pro",
            Username = "NADROJ"
        }
    };

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public DataRepository(IConfiguration configuration)
    {
        _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");

        var mongoDatabase = _mongoClient.GetDatabase("mydb");

        _userCollection = mongoDatabase.GetCollection<users>("users");
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();
    }

    public IEnumerable<GetDataResponse> GetAllData()
    {
        using var connection = new SqlConnection(_connectionString);
        string query = "SELECT Id, Name, Price FROM Product";
        try
        {
            connection.Open();
            var products = connection.Query<GetDataResponse>(query);
            return products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public bool UpdateData(UpdateDataRequest request)
    {
        data[0] = new GetDataResponse
        { 
            Username = "NADROJ"
        };
        return true;
    }

    public GetDataResponse GetData(GetDataRequest dataRequest)
    {
        return data.FirstOrDefault(x => x.Username == dataRequest.Alias)!;
    }

    public async Task<List<users>> GetAllUsersAsync()
    {
        var users =  await _userCollection.Find(_ => true).ToListAsync();
        return users;
    }
}
