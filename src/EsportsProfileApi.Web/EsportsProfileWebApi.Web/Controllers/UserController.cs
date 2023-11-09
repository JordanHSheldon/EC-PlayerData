namespace EsportsProfileWebApi.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Responses.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    [HttpPost]
    [Route("CreateUser")]
    public ActionResult GetDataById()
    {
        return new JsonResult(false);
    }

    [HttpPost]
    [Route("GetUserById")]
    public ActionResult GetUserByName()
    {
        return new JsonResult(new GetUserDataResponseDto
        {
            Id = 0,
        });
    }

    [HttpPost]
    [Route("UpdateUserByName")]
    public ActionResult UpdateUserByName()
    {
        return new JsonResult(false);
    }
}
