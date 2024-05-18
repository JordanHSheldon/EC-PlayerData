namespace EsportsProfileWebApi.INFRASTRUCTURE;

using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.Data;
using System.Collections.Generic;

public interface IDataRepository
{
    Task<DataEntity> GetUserData(GetDataRequestModel dataRequest);

    Task<UpdateDataResponseModel> UpdateData(UpdateDataRequestModel request);

    Task<List<DataEntity>> GetAllDataAsync();
}