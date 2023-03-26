using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.INFRASTRUCTURE;

namespace EsportsProfileWebApi.DOMAIN
{
    public class PeripheralOrchestrator : IPeripheralOrchestrator
    {
        private readonly IPeripheralsRepository _peripheralsRepository;

        public PeripheralOrchestrator(IPeripheralsRepository peripheralsRepository)
        {
            _peripheralsRepository = peripheralsRepository ?? throw new NotImplementedException();
        }

        public PeripheralsDTO getAllPeripheralsForPlayer(string playerName)
        {
            return _peripheralsRepository.getAllPeripheralsForPlayer(playerName);
        }

    }
}
