namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    using Microsoft.Data.SqlClient;
    using Dapper;
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Settings;
    using System.Data;
    using EsportsProfileWebApi.INFRASTRUCTURE.Repository.Constants;
    using Microsoft.Extensions.Configuration;

    public class DataRepository : IDataRepository
    {
        private static string _connectionString = string.Empty;

        public DataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();
        }
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
            using var con = new SqlConnection(_connectionString);
            con.Open();
            var sql = "EXEC Settingsinsertupdatedelete '" + settingsRequest.Id + "',0.0,'','','','','SelectDistinct'";
            var getEntityResult = con.Query<GetSettingsResponseDTO>(sql, new GetSettingsResponseDTO { });
            return getEntityResult.First();
        }
        
        public GetPeripheralsResponseDTO GetPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            using var con = new SqlConnection(_connectionString);
            con.Open();

            var sql = "EXEC Peripheralinsertupdatedelete '" + peripheralsRequest.Id + "','','','','','','SelectDistinct'";
            var getEntityResult = con.Query<GetPeripheralsResponseDTO>(sql, new GetPeripheralsResponseDTO { });
            return getEntityResult.First();
        }

        public IEnumerable<GetSettingsResponseDTO> GetAllSettings(GetSettingsRequestDTO settingsRequest)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(RepositoryConstants.GetSettingsById, new object(), commandType: CommandType.StoredProcedure);
            }
            return new List<GetSettingsResponseDTO>();
        }

        public IEnumerable<GetPeripheralsResponseDTO> GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(RepositoryConstants.GetPeripheralsById, new object(), commandType: CommandType.StoredProcedure);
            }
            return new List<GetPeripheralsResponseDTO>();
        }

        public IEnumerable<GetDataResponseDTO> GetAllData(GetDataRequestDTO settingsRequest)
        {
            return new List<GetDataResponseDTO>();
        }

        public bool UpdatePeripherals(UpdatePeripheralsRequestDTO peripheralsRequest)
        {
            using var con = new SqlConnection(_connectionString);
            con.Open();
            var sql = "EXEC Peripheralinsertupdatedelete '" + peripheralsRequest.Id + "','','','','','','Insert'";
            var getEntityResult = con.Query<GetPeripheralsResponseDTO>(sql, new GetPeripheralsResponseDTO { });
            return true;
        }

        public bool UpdateSettings(UpdateSettingsRequestDTO settingsRequest)
        {
            using var con = new SqlConnection(_connectionString);
            con.Open();
            var sql = "EXEC Peripheralinsertupdatedelete '" + settingsRequest.Id + "','','','','','','Insert'";
            var getEntityResult = con.Query<GetPeripheralsResponseDTO>(sql, new GetPeripheralsResponseDTO { });
            return true;
        }
    }
}
