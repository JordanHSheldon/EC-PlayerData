using System.Data.SqlClient;
using Dapper;
using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.Settings;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{

    public class SettingsRepository : ISettingsRepository
    {

        public SettingsResponseDTO getAllSettingsForPlayer(SettingsRequestDTO settingsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Peripheralinsertupdatedelete " + settingsRequest.Alias + ",'','','','','','Select'";
            var getEntityResult = con.Query<SettingsResponseDTO>(sql, new SettingsResponseDTO { });
            return getEntityResult.FirstOrDefault();
        }
    }
}
