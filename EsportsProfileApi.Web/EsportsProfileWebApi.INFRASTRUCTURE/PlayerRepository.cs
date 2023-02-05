using EsportsProfileWebApi.CROSSCUTTING;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    public class PlayerRepository : IPlayerRepository
    {
        public static List<PlayerDTO> players = new List<PlayerDTO>
        {
            new PlayerDTO{Id=0,Lastname="Sheldon",Firstname="Jordan",Alias="Nadroj"},
            new PlayerDTO{Id=1,Lastname="Sheldon",Firstname="Jordan",Alias="Nadroj"},
            new PlayerDTO{Id=2,Lastname="Sheldon",Firstname="Jordan",Alias="Nadroj"},
            new PlayerDTO{Id=3,Lastname="Sheldon",Firstname="Jordan",Alias="Nadroj"},
            new PlayerDTO{Id=4,Lastname="Sheldon",Firstname="Jordan",Alias="Nadroj"},
            new PlayerDTO{Id=5,Lastname="Sheldon",Firstname="Jordan",Alias="Nadroj"},
        };

        public List<PlayerDTO> getAllPlayers()
        {
            return players;
        }

        public PlayerDTO getPlayer(int playerId)
        {
            return players.Find(x=>x.Id==playerId) ?? new PlayerDTO();
        }

        public PlayerDTO AddPlayer(PlayerDTO player)
        {
            players.Add(player);
            return getPlayer(player.Id);
        }

        public bool updatePlayer(PlayerDTO player)
        {
            return false;
        }

        public bool removePlayer(int id)
        {
            if (getPlayer(id) == null)
            {
                return false;
            }
            players.Remove(getPlayer(id));
            return true;
        }
    }
}
