namespace EsportsProfileWebApi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using EsportsProfileWebApi.Web.Responses.User;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpPost]
        [Route("CreateUser")]
        public ActionResult GetDataById()
        {
            return new JsonResult(false);
        }

        [HttpPost]
        [Route("GetUserByName")]
        public ActionResult GetUserByName()
        {
            return new JsonResult(new GetUserDataResponseDto
            {
                FirstName = "Jordan",
                LastName = "Sheldon",
                Email = "Jordansheldon@email.com",
                Username = "Nadroj",
            });
        }

        [HttpPost]
        [Route("UpdateUserByName")]
        public ActionResult UpdateUserByName()
        {
            return new JsonResult(false);
        }
    }
}
