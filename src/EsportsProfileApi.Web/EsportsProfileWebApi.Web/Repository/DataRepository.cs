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
        public GetDataResponse GetData(GetDataRequestDTO dataRequest)
        {
            var data = new GetDataResponse()
            {
                Dpi = 800,
                Sensitivity = 1,
                ResolutionX = 1920,
                ResolutionY = 1080,
                ResolutionType = "Native",
                Monitor = "Benq",
                Mouse = "Gprowireless",
                MousePad = "Aqua Control PLus",
                KeyBoard = "Wooting 60HE",
                HeadSet = "SteelSeries Arctis Nova Pro"
            };
            return data;
        }

        public GetSettingsResponse GetSettings(GetSettingsRequestDTO settingsRequest)
        {
            using var con = new SqlConnection(_connectionString);
            con.Open();
            var sql = "EXEC Settingsinsertupdatedelete '" + settingsRequest.Id + "',0.0,'','','','','SelectDistinct'";
            var getEntityResult = con.Query<GetSettingsResponse>(sql, new GetSettingsResponse { });
            return getEntityResult.First();
        }
        
        public GetPeripheralsResponse GetPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            using var con = new SqlConnection(_connectionString);
            con.Open();

            var sql = "EXEC Peripheralinsertupdatedelete '" + peripheralsRequest.Id + "','','','','','','SelectDistinct'";
            var getEntityResult = con.Query<GetPeripheralsResponse>(sql, new GetPeripheralsResponse { });
            return getEntityResult.First();
        }

        public IEnumerable<GetSettingsResponse> GetAllSettings(GetSettingsRequestDTO settingsRequest)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(RepositoryConstants.GetSettingsById, new object(), commandType: CommandType.StoredProcedure);
            }
            return new List<GetSettingsResponse>();
        }

        public IEnumerable<GetPeripheralsResponse> GetAllPeripherals(GetPeripheralsRequestDTO peripheralsRequest)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(RepositoryConstants.GetPeripheralsById, new object(), commandType: CommandType.StoredProcedure);
            }
            return new List<GetPeripheralsResponse>();
        }

        public IEnumerable<GetDataResponse> GetAllData(GetDataRequestDTO settingsRequest)
        {
            return new List<GetDataResponse>();
        }

        public bool UpdatePeripherals(UpdatePeripheralsRequestDTO peripheralsRequest)
        {
            using var con = new SqlConnection(_connectionString);
            con.Open();
            var sql = "EXEC Peripheralinsertupdatedelete '" + peripheralsRequest.Id + "','','','','','','Insert'";
            var getEntityResult = con.Query<GetPeripheralsResponse>(sql, new GetPeripheralsResponse { });
            return true;
        }

        public bool UpdateSettings(UpdateSettingsRequestDTO settingsRequest)
        {
            using var con = new SqlConnection(_connectionString);
            con.Open();
            var sql = "EXEC Peripheralinsertupdatedelete '" + settingsRequest.Id + "','','','','','','Insert'";
            var getEntityResult = con.Query<GetPeripheralsResponse>(sql, new GetPeripheralsResponse { });
            return true;
        }
    }
}
