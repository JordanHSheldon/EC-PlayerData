namespace EsportsProfileWebApi.Web.Controllers;

using EsportsProfileWebApi.Web.Requests.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Responses.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    [HttpPost]
    [Route("Register")]
    public ActionResult Register(RegisterRequest request)
    {
        return new JsonResult(false);
    }

    [HttpPost]
    [Route("Login")]
    public ActionResult Login(LoginRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("SuperDuperSecretValueSuperDuperSecretValue");

        // find if the user is valid, if they are create the claims or retrieve them from the db

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
            Id = 1
        });
    }

}
