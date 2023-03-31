using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.Settings;

namespace EsportsProfileWebApi.DOMAIN.Orchestrators.Settings
{
    public interface ISettingsOrchestrator
    {
        public SettingsResponseDTO? GetAllSettingsForPlayer(SettingsRequestDTO settingsRequest);
    }
}
