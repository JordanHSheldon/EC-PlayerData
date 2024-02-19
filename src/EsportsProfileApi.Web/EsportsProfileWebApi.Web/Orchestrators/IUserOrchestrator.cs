namespace EsportsProfileWebApi.Web.Orchestrators;

using EsportsProfileWebApi.Web.Requests.User;
using EsportsProfileWebApi.Web.Responses.User;

public interface IUserOrchestrator
{
    Task<GetUserDataResponse> RegisterUser(RegisterRequest request);

    Task<GetUserDataResponse> LoginUser(LoginRequest request);
}
