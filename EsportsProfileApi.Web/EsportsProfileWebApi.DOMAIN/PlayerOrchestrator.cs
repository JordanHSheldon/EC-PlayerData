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

        public PlayerDTO registerPlayer(PlayerCreationDTO player)
        {
            List<PlayerDTO> check = getAllPlayers();
            if (check.Select(x => x).Where(x => x.Alias == player.Alias).Count().Equals(0) && player != null)
            {
                return  _playerRepostirory.AddPlayer(
                    new PlayerDTO() {Id = check.Max(x => x.Id) + 1, Firstname = player.fname, Lastname = player.lname, Alias = player.Alias, Email = player.Email, Password = player.Password });
                
            }
            return null;
        }



        public PlayerDTO AddPlayer(PlayerCreationDTO player)
        {
            return _playerRepostirory.AddPlayer(
                new PlayerDTO()
                {
                    Firstname = player.fname,
                    Lastname = player.lname,
                    Alias = player.Alias,
                    Email = player.Email,
                    Password = player.Password
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

        public PlayerLoginDTO getPlayer(string player)
        {
            var playerLogin = _playerRepostirory.getPlayer(player);
            return new PlayerLoginDTO { Alias = playerLogin.Alias, Password = playerLogin.Password };
        }

        public bool deletePlayer(string player)
        {
            return _playerRepostirory.removePlayer(player);
        }
    }
}
