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
            new PlayerDTO{Id=0,Lastname="Sheldon",Firstname="Jordan",Alias="Nadroj",Password="password",Email="jordanhsheldon@gmail.com" }
        };

        public List<PlayerDTO> getAllPlayers()
        {
            return players;
        }

        public PlayerDTO getPlayer(string player)
        {
            return players.Find(x => x.Alias.ToLower() == player.ToLower());
        }


        public PlayerDTO AddPlayer(PlayerDTO player)
        {
                players.Add(player);
                return getPlayer(player.Alias);
        }

        public bool updatePlayer(PlayerDTO player)
        {
            return false;
        }

        public PlayerDTO getPlayerByAlias(PlayerDTO player)
        {
            return players.Find(x => x.Alias == player.Alias) ?? new PlayerDTO();
        }

        public bool removePlayer(string player)
        {
            if (getPlayer(player) == null)
            {
                return false;
            }
            players.Remove(getPlayer(player));
            return true;
        }
    }
}
