using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Services.Interfaces;
using Keeper.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /* private readonly IUserService _userService;
         public AccountController(IUserService userService)
         {
             _userService = userService;
         }
         [HttpPost("Register")]
         public async Task<ResponseModel> Register(RegisterVM register)
         {
             ModelState.ClearValidationState(nameof(register));
             if (!ModelState.IsValid)
             {
                 return new ResponseModel
                 {
                     IsSuccess = false,
                     StatusCode = StatusType.NOT_VALID,
                     Data = ModelState.Values.SelectMany(x => x.Errors)
                 };
             }
             return await _userService.RegisterUser(register);
         }
         [HttpPost("Login")]
         public async Task<ResponseModel> Login(string email, string password)
         {
             ResponseModel responseModel = new();                      
             return await _userService.Login(email, password);
         }
     }*/
    }
}
