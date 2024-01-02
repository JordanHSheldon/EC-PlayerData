namespace EsportsProfileWebApi.Web.Controllers;

using EsportsProfileWebApi.Web.Orchestrators;
using EsportsProfileWebApi.Web.Requests.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Responses.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    List<users> users = new List<users>()
    {
        new users()
        {
            Username = "username",
            password = "password",
        }
    };

    private readonly IDataOrchestrator _dataOrchestrator;

    public UserController(IDataOrchestrator dataOrchestrator)
    {
        _dataOrchestrator = dataOrchestrator ?? throw new NotImplementedException();
    }

    [HttpPost]
    [Route("Users")]
    public async Task<users> GetAsync()
    {
        var result = await _dataOrchestrator.GetAllUsersAsync();
        return result.FirstOrDefault();
    }

    [HttpPost]
    [Route("Register")]
    public ActionResult Register(RegisterRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("SuperDuperSecretValueSuperDuperSecretValue");

        // find if the user is valid, if they are create the claims or retrieve them from the db
        if (users.Contains(new users { Username = request.Username, Email = request.Email }))
            return BadRequest("Account already exists!");

        users.Add(new users()
        {
            Username = request.Username,
            password = request.Password,
            Email = request.Email
        });

        //do this later to get claims and token once the registration is complete.
        var claims = new List<Claim>()
        {
            new (ClaimTypes.Role, "Member"),
            new (ClaimTypes.Name, request.Username), // Replace with user claims
            new (ClaimTypes.Email, request.Email),
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = "https://localhost:5000",
            Audience = "https://localhost:5000",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        return new JsonResult(new GetUserDataResponse
        {
            Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
            Id = 1,
            Claims = claims
        });
    }

    [HttpPost]
    [Route("Login")]
    public ActionResult Login(LoginRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("SuperDuperSecretValueSuperDuperSecretValue");

        // find if the user is valid, if they are create the claims or retrieve them from the db
        if (users.Where(x=> x.Username == request.Username && x.password == request.Password).Count().Equals(0))
            return new NotFoundResult();
        var claims = new List<Claim>()
        {
            new (ClaimTypes.Role, "Admin"),
            new (ClaimTypes.Name, "NADROJ"), // Replace with user claims
            new (ClaimTypes.Email, "Jordanhsheldon@gmail.com"),
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = "https://localhost:5000",
            Audience = "https://localhost:5000",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        return new JsonResult(new GetUserDataResponse
        {
            Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
            Id = 1,
            Claims = claims
        });
    }
}