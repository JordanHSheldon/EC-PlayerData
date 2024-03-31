namespace EsportsProfileWebApi.Web.Responses.User;

public class UserRegisterRequestDTO
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
