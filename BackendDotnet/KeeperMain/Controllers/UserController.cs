using Keeper.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok();
        }

    }
}
