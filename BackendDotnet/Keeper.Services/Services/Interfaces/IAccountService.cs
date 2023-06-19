using Keeper.Common.Response;
using Keeper.Common.ViewModels;

namespace Keeper.Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseModel<string>> RegisterAsync(RegisterVM register);
        Task<ResponseModel<TokenModel>> LoginAsync(LoginVM loginVM);
        Task<ResponseModel<OTPModel>> GenerateOTP(string email);
    }
}
