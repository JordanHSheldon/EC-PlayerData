namespace EsportsProfileWebApi.DOMAIN.Orchestrators.Settings
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

    public interface IDataOrchestrator
    {
        GetDataResponse GetData(GetDataRequestDTO dataRequest);

        IEnumerable<GetSettingsResponse> GetAllSettings(GetSettingsRequestDTO settingsRequest);

        IEnumerable<GetPeripheralsResponse> GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest);

        IEnumerable<GetDataResponse> GetAllData(GetDataRequestDTO dataRequest);

        bool UpdateData(UpdateDataRequestDTO peripheralsRequest);
    }
}