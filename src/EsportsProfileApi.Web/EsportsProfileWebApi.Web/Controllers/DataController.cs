
namespace EsportsProfileWebApi.Web.Controllers
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
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

        [HttpPost]
        [Route("GetDataByName")]
        public ActionResult GetDataByName(GetDataRequestDTO getDataRequestDto)
        {
            var result = _dataOrchestrator.GetData(getDataRequestDto);
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("UpdateDataById")]
        public ActionResult UpdateDataById(UpdateDataRequestDTO updateDataRequestDto)
        {
            return new JsonResult(_dataOrchestrator.UpdateData(updateDataRequestDto));
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
