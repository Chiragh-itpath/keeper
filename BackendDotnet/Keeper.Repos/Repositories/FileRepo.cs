using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Repos.Repositories
{
    public class FileRepo : IFileRepo
    {
        private readonly DbKeeperContext _db;
        public FileRepo(DbKeeperContext db)
        {
            _db = db;
        }
        public async Task<FileModel> AddAsync(FileModel file)
        {
            await _db.AddAsync(file);
            await _db.SaveChangesAsync();
            return file;
        }
        public async Task<List<FileModel>> GetFilesAsync(Guid itemId)
        {
            var query = from file in _db.Files
                        join linker in _db.ItemFileLinker on file.Id equals linker.FileId
                        where linker.ItemId == itemId
                        select file;

            return await query.ToListAsync();
        }
    }
}
