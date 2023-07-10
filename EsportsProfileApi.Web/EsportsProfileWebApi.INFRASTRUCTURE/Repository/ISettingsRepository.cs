
namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

    public interface ISettingsRepository
    {
        public SettingsResponseDTO? GetAllSettingsForPlayer(SettingsRequestDTO settingsRequest);

        public PeripheralsResponseDTO getAllPeripheralsForPlayer(PeripheralsRequestDTO peripheralsRequest);
    }
}

