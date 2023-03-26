using EsportsProfileWebApi.CROSSCUTTING;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    public interface IPeripheralsRepository
    {
        public PeripheralsDTO getAllPeripheralsForPlayer(string playerName);
    }
}
