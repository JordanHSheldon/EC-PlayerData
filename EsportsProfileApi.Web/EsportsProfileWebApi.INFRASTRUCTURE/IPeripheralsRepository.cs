using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.PeripheralDTOs;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    public interface IPeripheralsRepository
    {
        public PeripheralsResponseDTO getAllPeripheralsForPlayer(PeripheralsRequestDTO peripheralsRequest);
    }
}
