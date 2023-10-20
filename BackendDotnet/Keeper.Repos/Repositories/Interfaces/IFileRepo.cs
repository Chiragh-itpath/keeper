using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IFileRepo
    {
        Task<FileModel> AddAsync(FileModel file);
        Task<List<FileModel>> GetFilesAsync(Guid itemId);
    }
}
