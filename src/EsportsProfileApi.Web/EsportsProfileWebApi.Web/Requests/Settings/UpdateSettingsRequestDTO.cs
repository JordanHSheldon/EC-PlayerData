
namespace EsportsProfileWebApi.CROSSCUTTING
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class UpdateSettingsRequestDTO
    {
        [Required]
        public int Id { get; set; }

        public decimal Sensitivity { get; set; }

        public int Dpi { get; set; }

        public int ResolutionX { get; set; }

        public int ResolutionY { get; set; }

        public string ResolutionType { get; set; } = string.Empty;
    }
}
