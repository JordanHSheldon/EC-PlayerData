
namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.Settings;

    public interface ISettingsRepository
    {
        public SettingsResponseDTO getAllSettingsForPlayer(SettingsRequestDTO settingsRequest);
    }
}
