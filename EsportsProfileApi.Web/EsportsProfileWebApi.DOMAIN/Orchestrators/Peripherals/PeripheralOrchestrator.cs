using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.PeripheralDTOs;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Peripherals;
using EsportsProfileWebApi.INFRASTRUCTURE.Repository;

namespace EsportsProfileWebApi.DOMAIN
{
    public class PeripheralOrchestrator : IPeripheralOrchestrator
    {
        private readonly IPeripheralsRepository _peripheralsRepository;

        public PeripheralOrchestrator(IPeripheralsRepository peripheralsRepository)
        {
            _peripheralsRepository = peripheralsRepository ?? throw new NotImplementedException();
        }

        public PeripheralsResponseDTO getAllPeripheralsForPlayer(PeripheralsRequestDTO peripheralsRequest)
        {
            return _peripheralsRepository.getAllPeripheralsForPlayer(peripheralsRequest);
        }

    }
}
