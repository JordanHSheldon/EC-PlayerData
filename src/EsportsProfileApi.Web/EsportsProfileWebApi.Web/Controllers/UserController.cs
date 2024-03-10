namespace EsportsProfileWebApi.Web.Controllers;

using EsportsProfileWebApi.Web.Orchestrators;
using EsportsProfileWebApi.Web.Requests.User;
using Microsoft.AspNetCore.Mvc;
using Responses.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserOrchestrator _userOrchestrator;

    public UserController(IUserOrchestrator userOrchestrator)
    {
        _userOrchestrator = userOrchestrator ?? throw new NotImplementedException();
    }

    [HttpPost]
    [Route("Register")]
    public async Task<GetUserDataResponse> Register(RegisterRequest request)
    {
        var result = await _userOrchestrator.RegisterUser(request);
        return result;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<GetUserDataResponse> Login(LoginRequest request)
    {
        var result = await _userOrchestrator.LoginUser(request);
        return result;
    }
}