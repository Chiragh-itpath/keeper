using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;

        public UserController(IUserService userService)
        {
            _user = userService;
        }

        [HttpGet("Me")]
        public async Task<ResponseModel<UserViewModel>> Me()
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _user.GetByIdAsync(userId);
        }

        [AllowAnonymous]
        [HttpGet("CheckMail")]
        public async Task<ResponseModel<UserViewModel>> CheckEmail(string email)
        {
            return await _user.CheckEmail(email);
        }
    }
}
