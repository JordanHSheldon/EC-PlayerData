namespace EsportsProfileWebApi.Web.Controllers;

using AutoMapper;
using DTOs;
using DTOs.User;
using Orchestrators;
using Orchestrators.Models.User;
using Microsoft.AspNetCore.Mvc;
using Responses.User;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserOrchestrator userOrchestrator, IMapper mapper) : Controller
{
    private readonly IUserOrchestrator _userOrchestrator = userOrchestrator ?? throw new NotImplementedException();
    private readonly IMapper _mapper = mapper ?? throw new NotImplementedException();

    [HttpPost]
    [Route("Register")]
    public async Task<UserRegisterResponseDTO> Register(UserRegisterRequestDTO userRegisterRequest)
    {
        var request = _mapper.Map<UserRegisterRequestModel>(userRegisterRequest);
        var result = await _userOrchestrator.RegisterUser(request);

        return _mapper.Map<UserRegisterResponseDTO>(result);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<UserLoginResponseDTO> Login(UserLoginRequestDTO userLoginRequest)
    {
        var request = _mapper.Map<UserLoginRequestModel>(userLoginRequest);
        var result = await _userOrchestrator.LoginUser(request);

        return _mapper.Map<UserLoginResponseDTO>(result);
    }

    [HttpGet]
    [Route("DiscordLogin")]
    public IActionResult DiscordLogin()
    {
        return Redirect("https://discord.com/oauth2/authorize?client_id=1362549805502431262&response_type=code&redirect_uri=https%3A%2F%2Flocalhost%3A7191%2Fapi%2Fuser%2FDiscordRedirect&scope=identify+email");
    }

    [HttpGet]
    [Route("DiscordRedirect")]
    public async Task<UserLoginResponseDTO> DiscordRedirect(string code)
    {
        var result = await _userOrchestrator.DiscordLogin(code);

        HttpContext.Response.Cookies.Append("user_id", result.Result, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None
        });

        return _mapper.Map<UserLoginResponseDTO>(result);   
    }
}