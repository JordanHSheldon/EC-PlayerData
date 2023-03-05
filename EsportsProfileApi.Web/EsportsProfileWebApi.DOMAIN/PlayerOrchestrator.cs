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

        public bool RegisterPlayer(PlayerCreationDTO player)
        {
            List<PlayerDTO> check = GetAllPlayers();
           
            return _playerRepostirory.AddPlayer(
                    new PlayerDTO() {
                        Id = check.Max(x => x.Id) + 1,
                        Firstname = player.fname,
                        Lastname = player.lname,
                        Alias = player.Alias,
                        Email = player.Email,
                        Password = player.Password 
                    });
        }

        public bool AddPlayer(PlayerCreationDTO player)
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

        public bool UpdatePlayer(PlayerDTO player)
        {
            return _playerRepostirory.UpdatePlayer(player);
        }

        public List<PlayerDTO> GetAllPlayers()
        {
            return _playerRepostirory.getAllPlayers();
        }

        public PlayerDTO GetPlayer(string player)
        {
            return _playerRepostirory.GetPlayer(player);
        }

        public PlayerLoginDTO LoginPlayer(PlayerLoginDTO player)
        {
            var playerLogin = _playerRepostirory.GetPlayer(player.Alias);
            return new PlayerLoginDTO { Alias = playerLogin.Alias, Password = playerLogin.Password };
        }

        public bool DeletePlayer(string player)
        {
            return _playerRepostirory.RemovePlayer(player);
        }
    }
}
