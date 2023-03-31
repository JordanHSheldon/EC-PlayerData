
namespace EsportsProfileWebApi.Web.Controllers
{
    using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : Controller
    {
        private ISettingsOrchestrator _settingsOrchestrator;

        public SettingsController(ISettingsOrchestrator settingsOrchestrator)
        {
            _settingsOrchestrator = settingsOrchestrator ?? throw new NotImplementedException();
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult AddSettingsToPlayer(int playerId)
        {
            return new JsonResult("");
        }

        [HttpPost]
        [Route("GetAllSettings")]
        public ActionResult GetAllSettings(object kevin)
        {
            return new JsonResult(new { sensitvity = "1",Dpi="800", Resolution = "1920x1080",ResolutionType = "Native" });
            //return new JsonResult(_settingsOrchestrator.getAllSettingsForPlayer(playerName));
        }


    }
}
