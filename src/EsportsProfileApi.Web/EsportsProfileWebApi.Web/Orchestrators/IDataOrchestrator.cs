namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;

public interface IDataOrchestrator
{
    Task<GetDataResponse> GetUserDataByAlias(GetDataRequest dataRequest);

    Task<bool> UpdateDataByAlias(UpdateDataRequest request);

    Task<List<GetDataResponse>> GetAllDataAsync();

    Task<string> CreateUserDataForUsername(string username);
}