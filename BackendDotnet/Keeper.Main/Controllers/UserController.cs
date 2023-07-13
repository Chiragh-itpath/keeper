using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Services.Interfaces;
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
        [HttpGet("{id}")]
        public async Task<ResponseModel<UserVM>> Get(Guid id)
        {
            return await _userService.GetByIdAsync(id);
        }
        [HttpGet("Email/{email}")]
        public async Task<ResponseModel<UserModel>> Get(string email)
        {
            var res=await _userService.GetByEmailAsync(email);
            if(res.Email == null)
            {
                return new ResponseModel<UserModel>()
                {
                    IsSuccess = false,
                    Message="Not exist",
                    StatusName=Common.Enums.StatusType.NOT_FOUND
                };
            }
            return new ResponseModel<UserModel>()
            {
                IsSuccess = true,
                Message = "User data by email",
                StatusName = Common.Enums.StatusType.SUCCESS,
                Data=res
            };
        }
    }
}
