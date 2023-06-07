
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
        public async Task Insert(UserModel user)
        {
            UserModel userModel = new()
            {
                Id = Guid.NewGuid(),
                Contact = user.Contact,
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName,
            };

            await _userRepo.Insert(userModel);
        }
    }
}
