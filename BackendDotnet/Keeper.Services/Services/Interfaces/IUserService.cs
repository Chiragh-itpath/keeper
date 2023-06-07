
using Keeper.Context.Model;


namespace Keeper.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task Insert(UserModel user);
    }
}
