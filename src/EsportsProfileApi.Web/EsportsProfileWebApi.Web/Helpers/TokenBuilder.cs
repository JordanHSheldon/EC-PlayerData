using EsportsProfileWebApi.Web.Responses.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EsportsProfileWebApi.Web.Helpers;

public class TokenBuilder
{
    private static readonly int _expiryInMinutes = 30;

    public static async Task<GetUserDataResponse> BuildToken(string key, string issuer, string audience, List<Claim> claims, string Id)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var encodedKey = Encoding.UTF8.GetBytes(key);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_expiryInMinutes),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(encodedKey), SecurityAlgorithms.HmacSha256)
        };

        return await Task.FromResult(new GetUserDataResponse
        {
            Id = Id,
            Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
        });
    }
}
