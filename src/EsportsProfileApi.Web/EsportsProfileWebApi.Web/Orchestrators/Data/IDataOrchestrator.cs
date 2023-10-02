using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

namespace EsportsProfileWebApi.DOMAIN.Orchestrators.Settings
{
    public interface IDataOrchestrator
    {
        GetDataResponseDTO GetData(GetDataRequestDTO dataRequest);

        IEnumerable<GetSettingsResponseDTO> GetAllSettings(GetSettingsRequestDTO settingsRequest);

        IEnumerable<GetPeripheralsResponseDTO> GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest);

        IEnumerable<GetDataResponseDTO> GetAllData(GetDataRequestDTO dataRequest);

        bool UpdateData(UpdateDataRequestDTO peripheralsRequest);
    }
}

