using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IFileRepo
    {
        Task<Guid> UploadAsync(FileModel file);
    }
}
