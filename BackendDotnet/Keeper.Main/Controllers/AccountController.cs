using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


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
        [HttpPost("Register")]
        public async Task<ResponseModel<string>> Register(RegisterVM register)
        {
            return await _userService.RegisterAsync(register);
        }
        [HttpPost("Login")]
        public async Task<ResponseModel<TokenModel>> Login(LoginVM loginVM)
        {
            return await _userService.LoginAsync(loginVM);
        }
    }
}
