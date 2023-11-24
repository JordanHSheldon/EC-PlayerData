namespace EsportsProfileWebApi.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Responses.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    [HttpPost]
    [Route("Register")]
    public ActionResult Register()
    {
        return new JsonResult(false);
    }

    [HttpPost]
    [Route("Login")]
    public ActionResult Login()
    {
        return new JsonResult(new GetUserDataResponse
        {
            Id = 0,
        });
    }
}
