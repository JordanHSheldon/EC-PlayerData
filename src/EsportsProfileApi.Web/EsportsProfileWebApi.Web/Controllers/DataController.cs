namespace EsportsProfileWebApi.Web.Controllers;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.Web.Orchestrators;
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
        var result = _dataOrchestrator.GetUserDataByAlias(getDataRequestDto);
        return new JsonResult(result);
    }

    [Authorize]
    [HttpPost]
    [Route("GetAllUserData")]
    public async Task<List<GetDataResponse>> GetAllDataAsync()
    {
        var result = await _dataOrchestrator.GetAllDataAsync();
        return result;
    }

    [Authorize]
    [HttpPost]
    [Route("GetDataById")]
    public ActionResult GetDataById(GetDataRequest getDataRequestDto)
    {
        var result = _dataOrchestrator.GetUserDataByAlias(getDataRequestDto);
        return new JsonResult(result);
    }

    [Authorize]
    [HttpPost]
    [Route("UpdateDataByAlias")]
    public ActionResult UpdateDataByAlias(UpdateDataRequest updateDataRequestDto)
    {
        return new JsonResult(_dataOrchestrator.UpdateDataByAlias(updateDataRequestDto));
    }
}