
namespace EsportsProfileWebApi.CROSSCUTTING
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class SettingsRequestDTO
    {
        [Required]
        public string Alias { get; set; } = string.Empty;
    }
}
