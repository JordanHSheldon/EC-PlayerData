namespace EsportsProfileWebApi.Web.Helpers;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenBuilder(IConfiguration config)
{
    private readonly int _expiryInMinutes = 43800;
    private readonly IConfiguration _config = config ?? throw new NotImplementedException();

    public async Task<string> BuildToken(IEnumerable<Claim> claims)
    {
        if (claims == null || !claims.Any())
            throw new ArgumentNullException(nameof(claims));

        var key = _config.GetValue<string>("Authentication:Key") ?? throw new NotImplementedException();
        var tokenHandler = new JwtSecurityTokenHandler();
        var encodedKey = Encoding.UTF8.GetBytes(key) ?? throw new NotImplementedException();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_expiryInMinutes),
            Issuer = _config.GetValue<string>("Authentication:Issuer"),
            Audience = _config.GetValue<string>("Authentication:Audience"),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(encodedKey), SecurityAlgorithms.HmacSha256)
        };

        return await Task.FromResult(tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)));
    }
}