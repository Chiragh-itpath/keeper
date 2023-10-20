using Keeper.Context.Model;
namespace Keeper.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel?> GetByEmailAsync(string email);
        Task<UserModel?> GetById(Guid userId);
        bool UpdateUser(UserModel user);
        Task<List<UserModel>> GetEmailList(string email);
    }
}
