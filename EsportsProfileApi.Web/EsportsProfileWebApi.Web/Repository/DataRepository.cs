
using Microsoft.Data.SqlClient;
using Dapper;
using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{

    public class DataRepository : IDataRepository
    {
        public GetDataResponseDTO GetData(GetDataRequestDTO dataRequest)
        {
            var data = new GetDataResponseDTO();
            data.SettingsResponse = new GetSettingsResponseDTO()
            {
                Dpi = 800,
                Sensitivity = 1,
                ResolutionX = 1920,
                ResolutionY = 1080,
                ResolutionType = "Native"
            };
            data.PeripheralsResponse = new GetPeripheralsResponseDTO()
            {
                Monitor = "Benq",
                Mouse = "Gprowireless",
                MousePad = "Aqua Control PLus",
                KeyBoard = "Wooting 60HE",
                HeadSet = "SteelSeries Arctis Nova Pro"
            };
            return data;
        }

        public GetSettingsResponseDTO GetSettings(GetSettingsRequestDTO settingsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Settingsinsertupdatedelete '" + settingsRequest.Id + "',0.0,'','','','','SelectDistinct'";
            var getEntityResult = con.Query<GetSettingsResponseDTO>(sql, new GetSettingsResponseDTO { });
            return getEntityResult.First();
        }

        public GetPeripheralsResponseDTO GetPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Peripheralinsertupdatedelete '" + peripheralsRequest.Id + "','','','','','','SelectDistinct'";
            var getEntityResult = con.Query<GetPeripheralsResponseDTO>(sql, new GetPeripheralsResponseDTO { });
            return getEntityResult.First();
        }

        public IEnumerable<GetSettingsResponseDTO> GetAllSettings(GetSettingsRequestDTO settingsRequest)
        {
            return new List<GetSettingsResponseDTO>();
        }

        public IEnumerable<GetPeripheralsResponseDTO> GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            return new List<GetPeripheralsResponseDTO>();
        }

        public IEnumerable<GetDataResponseDTO> GetAllData(GetDataRequestDTO settingsRequest)
        {
            return new List<GetDataResponseDTO>();
        }

        public bool UpdatePeripherals(UpdatePeripheralsRequestDTO peripheralsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Peripheralinsertupdatedelete '" + peripheralsRequest.Id + "','','','','','','Insert'";
            var getEntityResult = con.Query<GetPeripheralsResponseDTO>(sql, new GetPeripheralsResponseDTO { });
            return true;
        }

        public bool UpdateSettings(UpdateSettingsRequestDTO settingsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Peripheralinsertupdatedelete '" + settingsRequest.Id + "','','','','','','Insert'";
            var getEntityResult = con.Query<GetPeripheralsResponseDTO>(sql, new GetPeripheralsResponseDTO { });
            return true;
        }

        public bool UpdateData(UpdateDataRequestDTO dataRequest)
        {
            return false;
        }
    }
}
