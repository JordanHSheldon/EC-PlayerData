using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

namespace EsportsProfileWebApi.DOMAIN.Orchestrators.Settings
{
    public interface ISettingsOrchestrator
    {
        public SettingsResponseDTO? GetAllSettingsForPlayer(SettingsRequestDTO settingsRequest);

        public PeripheralsResponseDTO getAllPeripheralsForPlayer(PeripheralsRequestDTO peripheralsRequest);
    }
}
