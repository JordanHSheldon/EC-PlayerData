using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.User;

namespace EsportsProfileWebApi.Web.Repository;

public interface IUserRepository
{
    Task<bool> UserExists(string userName);

    Task<UserEntity> RegisterUser(UserRegisterRequestModel request);

    Task<UserEntity> LoginUser(UserLoginRequestModel request);
}
