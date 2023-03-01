using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EsportsProfileWebApi.DOMAIN;
using EsportsProfileWebApi.CROSSCUTTING;
using EsportsProfileWebApi.INFRASTRUCTURE;

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
        [Route("Register")]
        public ActionResult RegisterPlayer(PlayerCreationDTO player)
        {
            if (player == null)
            {
                return BadRequest("Player data must be valid");
            }
            return new JsonResult(_playerOrchestrator.registerPlayer(player));
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
        public ActionResult GetPlayer(PlayerLoginDTO player)
        {
            if (player!=null)
            {
                var x = _playerOrchestrator.getPlayer(player.Alias);
                return new JsonResult(x);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("GetAll")]
        public ActionResult GetAllPlayers()
        {
            return new JsonResult(_playerOrchestrator.getAllPlayers().ToArray());
        }
        
        [HttpPost]
        [Route("Delete")]
        public ActionResult RemovePlayer(string player)
        {
            if (player != null)
            {
                return new JsonResult(_playerOrchestrator.deletePlayer(player));
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult UpdatePlayer(PlayerDTO player)
        {
            if (player != null)
            {
                return new JsonResult(_playerOrchestrator.updatePlayer(player));
            }
            return BadRequest();
        }
    }
}
