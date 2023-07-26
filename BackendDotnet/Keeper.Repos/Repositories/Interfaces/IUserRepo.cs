using Keeper.Context.Model;
namespace Keeper.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> GetByEmailAsync(string email);
        Task<UserModel> GetByIdAsync(Guid id);
        Task<bool> UpdateUser(UserModel user);
    }
}
