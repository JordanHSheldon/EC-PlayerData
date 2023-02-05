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
        [Route("Add")]
        public ActionResult AddPlayer(PlayerCreationDTO player)
        {
            return new JsonResult(_playerOrchestrator.AddPlayer(player));
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult GetPlayer(Intincoming incomingid)
        {

            int id = incomingid.Id;
            if (id > 0)
            {

                return new JsonResult(_playerOrchestrator.getPlayer(id));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAllPlayers()
        {
            return new JsonResult(_playerOrchestrator.getAllPlayers().ToArray());
        }
        
        [HttpPost]
        [Route("Delete")]
        public ActionResult RemovePlayer(Intincoming incomingid)
        {
            int id = incomingid.Id;
            if (id != null && id > 0)
            {
                return new JsonResult(_playerOrchestrator.deletePlayer(id));
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
