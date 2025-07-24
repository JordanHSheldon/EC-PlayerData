using EsportsProfileWebApi.Web.Orchestrators.Models.User;

namespace EsportsProfileWebApi.Web.Orchestrators;


public interface IUserOrchestrator
{
    Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel request);

    Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel request);

    Task<UserLoginResponseModel> DiscordLogin(string code);
}
