using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Services.Interfaces;
using Keeper.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.ModelBinding;
using KeeperCore.Services;
using Microsoft.Win32;

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
            return await _userService.RegisterUser(register);

        }
        [HttpPost("Login")]
        public async Task<ResponseModel<string>> Login(string email, string password)
        {
            ResponseModel<string> responseModel = new();                      
            return await _userService.Login(email, password);
        }
        [HttpPost("test")]
        public string test(string str)
        {
            return str;
        }
    }
}
