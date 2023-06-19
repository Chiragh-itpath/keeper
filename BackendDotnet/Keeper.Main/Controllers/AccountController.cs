using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Services.Interfaces;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace Keeper.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {  
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService= accountService;
        }
        [HttpPost("Register")]
        public async Task<ResponseModel<string>> Register(RegisterVM register)
        {
            return await _accountService.RegisterAsync(register);
        }
        [HttpPost("Login")]
        public async Task<ResponseModel<TokenModel>> Login(LoginVM loginVM)
        {
            return await _accountService.LoginAsync(loginVM);
        }
        [HttpPost("GenerateOTP")]
        public async Task<ResponseModel<OTPModel>> GenerateOTP(OTPModel oTPModel)
        {
            return await _accountService.GenerateOTP(oTPModel.Email);
        }
        [HttpPost("ChangePassword")]
        public async Task<ResponseModel<string>> ChangePassword(LoginVM loginVM)
        {
            return await _accountService.UpdatePasswordAsync(loginVM);
        }
    }
}
