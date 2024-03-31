namespace EsportsProfileWebApi.INFRASTRUCTURE;

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using MongoDB.Driver;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.Data;

public class DataRepository : IDataRepository
{
    private readonly IMongoCollection<DataEntity> _userCollection;
    private readonly MongoClient _mongoClient;

    public DataRepository(IConfiguration configuration)
    {
        _mongoClient = new MongoClient(configuration.GetConnectionString("MongoConnection") ?? throw new NotImplementedException());

        var mongoDatabase = _mongoClient.GetDatabase("EsportsCompare");

        _userCollection = mongoDatabase.GetCollection<DataEntity>("cs_data");
    }

    public async Task<bool> UpdateDataById(UpdateDataRequestModel request)
    {
        var temp = await _userCollection.UpdateOneAsync(data => data.UserId == request.Username, Builders<DataEntity>.Update.Set(data => data.Dpi, request.Dpi));
        return true;
    }

    public async Task<string> CreateCSData(string UserId)
    {
        await _userCollection.InsertOneAsync(new DataEntity() { UserId = UserId });
        var user = await _userCollection.Find(data => data.UserId == UserId).FirstOrDefaultAsync();
        return user.Id;
    }

    public async Task<DataEntity> GetUserDataById(GetDataRequestModel dataRequest)
    {
        return await _userCollection.Find(data => data.UserId == dataRequest.UserId).FirstOrDefaultAsync();
    }

    public async Task<List<DataEntity>> GetAllDataAsync()
    {
        return await _userCollection.Find(_ => true).ToListAsync();
    }
}
