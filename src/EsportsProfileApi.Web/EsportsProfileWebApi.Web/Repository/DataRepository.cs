namespace EsportsProfileWebApi.INFRASTRUCTURE;

using Microsoft.Data.SqlClient;
using Dapper;
using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;

public class DataRepository : IDataRepository
{
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
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();
    }

    public IEnumerable<GetDataResponse> GetAllData()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
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
}
