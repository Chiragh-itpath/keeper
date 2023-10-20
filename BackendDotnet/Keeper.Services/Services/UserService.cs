using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Repos.Interfaces;
using Keeper.Services.Interfaces;

namespace KeeperCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<ResponseModel<UserViewModel>> CheckEmail(string email)
        {
            var res = await _userRepo.GetByEmailAsync(email);
            if (res == null)
            {
                return new ResponseModel<UserViewModel>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = ""
                };
            }
            UserViewModel user = new()
            {
                Id = res.Id,
                UserName = res.UserName,
                Email = res.Email,
                Contact = res.Contact
            };
            return new ResponseModel<UserViewModel>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = user
            };
        }
        public async Task<ResponseModel<UserViewModel>> GetByIdAsync(Guid id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
            {
                return new ResponseModel<UserViewModel>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = true,
                    Message = "No User found with this id",
                };
            }
            var UserViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Contact = user.Contact,
            };
            return new ResponseModel<UserViewModel>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = UserViewModel
            };
        }
    }
}
