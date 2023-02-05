using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportsProfileWebApi.CROSSCUTTING;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    
    public class SettingsRepository : ISettingsRepository
    {
        public SettingsDTO getAllSettingsForPlayer()
        {
            return new SettingsDTO(); // implement using db
        }
    }
}
