namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.Web.Repository;
using EsportsProfileWebApi.Web.Requests.User;
using EsportsProfileWebApi.Web.Responses.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class UserOrchestrator : IUserOrchestrator
{
    private readonly IUserRepository _userRepository;
    public UserOrchestrator(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new NotImplementedException();
    }

    public async Task<GetUserDataResponse> RegisterUser(RegisterRequest request)
    {
        // find if the user is valid, if they are create the claims or retrieve them from the db
        var alreadyExists = _userRepository.CheckIfUserExists(request.Username,request.Email).Result;
        if (alreadyExists)
            throw new Exception("User already exists");

        // create the user and add them to the db
        var user = _userRepository.RegisterUser(request);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("SuperDuperSecretValueSuperDuperSecretValue");

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = "https://localhost:5000",
            Audience = "https://localhost:5000",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        return await Task.FromResult(new GetUserDataResponse
        {
            Id = user.Id,
            Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
        });
    }
}
