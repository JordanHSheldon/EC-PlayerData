namespace EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.Settings
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class SettingsResponseDTO
    {
        public string Alias { get; set; } = string.Empty;
        public decimal Sensitivity { get; set; }
        public int Dpi { get; set; }

        public int ResolutionX { get; set; }

        public int ResolutionY { get; set; }

        public string ResolutionType { get; set; } = string.Empty;

    }
}
