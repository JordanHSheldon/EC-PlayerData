
namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.Settings;

    public interface ISettingsRepository
    {
        public SettingsResponseDTO? GetAllSettingsForPlayer(SettingsRequestDTO settingsRequest);
    }
}

