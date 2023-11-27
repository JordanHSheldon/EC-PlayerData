namespace EsportsProfileWebApi.Web.Requests.User;

using System.ComponentModel.DataAnnotations;
public class LoginRequest
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
}
