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
        public PlayerDTO GetPlayer(string player);
        public bool AddPlayer(PlayerDTO player);
        public bool RemovePlayer(string player);
        public bool UpdatePlayer(PlayerDTO player);

    }
}
