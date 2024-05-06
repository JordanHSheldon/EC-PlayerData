namespace EsportsProfileWebApi.Web.Orchestrators.Models;

public class UserRegisterRequestModel
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
