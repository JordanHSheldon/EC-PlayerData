using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.INFRASTRUCTURE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.DOMAIN
{
    public interface IPlayerOrchestrator
    {
        public List<PlayerDTO> getAllPlayers();
        public PlayerLoginDTO getPlayer(string alias);
        public bool updatePlayer(PlayerDTO player);
        public PlayerDTO AddPlayer(PlayerCreationDTO player);
        public PlayerDTO registerPlayer(PlayerCreationDTO player);
        public bool deletePlayer(string player);
    }
}
