using System.Data.SqlClient;
using Dapper;
using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{

    public class SettingsRepository : ISettingsRepository
    {

        public SettingsResponseDTO? GetAllSettingsForPlayer(SettingsRequestDTO settingsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Settingsinsertupdatedelete '" + settingsRequest.Id + "',0.0,'','','','','SelectDistinct'";
            var getEntityResult = con.Query<SettingsResponseDTO>(sql, new SettingsResponseDTO { });
            return getEntityResult.First();
        }

        public PeripheralsResponseDTO getAllPeripheralsForPlayer(PeripheralsRequestDTO peripheralsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Peripheralinsertupdatedelete '" + peripheralsRequest.Id + "','','','','','','SelectDistinct'";
            var getEntityResult = con.Query<PeripheralsResponseDTO>(sql, new PeripheralsResponseDTO { });
            return getEntityResult.First();
        }

        public bool AddPeripheralsToPlayer(PeripheralsRequestDTO peripheralsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Peripheralinsertupdatedelete '" + peripheralsRequest.Id + "','','','','','','Insert'";
            var getEntityResult = con.Query<PeripheralsResponseDTO>(sql, new PeripheralsResponseDTO { });
            return true;
        }
    }
}
