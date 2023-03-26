using EsportsProfileWebApi.CROSSCUTTING;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.DOMAIN
{
    public interface IPeripheralOrchestrator
    {
        public PeripheralsDTO getAllPeripheralsForPlayer(string playerName);
    }
}
