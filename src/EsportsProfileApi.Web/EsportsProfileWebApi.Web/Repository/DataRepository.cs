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
        _mongoClient = new MongoClient(configuration.GetConnectionString("MongoConnection") ?? throw new NotImplementedException());

        var mongoDatabase = _mongoClient.GetDatabase("STDATA");

        _userCollection = mongoDatabase.GetCollection<GetDataResponse>("Settings");
    }

    public async Task<bool> UpdateDataByAlias(UpdateDataRequest request)
    {
        var temp = await _userCollection.UpdateOneAsync(data => data.Username == request.Username, Builders<GetDataResponse>.Update.Set(data => data.Dpi, request.Dpi));
        return true;
    }

    public async Task<string> CreateUserDataForUsername(string username)
    {
        await _userCollection.InsertOneAsync(new GetDataResponse() { Username = username });
        var user = await _userCollection.Find(data => data.Username == username).FirstAsync();
        return user.Id;
    }

    public async Task<GetDataResponse> GetUserDataByAlias(GetDataRequest dataRequest)
    {
        return await _userCollection.Find(data => data.Username == dataRequest.Username).FirstAsync();
    }

    public async Task<List<GetDataResponse>> GetAllDataAsync()
    {
        return await _userCollection.Find(_ => true).ToListAsync();
    }
}
