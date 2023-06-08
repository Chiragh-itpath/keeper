using Keeper.Common.ViewModels;
using Keeper.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Keeper.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userService.GetUserByEmail(register.Email);
            if(res != null && res.Id!=Guid.Empty)
            {
                ModelState.AddModelError("errors", "Email already exists");
                return BadRequest(ModelState);
            }
            return Ok(true);                             
        }

    }
}
