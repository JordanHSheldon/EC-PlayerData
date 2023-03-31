using EsportsProfileWebApi.CROSSCUTTING;
using System;

namespace EsportsProfileWebApi.INFRASTRUCTURE.Repository
{
    public interface IPlayerRepository
    {
        public List<PlayerDTO> GetAllPlayers();
        public PlayerDTO GetPlayer(string player);
        public bool AddPlayer(PlayerDTO player);
        public bool RemovePlayer(string player);
        public bool UpdatePlayer(PlayerDTO player);
        public PlayerResponseDTO? RegisterPlayer(PlayerDTO player);

    }
}
