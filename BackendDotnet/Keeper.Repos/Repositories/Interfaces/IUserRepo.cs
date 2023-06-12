using Keeper.Context.Model;
namespace Keeper.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<bool> Register(UserModel user);
        Task<UserModel> GetUserByEmail(string email);       
    }
}
