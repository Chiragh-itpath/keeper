using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keeper.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<ResponseModel<string>> RegisterAsync(RegisterVM register);
        Task<UserModel> GetByEmailAsync(string email);
        Task<ResponseModel<TokenModel>> LoginAsync(LoginVM loginVM);
    }
}
