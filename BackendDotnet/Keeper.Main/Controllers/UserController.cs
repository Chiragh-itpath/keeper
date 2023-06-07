using Keeper.Context.Model;
using Keeper.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(await _userService.GetAllUsers());
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserModel user)
        {
            var res = new UserModel()
            {
                Id = Guid.NewGuid(),
                UserName = user.UserName,
                Email = user.Email,
                Contact = user.Contact,
                Password = user.Password,
                CreatedOn = DateTime.Now,
            };
            await _userService.Insert(user);
            return Ok(res);
        }
    }
}
