namespace EsportsProfileWebApi.INFRASTRUCTURE;

using Microsoft.Data.SqlClient;
using Dapper;
using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;
using MongoDB.Driver;

public class DataRepository : IDataRepository
{
    private readonly IMongoCollection<GetDataResponse> _userCollection;
    private readonly MongoClient _mongoClient;
    private static string _connectionString = string.Empty;

    public DataRepository(IConfiguration configuration)
    {
        _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");

        var mongoDatabase = _mongoClient.GetDatabase("STDATA");

        _userCollection = mongoDatabase.GetCollection<GetDataResponse>("Settings");
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();
    }

    public Task<bool> UpdateDataByAlias(UpdateDataRequest request)
    {
        var temp = _userCollection.UpdateOne(data => data.Alias == request.Alias, Builders<GetDataResponse>.Update.Set(data => data.Dpi, request.Dpi));
        return Task.FromResult(true);
    }

    public async Task<GetDataResponse> GetUserDataByAlias(GetDataRequest dataRequest)
    {
        var user = await _userCollection.Find(data => data.Alias == dataRequest.Alias).FirstAsync();
        return user;
    }

    public async Task<List<GetDataResponse>> GetAllDataAsync()
    {
        var users = await _userCollection.Find(_ => true).ToListAsync();
        return users;
    }
}
