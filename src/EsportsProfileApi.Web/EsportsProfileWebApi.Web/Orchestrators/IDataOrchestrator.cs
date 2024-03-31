namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.Web.Orchestrators.Models;

public interface IDataOrchestrator
{
    Task<GetDataResponseModel> GetDataById(GetDataRequestModel dataRequest);

    Task<UpdateDataRequestModel> UpdateDataById(UpdateDataRequestModel request);

    Task<List<GetDataResponseModel>> GetAllDataAsync();

    Task<string> CreateCSData(string username);
}