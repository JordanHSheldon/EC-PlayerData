
namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

    public interface IDataRepository
    {
        public GetDataResponseDTO GetData(GetDataRequestDTO dataRequest);

        public GetSettingsResponseDTO GetSettings(GetSettingsRequestDTO peripheralsRequest);

        public GetPeripheralsResponseDTO GetPeripherals(GetPeripheralsRequestDTO peripheralsRequest);

        public IEnumerable<GetPeripheralsResponseDTO> GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest);

        public IEnumerable<GetSettingsResponseDTO> GetAllSettings(GetSettingsRequestDTO settingsRequest);

        public IEnumerable<GetDataResponseDTO> GetAllData(GetDataRequestDTO dataRequest);

        public bool UpdateSettings(UpdateSettingsRequestDTO settingsRequest);

        public bool UpdatePeripherals(UpdatePeripheralsRequestDTO peripheralsRequest);

        public bool UpdateData(UpdateDataRequestDTO peripheralsRequest);
    }
}

