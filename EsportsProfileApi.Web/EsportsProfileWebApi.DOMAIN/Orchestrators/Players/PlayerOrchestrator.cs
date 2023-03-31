
namespace EsportsProfileWebApi.DOMAIN
{
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.PlayerDTOs;
    using EsportsProfileWebApi.DOMAIN.Orchestrators.Players;
    using EsportsProfileWebApi.INFRASTRUCTURE.Repository;

    public class PlayerOrchestrator :IPlayerOrchestrator
    {
        private readonly IPlayerRepository _playerRepostirory;

        public PlayerOrchestrator(IPlayerRepository playerRepository)
        {
            _playerRepostirory = playerRepository ?? throw new NotImplementedException();
        }

        public PlayerResponseDTO? RegisterPlayer(PlayerCreationDTO player)
        {

            // fix
            List<PlayerDTO> check = GetAllPlayers();
            return _playerRepostirory.RegisterPlayer(
                    new PlayerDTO() {
                        Firstname = player.fname,
                        Lastname = player.lname,
                        Alias = player.Alias,
                        Email = player.Email,
                        Pass = player.Password 
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
                    Pass = player.Password
                }
                );
        }

        public bool UpdatePlayer(PlayerDTO player)
        {
            return _playerRepostirory.UpdatePlayer(player);
        }

        public List<PlayerDTO> GetAllPlayers()
        {
            return _playerRepostirory.GetAllPlayers();
        }

        public PlayerDTO GetPlayer(string player)
        {
            return _playerRepostirory.GetPlayer(player);
        }

        public PlayerLoginRequestDTO? LoginPlayer(PlayerLoginRequestDTO player)
        {
            var playerLogin = _playerRepostirory.GetPlayer(player.Alias);
            if (playerLogin != null && (playerLogin.Pass ==  player.Password))
            {
                return player;
            }
            else
            {
                return null;
            }
        }

        public bool DeletePlayer(string player)
        {
            return _playerRepostirory.RemovePlayer(player);
        }
    }
}
