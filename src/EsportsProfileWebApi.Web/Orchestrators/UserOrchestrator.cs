namespace EsportsProfileWebApi.Web.Orchestrators;

using System.Security.Claims;
using EsportsProfileWebApi.Web.Helpers;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository;

public class UserOrchestrator(IUserRepository userRepository, IConfiguration config) : IUserOrchestrator
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new NotImplementedException();
    private readonly TokenBuilder _tokenBuilder = new(config);

    public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel request)
    {
        request.Username = request.Username.Replace(" ","");
        var user = await _userRepository.RegisterUser(request);
        if (user == null)
        {
            return new UserRegisterResponseModel()
            {
                Result = "Error creating user data"
            };
        }

        var claims = new List<Claim> {
            new ("Id",user.Id!),
            new ("Role",user.Role!)
        };

        return new UserRegisterResponseModel()
        {
            Result = await _tokenBuilder.BuildToken(claims)
        };
    }

    public async Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel request)
    {
        var user = await _userRepository.LoginUser(request);
        if (user == null)
        {
            return new UserLoginResponseModel()
            {
                Result = "Not found"
            };
        }

        var claims = new List<Claim> 
        {
            new ("Id",user?.Id!),
            new ("Role",user?.Role!)
        };

        return new UserLoginResponseModel()
        {
            Result = await _tokenBuilder.BuildToken(claims)
        };
    }
}
