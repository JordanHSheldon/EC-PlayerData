namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    using Microsoft.Data.SqlClient;
    using Dapper;
    using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;

    public class DataRepository : IDataRepository
    {
        private static string _connectionString = string.Empty;
        List<GetDataResponse> data = new List<GetDataResponse>()
        {
            new GetDataResponse() {
                Dpi = 800,
                Sensitivity = 1,
                ResolutionX = 1920,
                ResolutionY = 1080,
                ResolutionType = "Native",
                Monitor = "Benq",
                Mouse = "Gprowireless",
                MousePad = "Aqua Control PLus",
                KeyBoard = "Wooting 60HE",
                HeadSet = "SteelSeries Arctis Nova Pro",
                Username = "NADROJ"
            }
        };

        public DataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();
        }

        public IEnumerable<GetDataResponse> GetAllData(GetDataRequest dataRequest)
        {
            throw new NotImplementedException();
        }

        public bool UpdateData(UpdateDataRequest request)
        {
            data[0] = new GetDataResponse
            { 
                Username = "NADROJ"
            };
            return true;
        }

        public GetDataResponse GetData(GetDataRequest dataRequest)
        {
            return data.FirstOrDefault(x => x.Username == dataRequest.Alias)!;
        }
    }
}
