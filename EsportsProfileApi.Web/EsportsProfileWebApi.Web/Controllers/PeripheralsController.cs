
namespace EsportsProfileWebApi.Web.Controllers
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.DOMAIN;
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
        public ActionResult GetAllPeripherals(object kevin)
        {
            return new JsonResult(new PeripheralsDTO{ KeyBoard="G915 TKL", Mouse = "gpro", MousePad="Aqua Control plus", HeadSet="Steel Series Pro Nova", Monitor="Acer" });
            //return new JsonResult(_settingsOrchestrator.getAllPeripheralsForPlayer(playerName));
        }


    }
}
