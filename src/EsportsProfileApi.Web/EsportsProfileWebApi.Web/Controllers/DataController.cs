namespace EsportsProfileWebApi.Web.Controllers;

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

    [HttpPost]
    [Route("GetDataByName")]
    public ActionResult GetDataByName(GetDataRequest getDataRequestDto)
    {
        var result = _dataOrchestrator.GetData(getDataRequestDto);
        return new JsonResult(result);
    }

    [Authorize]
    [HttpPost]
    [Route("GetDataById")]
    public ActionResult GetDataById(GetDataRequest getDataRequestDto)
    {
        var result = _dataOrchestrator.GetData(getDataRequestDto);
        return new JsonResult(result);
    }

    [Authorize]
    [HttpPost]
    [Route("UpdateDataById")]
    public ActionResult UpdateDataById(UpdateDataRequest updateDataRequestDto)
    {
        return new JsonResult(_dataOrchestrator.UpdateData(updateDataRequestDto));
    }

    [HttpPost]
    [Route("GetAllData")]
    public ActionResult GetAllData()
    {
        return new JsonResult(_dataOrchestrator.GetAllData());
    }
}