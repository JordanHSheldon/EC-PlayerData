using Microsoft.AspNetCore.Mvc;
using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.PlayerDTOs;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Players;

namespace EsportsProfileWebApi.Web.Controllers
{
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
            return new JsonResult(_playerOrchestrator.AddPlayer(player));
        }

        [HttpPost]
        [Route("Get")]
        public ActionResult GetPlayer(PlayerDTO player)
        {
            if (player!=null)
            {
                return new JsonResult(_playerOrchestrator.GetPlayer(player.Alias));
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult LoginPlayer(PlayerLoginRequestDTO player)
        {
            if (player != null)
            {
                return new JsonResult(_playerOrchestrator.LoginPlayer(player));
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("GetAll")]
        public ActionResult GetAllPlayers()
        {
            return new JsonResult(_playerOrchestrator.GetAllPlayers().ToArray());
        }
        
        [HttpPost]
        [Route("Delete")]
        public ActionResult RemovePlayer(string player)
        {
            if (player != null)
            {
                return new JsonResult(_playerOrchestrator.DeletePlayer(player));
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult UpdatePlayer(PlayerDTO player)
        {
            if (player != null)
            {
                return new JsonResult(_playerOrchestrator.UpdatePlayer(player));
            }
            return BadRequest();
        }
    }
}
