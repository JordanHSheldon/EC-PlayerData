namespace EsportsProfileWebApi.INFRASTRUCTURE;

using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.Data;
using System.Collections.Generic;

public interface IDataRepository
{
    Task<DataEntity> GetUserDataById(GetDataRequestModel dataRequest);

    Task<bool> UpdateDataById(UpdateDataRequestModel request);

    Task<List<DataEntity>> GetAllDataAsync();

    Task<string> CreateCSData(string username);
}