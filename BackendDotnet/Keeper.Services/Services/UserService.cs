using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace KeeperCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepo userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var res = await _userRepo.GetAllAsync();
            return res;
        }
        public async Task<UserModel> GetByEmailAsync(string email)
        {
            return await _userRepo.GetByEmailAsync(email);
        }
        public async Task<ResponseModel<UserVM>> GetByIdAsync(Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user.Id == Guid.Empty)
            {
                return new ResponseModel<UserVM>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = true,
                    Message = "No User found with this id",
                };
            }
            var userVm = new UserVM()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Contact = user.Contact,
            };
            return new ResponseModel<UserVM>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "User Found",
                Data = userVm
            };
        }


    }
}
