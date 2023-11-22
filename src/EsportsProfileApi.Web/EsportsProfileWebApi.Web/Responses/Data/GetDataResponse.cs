using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

namespace EsportsProfileWebApi.CROSSCUTTING.Responses.Data
{
    public class GetDataResponse
    {
        public double Sensitivity { get; set; } = 2.5;

        public int Dpi { get; set; } = 400;

        public int ResolutionX { get; set; } = 1920;

        public int ResolutionY { get; set; } = 1080;

        public string ResolutionType { get; set; } = "Native";

        public string? Mouse { get; set; } = string.Empty;

        public string? MousePad { get; set; } = string.Empty;

        public string? KeyBoard { get; set; } = string.Empty;

        public string? HeadSet { get; set; } = string.Empty;

        public string? Monitor { get; set; } = string.Empty;

        public string? Username { get; set; } = string.Empty;

        public GetPeripheralsResponse? Peripherals { get; set; }

        public GetSettingsResponse? Settings { get; set; }
    }
}
