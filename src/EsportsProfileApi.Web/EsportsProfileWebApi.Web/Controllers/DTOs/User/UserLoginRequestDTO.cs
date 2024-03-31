namespace EsportsProfileWebApi.Web.Controllers.DTOs.User;

public class UserLoginRequestDTO
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
