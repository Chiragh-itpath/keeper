using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;

namespace Keeper.Repos.Repositories
{
    public class FileRepo : IFileRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        public FileRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }
        public async Task<Guid> UploadAsync(FileModel file)
        {
            await _dbKeeperContext.Files.AddAsync(file);
            if(await _dbKeeperContext.SaveChangesAsync() != 1)
            {
                return Guid.Empty;
            }
            return _dbKeeperContext.Files.OrderByDescending(f => f.Id).Single()!.Id;
        }
    }
}
