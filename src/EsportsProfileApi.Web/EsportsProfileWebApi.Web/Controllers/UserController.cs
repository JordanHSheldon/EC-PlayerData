namespace EsportsProfileWebApi.Web.Controllers;

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
    public ActionResult Register()
    {
        return new JsonResult(false);
    }

    [HttpPost]
    [Route("Login")]
    public ActionResult Login()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("SuperDuperSecretValueSuperDuperSecretValue");
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, "username"), // Replace with user claims
            new Claim(ClaimTypes.Email, "user@example.com"),
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
