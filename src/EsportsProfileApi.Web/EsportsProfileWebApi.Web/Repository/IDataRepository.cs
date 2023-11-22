
namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

    public interface IDataRepository
    {
        public GetDataResponse GetData(GetDataRequestDTO dataRequest);

        public GetSettingsResponse GetSettings(GetSettingsRequestDTO peripheralsRequest);

        public GetPeripheralsResponse GetPeripherals(GetPeripheralsRequestDTO peripheralsRequest);

        public IEnumerable<GetPeripheralsResponse> GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest);

        public IEnumerable<GetSettingsResponse> GetAllSettings(GetSettingsRequestDTO settingsRequest);

        public IEnumerable<GetDataResponse> GetAllData(GetDataRequestDTO dataRequest);

        public bool UpdateSettings(UpdateSettingsRequestDTO settingsRequest);

        public bool UpdatePeripherals(UpdatePeripheralsRequestDTO peripheralsRequest);
    }
}

