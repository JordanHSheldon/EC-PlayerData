using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;
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

        public SettingsResponseDTO? GetAllSettingsForPlayer(SettingsRequestDTO settingsRequest)
        {
            return _settingsRepository.GetAllSettingsForPlayer(settingsRequest);
        }

        public PeripheralsResponseDTO getAllPeripheralsForPlayer(PeripheralsRequestDTO peripheralsRequest)
        {
            return _settingsRepository.getAllPeripheralsForPlayer(peripheralsRequest);
        }
    }
}
