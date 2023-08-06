
namespace EsportsProfileWebApi.CROSSCUTTING.Requests.Data
{
    public class UpdateDataRequestDTO
    {
        public UpdateSettingsRequestDTO SettingsResponse { get; set; } = new();

        public UpdatePeripheralsRequestDTO PeripheralsResponse { get; set; } = new();
    }
}
