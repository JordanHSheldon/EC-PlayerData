namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.Web.Orchestrators.Models;

public interface IDataOrchestrator
{
    Task<GetDataResponseModel> GetData(GetDataRequestModel dataRequest);

    Task<UpdateDataResponseModel> UpdateData(UpdateDataRequestModel request);

    Task<List<GetDataResponseModel>> GetAllDataAsync();
}