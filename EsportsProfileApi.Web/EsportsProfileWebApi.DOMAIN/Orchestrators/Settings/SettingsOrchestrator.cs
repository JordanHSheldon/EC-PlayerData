using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.Settings;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
using EsportsProfileWebApi.INFRASTRUCTURE;

namespace EsportsProfileWebApi.DOMAIN
{
    public class SettingsOrchestrator : ISettingsOrchestrator
    {
        private readonly ISettingsRepository _settingsRepository;
        public SettingsOrchestrator(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository ?? throw new NotImplementedException();
        }

        public SettingsResponseDTO getAllSettingsForPlayer(SettingsRequestDTO settingsRequest)
        {
            return _settingsRepository.getAllSettingsForPlayer(settingsRequest);
        }
    }
}
