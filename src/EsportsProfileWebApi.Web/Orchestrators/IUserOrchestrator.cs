using EsportsProfileWebApi.Web.Orchestrators.Models;

namespace EsportsProfileWebApi.Web.Orchestrators;


public interface IUserOrchestrator
{
    Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel request);

    Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel request);
}
