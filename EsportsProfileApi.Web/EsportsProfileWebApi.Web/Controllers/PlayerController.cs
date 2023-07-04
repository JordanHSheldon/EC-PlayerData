
namespace EsportsProfileWebApi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using EsportsProfileWebApi.CROSSCUTTING;
    using EsportsProfileWebApi.DOMAIN.Orchestrators.Players;

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerOrchestrator _playerOrchestrator;

        public PlayerController(IPlayerOrchestrator playerOrchestrator)
        {
            _playerOrchestrator = playerOrchestrator ?? throw new NotImplementedException();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult AddPlayer(PlayerCreationDTO player)
        {
            if (player == null)
            {
                return BadRequest("Player data must be valid");
            }
            return new JsonResult(new PlayerDTO {Alias = player.Alias, Pass = player.Password });
        }

        [HttpPost]
        [Route("GetPlayerByAccountId")]
        public ActionResult GetPlayer(PlayerDTO player)
        {
            if (player!=null && player.Alias != null)
            {
                return new JsonResult(_playerOrchestrator.GetPlayer(player.Alias));
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("GetAllPlayers")]
        public ActionResult GetAllPlayers()
        {
            return new JsonResult(_playerOrchestrator.GetAllPlayers().ToArray());
        }

        [HttpPut]
        [Route("UpdatePlayerById")]
        public ActionResult UpdatePlayer(PlayerDTO player)
        {
            if (player != null)
            {
                return new JsonResult(_playerOrchestrator.UpdatePlayer(player));
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("DeletePlayerById")]
        public ActionResult RemovePlayer(string player)
        {
            if (player != null)
            {
                return new JsonResult(_playerOrchestrator.DeletePlayer(player));
            }
            return BadRequest();
        }   
    }
}
