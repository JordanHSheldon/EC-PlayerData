using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportsProfileWebApi.CROSSCUTTING;
namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    public interface ISettingsRepository
    {
        public SettingsDTO getAllSettingsForPlayer(string playerName);
    }
}
