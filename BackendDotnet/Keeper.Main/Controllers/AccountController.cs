using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Register")]
        public async Task<ResponseModel<string>> Register(RegisterModel register)
        {
            return await _accountService.RegisterAsync(register);
        }
        [HttpPost("Login")]
        public async Task<ResponseModel<TokenModel>> Login(LoginModel loginVM)
        {
            return await _accountService.LoginAsync(loginVM);
        }
        [HttpGet("otp")]
        public async Task<ResponseModel<string>> GetOTP(string email)
        {
            return await _accountService.GetOTP(email);
        }
        [HttpPut("ResetPassword")]
        public async Task<ResponseModel<string>> ResetPassword(PasswordResetModel resetModel)
        {
            return await _accountService.UpdatePasswordAsync(resetModel);
        }
    }
}
