
namespace EsportsProfileWebApi.CROSSCUTTING
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class PlayerCreationDTO
    {
        [Required]
        public string? Fname { get; set; } 

        [Required]
        public string? Lname { get; set; } 

        [Required]
        public string? Alias { get; set; } 
        
        [Required]
        public string? Email{ get; set; } 

        [Required]
        public string? Password { get; set; } 

    }
}
