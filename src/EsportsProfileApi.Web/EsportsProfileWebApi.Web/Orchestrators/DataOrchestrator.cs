namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.INFRASTRUCTURE;

public class DataOrchestrator : IDataOrchestrator
{
    private readonly IDataRepository _dataRepository;

    public DataOrchestrator(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository ?? throw new NotImplementedException();
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
