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
        public List<PlayerDTO> GetAllPlayers();
        public bool RegisterPlayer(PlayerCreationDTO player);
        public PlayerDTO GetPlayer(string alias);
        public PlayerLoginDTO? LoginPlayer(PlayerLoginDTO player);
        public bool UpdatePlayer(PlayerDTO player);
        public bool AddPlayer(PlayerCreationDTO player);
        public bool DeletePlayer(string player);
    }
}
