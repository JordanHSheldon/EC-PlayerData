namespace EsportsProfileWebApi.Web.Controllers;

using AutoMapper;
using EsportsProfileWebApi.Web.Controllers.DTOs;
using EsportsProfileWebApi.Web.Controllers.DTOs.User;
using EsportsProfileWebApi.Web.Orchestrators;
using EsportsProfileWebApi.Web.Orchestrators.Models;
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
}