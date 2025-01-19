namespace EsportsProfileWebApi.Web.Repository;

using Orchestrators.Models.User;
using Entities.User;

public interface IUserRepository
{
    Task<UserEntity?> RegisterUser(UserRegisterRequestModel request);

    Task<UserEntity?> LoginUser(UserLoginRequestModel request);
}
