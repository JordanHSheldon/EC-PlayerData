using EsportsProfileWebApi.CROSSCUTTING;
//using RestSharp;
using Dapper;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    public class PlayerRepository : IPlayerRepository
    {
        private static readonly HttpClient client = new HttpClient();

        public static List<PlayerDTO> players = new List<PlayerDTO>
        {
            new PlayerDTO{Id=0,Lastname="Sheldon",Firstname="Jordan",Alias="Nadroj",Password="password",Email="jordanhsheldon@gmail.com" }
        };

        public List<PlayerDTO> getAllPlayers()
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

            var sql = "EXEC Masterinsertupdatedelete 0,'','','','','','Select'";
            var getEntityResult = con.Query<PlayerDTO>(sql, new PlayerDTO { });
            return getEntityResult.FirstOrDefault();
        }

        public PlayerDTO LoginPlayer(PlayerDTO player)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Masterinsertupdatedelete 0,'','','','','','Select'";
            var getEntityResult = con.Query<PlayerDTO>(sql, new PlayerDTO { });
            return getEntityResult.FirstOrDefault();
        }

        public bool AddPlayer(PlayerDTO player)
        {
            var cs = @"Data Source=JORDAN;Initial Catalog=EsportsCompare;Integrated Security=True";

            using var con = new SqlConnection(cs);
            con.Open();

            var sql = "EXEC Masterinsertupdatedelete 0,'"+player.Firstname+"','"+ player.Lastname+ "','"+ player.Alias+ "','"+ player.Email+ "','"+player.Password+ "','Insert'";
            var getEntityResult = con.Query<PlayerDTO>(sql, new PlayerDTO { });

            return true;
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

            var sql = "EXEC Masterinsertupdatedelete 0,'" + player.Firstname + "','" + player.Lastname + "','" + player.Alias + "','" + player.Email + "','" + player.Password + "','Insert'";
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
