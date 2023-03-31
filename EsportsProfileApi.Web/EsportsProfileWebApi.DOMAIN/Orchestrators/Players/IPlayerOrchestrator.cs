using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.PlayerDTOs;
using EsportsProfileWebApi.INFRASTRUCTURE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.DOMAIN.Orchestrators.Players
{
    public interface IPlayerOrchestrator
    {
        public List<PlayerDTO> GetAllPlayers();
        public PlayerResponseDTO? RegisterPlayer(PlayerCreationDTO player);
        public PlayerDTO GetPlayer(string alias);
        public PlayerLoginRequestDTO? LoginPlayer(PlayerLoginRequestDTO player);
        public bool UpdatePlayer(PlayerDTO player);
        public bool AddPlayer(PlayerCreationDTO player);
        public bool DeletePlayer(string player);
    }
}
