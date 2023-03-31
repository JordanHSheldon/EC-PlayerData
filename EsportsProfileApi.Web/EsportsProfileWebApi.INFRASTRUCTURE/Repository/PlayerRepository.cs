
namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using Dapper;
    using System.Data.SqlClient;
    using EsportsProfileWebApi.CROSSCUTTING.Responses.Peripherals;
    using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.Settings;
    using EsportsProfileWebApi.INFRASTRUCTURE.Repository;

    public class PlayerRepository : IPlayerRepository
    {

        public static List<PlayerDTO> players = new List<PlayerDTO>
        {
            new PlayerDTO{Id=0,Lastname="Sheldon",Firstname="Jordan",Alias="Nadroj",Pass="password",Email="jordanhsheldon@gmail.com" }
        };

        public List<PlayerDTO> GetAllPlayers()
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Masterinsertupdatedelete 0,'','','','','','Select'";
            var getEntityResult = con.Query<PlayerDTO>(sql, new PlayerDTO {});
            return getEntityResult.ToList();
        }

        public PlayerDTO GetPlayer(string player)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Masterinsertupdatedelete 0,'','','" + player + "','','','SelectDistinct'";
            var getEntityResult = con.Query<PlayerDTO>(sql, new PlayerDTO {});
            return getEntityResult.FirstOrDefault();
        }

        public PlayerDTO LoginPlayer(PlayerDTO player)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Masterinsertupdatedelete 0,'','','"+player+"','','','SelectDistinct'";
            var getEntityResult = con.Query<PlayerDTO>(sql, new PlayerDTO { });
            return getEntityResult.FirstOrDefault();
        }

        public bool AddPlayer(PlayerDTO player)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();
            // maybe make a register player stored proc that inserts into all of these tables if a record if that name doesnt exist
            var sqlPlayer = "EXEC Masterinsertupdatedelete 0,'"+player.Firstname+"','"+ player.Lastname+ "','"+ player.Alias+ "','"+ player.Email+ "','"+player.Pass+ "','Insert'";
            con.Query<PlayerDTO>(sqlPlayer);
            return true;
        }

        public PlayerResponseDTO? RegisterPlayer(PlayerDTO player)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";
            using var con = new SqlConnection(cs);
            con.Open();
            var sqlPlayer = "EXEC RegisterPlayer '" + player.Firstname + "','" + player.Lastname + "','" + player.Alias + "','" + player.Email + "','" + player.Pass + "'";
            var result = con.Query<PlayerDTO>(sqlPlayer);
            return new PlayerResponseDTO { Alias = player.Alias, Password = player.Pass };
        }

        public bool UpdatePlayer(PlayerDTO player)
        {
            return false;
        }

        public PlayerDTO GetPlayerByAlias(PlayerDTO player)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Masterinsertupdatedelete 0,'" + player.Firstname + "','" + player.Lastname + "','" + player.Alias + "','" + player.Email + "','" + player.Pass + "','Insert'";
            var getEntityResult = con.Query<PlayerDTO>(sql, new PlayerDTO { });
            return getEntityResult.FirstOrDefault();
        }

        public bool RemovePlayer(string player)
        {
            if (GetPlayer(player) == null)
            {
                return false;
            }
            players.Remove(GetPlayer(player));
            return true;
        }
    }
}
