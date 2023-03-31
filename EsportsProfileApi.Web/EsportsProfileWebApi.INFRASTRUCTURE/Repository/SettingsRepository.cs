using System.Data.SqlClient;
using Dapper;
using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.Settings;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{

    public class SettingsRepository : ISettingsRepository
    {

        public SettingsResponseDTO? GetAllSettingsForPlayer(SettingsRequestDTO settingsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Settingsinsertupdatedelete '" + settingsRequest.Alias + "',0.0,'','','','','SelectDistinct'";
            var getEntityResult = con.Query<SettingsResponseDTO>(sql, new SettingsResponseDTO { });
            return getEntityResult.FirstOrDefault(x=> x.Alias == settingsRequest.Alias);
        }
    }
}
