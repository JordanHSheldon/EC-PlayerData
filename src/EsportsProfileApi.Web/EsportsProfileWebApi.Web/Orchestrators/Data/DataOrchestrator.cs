namespace EsportsProfileWebApi.DOMAIN;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
using EsportsProfileWebApi.INFRASTRUCTURE;

public class DataOrchestrator : IDataOrchestrator
{
    private readonly IDataRepository _dataRepository;

    public DataOrchestrator(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository ?? throw new NotImplementedException();
    }

    public IEnumerable<GetDataResponse> GetAllData(GetDataRequest dataRequest)
    {
        throw new NotImplementedException();
    }

    public GetDataResponse GetData(GetDataRequest dataRequest)
    {
        return _dataRepository.GetData(dataRequest);
    }

    public bool UpdateData(UpdateDataRequest request)
    {
        return _dataRepository.UpdateData(request);
    }
}
