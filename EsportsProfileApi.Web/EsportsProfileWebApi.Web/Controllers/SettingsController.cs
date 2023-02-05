using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.DOMAIN;
using Microsoft.AspNetCore.Mvc;

namespace EsportsProfileWebApi.Web.Controllers
{

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
        public ActionResult addSettingsToPlayer(int playerId)
        {
            return new JsonResult("");
        }
    }
}
