
namespace EsportsProfileWebApi.Web.Controllers
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        private readonly IDataOrchestrator _dataOrchestrator;

        public DataController(IDataOrchestrator dataOrchestrator)
        {
            _dataOrchestrator = dataOrchestrator ?? throw new NotImplementedException();
        }

        [Authorize]
        [HttpPost]
        [Route("GetDataById")]
        public ActionResult GetDataById(GetDataRequestDTO getDataRequestDTO)
        {
            return new JsonResult(_dataOrchestrator.GetData(getDataRequestDTO));
        }

        [HttpPost]
        [Route("UpdateDataById")]
        public ActionResult UpdateDataById(UpdateDataRequestDTO updateDataRequestDTO)
        {
            return new JsonResult(_dataOrchestrator.UpdateData(updateDataRequestDTO));
        }

        [HttpPost]
        [Route("GetAllSettings")]
        public ActionResult GetAllSettings(GetSettingsRequestDTO settingsRequest)
        {
            return new JsonResult(_dataOrchestrator.GetAllSettings(settingsRequest));
        }

        [HttpPost]
        [Route("GetAllPeripherals")]
        public ActionResult GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            return new JsonResult(_dataOrchestrator.GetAllPeripherals(peripheralsRequest));
        }
    }
}
