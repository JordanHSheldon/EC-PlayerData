using EsportsProfileWebApi.Web.Requests.User;
using System.Security.Claims;

namespace EsportsProfileWebApi.Web.Repository;

public interface IUserRepository
{
    Task<bool> CheckIfUserExists(string username, string email);

    Task<IEnumerable<Claim>> RegisterUser(RegisterRequest request, string id);

    //Task<bool> LoginUser(string username);
}
