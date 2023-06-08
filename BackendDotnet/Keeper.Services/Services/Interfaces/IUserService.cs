
using Keeper.Common.ViewModels;
using Keeper.Context.Model;


namespace Keeper.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<bool> RegisterUser(RegisterVM register);
         Task<UserModel> GetUserByEmail(string email);
    }
}
