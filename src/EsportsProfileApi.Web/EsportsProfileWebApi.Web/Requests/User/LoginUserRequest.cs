namespace EsportsProfileWebApi.Web.Requests.User
{
    using System.ComponentModel.DataAnnotations;
    public class LoginUserRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
