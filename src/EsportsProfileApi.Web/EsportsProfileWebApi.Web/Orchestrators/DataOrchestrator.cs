namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.INFRASTRUCTURE;

public class DataOrchestrator(IDataRepository dataRepository) : IDataOrchestrator
{
    private readonly IDataRepository _dataRepository = dataRepository ?? throw new NotImplementedException();

    public async Task<string> CreateUserDataForUsername(string username)
    {
        return await _dataRepository.CreateUserDataForUsername(username);
    }

    public async Task<GetDataResponse> GetUserDataByAlias(GetDataRequest dataRequest)
    {
        return await _dataRepository.GetUserDataByAlias(dataRequest);
    }

    public async Task<bool> UpdateDataByAlias(UpdateDataRequest request)
    {
        return await _dataRepository.UpdateDataByAlias(request);
    }

    public async Task<List<GetDataResponse>> GetAllDataAsync()
    {
        return await _dataRepository.GetAllDataAsync();
    }
}
