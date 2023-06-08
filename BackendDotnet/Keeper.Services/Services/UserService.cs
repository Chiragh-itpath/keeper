
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
                Password = register.Password,
                Contact = register.Contact,
                CreatedOn = register.CreatedOn,
                UpdateOn = null
            };
            try
            {               
                register.Password = BCrypt.Net.BCrypt.HashPassword(register.Password);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync((string?)ex.Message);
            }
            return await _userRepo.Register(userModel);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _userRepo.GetUserByEmail(email);
        }

        public async Task<bool> Login(UserModel user)
        {
            var res = await _userRepo.GetUserByEmail(user.Email);
            if (res != null)
            {
                return BCrypt.Net.BCrypt.Verify(user.Password, res.Password);
            }
            return false;
        }
    }
}
