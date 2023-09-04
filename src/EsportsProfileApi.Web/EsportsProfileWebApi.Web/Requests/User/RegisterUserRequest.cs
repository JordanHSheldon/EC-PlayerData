namespace EsportsProfileWebApi.Web.Requests.User
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserRequest
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MinLength(10)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [MinLength(1)]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [MinLength(1)]
        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}