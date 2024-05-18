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
        _mongoClient = new MongoClient(configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException());

        var mongoDatabase = _mongoClient.GetDatabase("EsportsCompare");

        _userCollection = mongoDatabase.GetCollection<DataEntity>("cs_data");
    }

    public async Task<UpdateDataResponseModel> UpdateData(UpdateDataRequestModel request)
    {
        var temp = await _userCollection.UpdateOneAsync(data => data.UserName == request.Username,
            Builders<DataEntity>.Update.Set(data => data.Dpi, request.Dpi)
                                       .Set(data => data.Sensitivity, request.Sensitivity)
                                       .Set(data => data.ResolutionX, request.ResolutionX)
                                       .Set(data => data.ResolutionY, request.ResolutionY)
                                       .Set(data => data.ResolutionType, request.ResolutionType)
                                       .Set(data => data.Mouse, request.Mouse)
                                       .Set(data => data.MousePad, request.MousePad)
                                       .Set(data => data.KeyBoard, request.KeyBoard)
                                       .Set(data => data.HeadSet, request.HeadSet)
                                       .Set(data => data.Monitor, request.Monitor));
        return new UpdateDataResponseModel { IsSuccessful = true };
    }

    public async Task<DataEntity> GetUserData(GetDataRequestModel dataRequest)
    {
        return await _userCollection.Find(data => data.UserName == dataRequest.UserName).FirstOrDefaultAsync();
    }

    public async Task<List<DataEntity>> GetAllDataAsync()
    {
        return await _userCollection.Find(_ => true).ToListAsync();
    }
}
