namespace EsportsProfileWebApi.Web.Orchestrators;

using System.Security.Claims;
using Helpers;
using Models.User;
using Repository;

public class UserOrchestrator(IUserRepository userRepository, IConfiguration config) : IUserOrchestrator
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new NotImplementedException();
    private readonly TokenBuilder _tokenBuilder = new(config);

    private const string NotFoundResult = "Not found";
    private const string ErrorResult = "Error creating user data";
    private const string UserExistsResult = "User already exists";

    public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel request)
    {
        try
        {
            var user = await _userRepository.RegisterUser(request);

            if (user.Id == "0")
            {
                return new UserRegisterResponseModel
                {
                    Result = UserExistsResult
                };
            }
            
            var claims = new List<Claim>
            {
                new("Id", user.Id)
            };

            return new UserRegisterResponseModel
            {
                Result = await _tokenBuilder.BuildToken(claims)
            };
        }
        catch (Exception e)
        {
            return new UserRegisterResponseModel
            {
                Result = ErrorResult
            };
        }
    }

    public async Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel request)
    {
        var user = await _userRepository.LoginUser(request);
        if (user.Id == "0")
        {
            return new UserLoginResponseModel
            {
                Result = NotFoundResult
            };
        }

        var claims = new List<Claim> 
        {
            new ("Id",user.Id)
        };

        return new UserLoginResponseModel
        {
            Result = await _tokenBuilder.BuildToken(claims)
        };
    }
}