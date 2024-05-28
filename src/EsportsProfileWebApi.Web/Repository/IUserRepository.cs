namespace EsportsProfileWebApi.Web.Repository;

using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.User;

public interface IUserRepository
{
    Task<UserEntity?> RegisterUser(UserRegisterRequestModel request);

    Task<UserEntity?> LoginUser(UserLoginRequestModel request);
}
