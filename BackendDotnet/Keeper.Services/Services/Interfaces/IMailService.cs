using Keeper.Common.OtherModels;

namespace Keeper.Services.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailModel mail);
    }
}
