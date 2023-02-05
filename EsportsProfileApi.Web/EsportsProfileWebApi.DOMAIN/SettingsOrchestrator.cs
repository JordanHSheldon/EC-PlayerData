using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.INFRASTRUCTURE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.DOMAIN
{
    public class SettingsOrchestrator : ISettingsOrchestrator
    {
        private ISettingsRepository _settingsRepository;
        public SettingsOrchestrator(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository ?? throw new NotImplementedException();
        }

        public SettingsDTO getAllSettingsForPlayer()
        {
            return _settingsRepository.getAllSettingsForPlayer();
        }
    }
}
