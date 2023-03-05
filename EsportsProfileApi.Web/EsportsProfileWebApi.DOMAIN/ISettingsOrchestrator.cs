using EsportsProfileWebApi.CROSSCUTTING;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.DOMAIN
{
    public interface ISettingsOrchestrator
    {
        public SettingsDTO getAllSettingsForPlayer(string playerName);
    }
}
