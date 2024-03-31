namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.INFRASTRUCTURE;
using EsportsProfileWebApi.Web.Helpers;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository;

public class UserOrchestrator(IUserRepository userRepository, IDataRepository dataRepository, IConfiguration config) : IUserOrchestrator
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new NotImplementedException();
    private readonly IDataRepository _dataRepository = dataRepository ?? throw new NotImplementedException();
    private readonly TokenBuilder _tokenBuilder = new(config);

    public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel request)
    {
        // check if user exists
        var exists = await _userRepository.UserExists(request.Username);
        if (exists == true)
            throw new Exception("User Already Exists");

        // create the user and add them to the db
        var user = await _userRepository.RegisterUser(request)
                ?? throw new Exception("Error creating user data");

        // create the user's cs data
        _ = await _dataRepository.CreateCSData(user.UserId)
                ?? throw new Exception("Error creating cs data");

        return new UserRegisterResponseModel()
        {
            Token = await _tokenBuilder.BuildToken(user.Claims)
        };
    }

    public async Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel request)
    {
        // retrieve the claims, if they do not exist for the user throw an exception
        var user = await _userRepository.LoginUser(request);

        if (user == null)
            throw new Exception("Incorrect or unknown credentials");

        return new UserLoginResponseModel()
        {
            Token = await _tokenBuilder.BuildToken(user.Claims)
        };
    }
}
