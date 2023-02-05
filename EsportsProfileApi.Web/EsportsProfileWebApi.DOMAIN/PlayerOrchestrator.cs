using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.INFRASTRUCTURE;
namespace EsportsProfileWebApi.DOMAIN
{
    public class PlayerOrchestrator :IPlayerOrchestrator
    {
        private IPlayerRepository _playerRepostirory;

        public PlayerOrchestrator(IPlayerRepository playerRepository)
        {
            _playerRepostirory = playerRepository ?? throw new NotImplementedException();
        }

        public PlayerDTO AddPlayer(PlayerCreationDTO player)
        {
            return _playerRepostirory.AddPlayer(
                new PlayerDTO()
                {
                    Firstname= player.Firstname,
                    Lastname= player.Lastname,
                    Alias= player.Alias,
                }
                );
        }

        public bool updatePlayer(PlayerDTO player)
        {
            return _playerRepostirory.updatePlayer(player);
        }

        public List<PlayerDTO> getAllPlayers()
        {
            return _playerRepostirory.getAllPlayers();
        }

        public PlayerDTO getPlayer(int playerId)
        {
            return _playerRepostirory.getPlayer(playerId);
        }

        public bool deletePlayer(int id)
        {
            return _playerRepostirory.removePlayer(id);
        }
    }
}
