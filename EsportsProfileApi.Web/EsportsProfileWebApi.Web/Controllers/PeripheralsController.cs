
namespace EsportsProfileWebApi.Web.Controllers
{
    using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.PeripheralDTOs;
    using EsportsProfileWebApi.DOMAIN.Orchestrators.Peripherals;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PeripheralsController : ControllerBase
    {
        private readonly IPeripheralOrchestrator _peripheralOrchestrator;

        public PeripheralsController(IPeripheralOrchestrator peripheralsOrchestrator)
        {
            _peripheralOrchestrator = peripheralsOrchestrator ?? throw new NotImplementedException();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult AddPeripheralsToPlayer(int playerId)
        {
            return new JsonResult("");
        }

        [HttpPost]
        [Route("GetAllPeripherals")]
        public ActionResult GetAllPeripherals(PeripheralsRequestDTO peripheralsRequest)
        {
            return new JsonResult(_peripheralOrchestrator.getAllPeripheralsForPlayer(peripheralsRequest));
        }

        [HttpPost]
        [Route("AddPeripherals")]
        public ActionResult AddPeripherals(PeripheralsRequestDTO peripheralsRequest)
        {
            return new JsonResult(_peripheralOrchestrator.getAllPeripheralsForPlayer(peripheralsRequest));
        }


    }
}
