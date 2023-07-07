using Dapper;
using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;

namespace Keeper.Repos.Repositories
{
    public class TagRepo : ITagRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        private readonly IConfiguration _configuration;
        public TagRepo(DbKeeperContext dbKeeperContext, IConfiguration configuration)
        {
            _dbKeeperContext = dbKeeperContext;
            _configuration = configuration;
        }


        public async Task<IEnumerable<TagModel>> GetAllAsync()
        {
            return await _dbKeeperContext.Tags.ToListAsync();
        }

        public async Task<TagModel> GetByIdAsync(Guid Id)
        {
            return await _dbKeeperContext.Tags.FindAsync(Id);
        }

        public async Task<IEnumerable<TagModel>> GetByTypeAsync(TagType type)
        {
            return await _dbKeeperContext.Tags.Where(t => t.Type == type).ToListAsync();
        }
        public async Task<TagModel> GetByTitleAsync(string title)
        {
            return await _dbKeeperContext.Tags.FirstOrDefaultAsync(t => t.Title == title);
        }

        public async Task<TagModel> SaveAsync(TagModel tag)
        {
            await _dbKeeperContext.Tags.AddAsync(tag);
            if (await _dbKeeperContext.SaveChangesAsync() > 0)
                return tag;
            return null;
        }
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var res = await _dbKeeperContext.Tags.FindAsync(id);
            if (res != null)
            {
                _dbKeeperContext.Tags.Remove(res);
                _dbKeeperContext.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<TagModel>> GetByUserAsync(Guid userid, TagType tagType)
        {
            using (var con = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {

                try
                {
                    string qry = $"select distinct  t.* from Tags as t inner join projects as p on t.Id=p.TagId where p.CreatedBy=@uid and p.IsDeleted='False'";
                    if (tagType == TagType.KEEP)
                        qry = $"select distinct  t.* from Tags as t inner join Keeps as p on t.Id=p.TagId where p.CreatedBy=@uid and p.IsDeleted='False' and ";
                    var res = await con.QueryAsync<TagModel>(qry, new { uid = userid });
                    return res;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }
    }
}
