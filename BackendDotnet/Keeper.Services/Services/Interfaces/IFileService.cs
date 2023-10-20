using Keeper.Common.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Keeper.Services.Services.Interfaces
{
    public interface IFileService
    {
        Task AddAsync(Guid UserId, Guid KeepId, Guid ItemId, List<IFormFile> files);
        Task<List<FileViewModel>> GetAllFiles(Guid itemId);
    }
}
