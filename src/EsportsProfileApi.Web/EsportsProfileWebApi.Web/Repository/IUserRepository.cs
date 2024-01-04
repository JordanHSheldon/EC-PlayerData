using EsportsProfileWebApi.Web.Requests.User;

namespace EsportsProfileWebApi.Web.Repository;

public interface IUserRepository
{
    Task<bool> CheckIfUserExists(string username, string email);

    Task<bool> RegisterUser(RegisterRequest request);

    //Task<bool> LoginUser(string username);
}
