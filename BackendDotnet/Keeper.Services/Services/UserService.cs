
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
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

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var res = await _userRepo.GetAllUsers();
            return res;
        }
        public async Task<bool> RegisterUser(RegisterVM register)
        {
            UserModel userModel = new()
            {
                Id = Guid.NewGuid(),
                UserName = register.UserName,
                Email = register.Email,
                Password=register.Password,
                Contact=register.Contact,
                CreatedOn = register.CreatedOn,
                UpdateOn = null
            };
            await _userRepo.Register(userModel);
            return true;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await  _userRepo.GetUserByEmail(email);
        }
    }
}
