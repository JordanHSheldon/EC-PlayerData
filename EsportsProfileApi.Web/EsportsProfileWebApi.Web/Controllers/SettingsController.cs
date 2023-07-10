
namespace EsportsProfileWebApi.Web.Controllers
{
    using EsportsProfileWebApi.CROSSCUTTING;
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
        public ActionResult AddSettingsById(int playerId)
        {
            return new JsonResult("");
        }

        [HttpPost]
        [Route("UpdateSettings")]
        public ActionResult UpdateSettingsById(int playerId)
        {
            return new JsonResult("");
        }

        [HttpPost]
        [Route("GetAllSettings")]
        public ActionResult GetAllSettings(GetPeripheralsRequestDTO settingsRequest)
        {
            return new JsonResult(_settingsOrchestrator.GetAllSettingsForPlayer(settingsRequest));
        }
    }
}
