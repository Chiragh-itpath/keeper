using Keeper.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Route("[api/controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            var res = await _userService.GetAllUsers();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok();
        }

    }
}
