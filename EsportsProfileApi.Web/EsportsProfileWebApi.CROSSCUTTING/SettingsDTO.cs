
namespace EsportsProfileWebApi.CROSSCUTTING
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class SettingsDTO
    {
        public decimal Sensitivity { get; set; }
        public int Dpi { get; set; }

        public int ResolutionX { get; set; } = 1920;

        public int ResolutionY { get; set; } = 1080;

        public string ResolutionType { get; set; } = string.Empty;

    }
}
