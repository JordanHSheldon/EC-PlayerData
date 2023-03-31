
namespace EsportsProfileWebApi.DOMAIN.Orchestrators.Peripherals
{
    using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.PeripheralDTOs;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;

    public interface IPeripheralOrchestrator
    {
        public PeripheralsResponseDTO getAllPeripheralsForPlayer(PeripheralsRequestDTO peripheralsRequest);
    }
}
