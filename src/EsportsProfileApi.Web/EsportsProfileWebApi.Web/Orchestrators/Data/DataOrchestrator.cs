using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
using EsportsProfileWebApi.INFRASTRUCTURE;

namespace EsportsProfileWebApi.DOMAIN
{
    public class DataOrchestrator : IDataOrchestrator
    {
        private readonly IDataRepository _dataRepository;

        public DataOrchestrator(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository ?? throw new NotImplementedException();
        }

        public IEnumerable<GetDataResponse> GetAllData(GetDataRequestDTO dataRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetPeripheralsResponse> GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetSettingsResponse> GetAllSettings(GetSettingsRequestDTO settingsRequest)
        {
            throw new NotImplementedException();
        }

        public GetDataResponse GetData(GetDataRequestDTO dataRequest)
        {
            return _dataRepository.GetData(dataRequest);
        }

        public bool UpdateData(UpdateDataRequestDTO peripheralsRequest)
        {
            throw new NotImplementedException();
        }
    }
}
