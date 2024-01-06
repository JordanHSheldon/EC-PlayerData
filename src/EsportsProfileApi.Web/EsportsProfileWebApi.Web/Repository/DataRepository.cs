namespace EsportsProfileWebApi.INFRASTRUCTURE;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using MongoDB.Driver;

public class DataRepository : IDataRepository
{
    private readonly IMongoCollection<GetDataResponse> _userCollection;
    private readonly MongoClient _mongoClient;

    public DataRepository(IConfiguration configuration)
    {
        _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");

        var mongoDatabase = _mongoClient.GetDatabase("STDATA");

        _userCollection = mongoDatabase.GetCollection<GetDataResponse>("Settings");
    }

    public Task<bool> UpdateDataByAlias(UpdateDataRequest request)
    {
        var temp = _userCollection.UpdateOne(data => data.Username == request.Username, Builders<GetDataResponse>.Update.Set(data => data.Dpi, request.Dpi));
        return Task.FromResult(true);
    }

    public async Task<string> CreateUserDataForUsername(string username)
    {
        await _userCollection.InsertOneAsync(new GetDataResponse() {Username = username });
        var user = await _userCollection.Find(data => data.Username == username).FirstAsync();
        return user.Id;
    }

    public async Task<GetDataResponse> GetUserDataByAlias(GetDataRequest dataRequest)
    {
        var user = await _userCollection.Find(data => data.Username == dataRequest.Username).FirstAsync();
        return user;
    }

    public async Task<List<GetDataResponse>> GetAllDataAsync()
    {
        var users = await _userCollection.Find(_ => true).ToListAsync();
        return users;
    }
}
