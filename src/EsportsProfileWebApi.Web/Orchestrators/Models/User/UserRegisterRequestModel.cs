namespace EsportsProfileWebApi.Web.Orchestrators.Models.User;

public class UserRegisterRequestModel
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
