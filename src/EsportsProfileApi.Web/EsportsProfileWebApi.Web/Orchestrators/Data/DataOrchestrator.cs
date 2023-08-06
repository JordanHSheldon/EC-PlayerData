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

        public GetDataResponseDTO GetData(GetDataRequestDTO dataRequest)
        {
            return _dataRepository.GetData(dataRequest);
        }

        public GetSettingsResponseDTO GetSettings(GetSettingsRequestDTO settingsRequest)
        {
            return _dataRepository.GetSettings(settingsRequest);
        }

        public GetPeripheralsResponseDTO GetPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            return _dataRepository.GetPeripherals(peripheralsRequest);
        }

        public IEnumerable<GetSettingsResponseDTO> GetAllSettings(GetSettingsRequestDTO settingsRequest)
        {
            return _dataRepository.GetAllSettings(settingsRequest);
        }

        public IEnumerable<GetPeripheralsResponseDTO> GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            return _dataRepository.GetAllPeripherals(peripheralsRequest);
        }

        public IEnumerable<GetDataResponseDTO> GetAllData(GetDataRequestDTO dataRequest)
        {
            return _dataRepository.GetAllData(dataRequest);
        }

        public bool UpdateSettings(UpdateSettingsRequestDTO settingsRequest)
        {
            return _dataRepository.UpdateSettings(settingsRequest);
        }

        public bool UpdatePeripherals(UpdatePeripheralsRequestDTO peripheralsRequest)
        {
            return _dataRepository.UpdatePeripherals(peripheralsRequest);
        }

        public bool UpdateData(UpdateDataRequestDTO peripheralsRequest)
        {
            return _dataRepository.UpdateData(peripheralsRequest);
        }
    }
}
