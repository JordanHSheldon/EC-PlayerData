
namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    using Dapper;
    using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.PeripheralDTOs;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
    using System.Data.SqlClient;
    public class PeripheralsRepository : IPeripheralsRepository
    {
        public PeripheralsResponseDTO getAllPeripheralsForPlayer(PeripheralsRequestDTO peripheralsRequest)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Peripheralinsertupdatedelete '" +peripheralsRequest.Alias+ "','','','','','','Select'";
            var getEntityResult = con.Query<PeripheralsResponseDTO>(sql, new PeripheralsResponseDTO { });
            return getEntityResult.FirstOrDefault();
        }
    }
}
