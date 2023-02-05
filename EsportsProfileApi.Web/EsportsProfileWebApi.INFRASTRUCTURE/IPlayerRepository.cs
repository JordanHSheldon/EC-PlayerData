using EsportsProfileWebApi.CROSSCUTTING;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.INFRASTRUCTURE
{
    public interface IPlayerRepository
    {
        public List<PlayerDTO> getAllPlayers();
        public PlayerDTO getPlayer(int playerId);
        public PlayerDTO AddPlayer(PlayerDTO player);
        public bool removePlayer(int id);
        public bool updatePlayer(PlayerDTO player);
    }
}
