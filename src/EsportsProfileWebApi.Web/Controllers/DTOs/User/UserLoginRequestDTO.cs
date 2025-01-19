namespace EsportsProfileWebApi.Web.Controllers.DTOs.User;

public class UserLoginRequestDTO
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
