namespace EsportsProfileWebApi.Web.Orchestrators.Models;

public class UserLoginRequestModel
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
