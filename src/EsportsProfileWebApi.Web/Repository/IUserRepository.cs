namespace EsportsProfileWebApi.Web.Repository;

using EsportsProfileWebApi.Web.Orchestrators;
using Orchestrators.Models.User;

public interface IUserRepository
{
    Task<int> RegisterUser(UserRegisterRequestModel request);

    Task<int> LoginUser(UserLoginRequestModel request);

    Task<int> DiscordLogin(DiscordUserData discordUserData);
}
