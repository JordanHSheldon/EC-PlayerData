
using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

namespace EsportsProfileWebApi.CROSSCUTTING.Responses.Data
{
    public class GetDataResponseDTO
    {
        public GetSettingsResponseDTO SettingsResponse { get; set; } = new();

        public GetPeripheralsResponseDTO PeripheralsResponse { get; set; } = new();
    }
}
