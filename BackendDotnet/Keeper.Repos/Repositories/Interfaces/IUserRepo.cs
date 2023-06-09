using Keeper.Context.Model;

namespace Keeper.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task Insert(UserModel user);
    }
}
