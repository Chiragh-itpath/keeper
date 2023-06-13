using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Keeper.Repos.Repositories
{
    public class TagRepo : ITagRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        public TagRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }

        ResponseModel GetResponse(StatusType eResponse, string message, bool isSuccess, object? data = null, object? metadata = null)
        {
            return new ResponseModel()
            {
                StatusCode = eResponse,
                Message = message,
                IsSuccess = isSuccess,
                Data = data,
                MetaData = metadata
            };
        }
        public async Task<ResponseModel> Get()
        {
            var res = await _dbKeeperContext.Tags.ToListAsync();
            ResponseModel response;
            if (res.Count > 0)
                response = GetResponse(StatusType.OK, "Tag Data", true, res);
            else
                response = GetResponse(StatusType.NOT_FOUND, "Tag Data not found", false);
            return response;
        }

        public async Task<ResponseModel> Get(Guid Id)
        {
            var res = await _dbKeeperContext.Tags.FindAsync(Id);
            ResponseModel response;
            if (res != null)
                response = GetResponse(StatusType.OK, "Tag Data", true, res);
            else
                response = GetResponse(StatusType.NOT_FOUND, "Tag Data not found", false);
            return response;
        }
        
        public async Task<ResponseModel> Get(TagType type)
        {
            var res = await _dbKeeperContext.Tags.Where(t=>t.Type==type).ToListAsync();
            ResponseModel response;
            if (res.Count > 0)
                response = GetResponse(StatusType.OK, "Tag Data", true, res);
            else
                response = GetResponse(StatusType.NOT_FOUND, "Tag Data not found", false);
            return response;
        }
        public async Task<ResponseModel> Get(string title)
        {
            var res = await _dbKeeperContext.Tags.Where(t=>t.Title== title).ToListAsync();
            ResponseModel response;
            if (res.Count > 0)
                response = GetResponse(StatusType.OK, "Tag Data", true, res);
            else
                response = GetResponse(StatusType.NOT_FOUND, "Tag Data not found", false);
            return response;
        }

        public async Task<ResponseModel> Post(TagModel tag)
        {
            await _dbKeeperContext.Tags.AddAsync(tag);
            if(await _dbKeeperContext.SaveChangesAsync()>0)
                return GetResponse(StatusType.OK, "Record Inserted", true,tag);

            return GetResponse(StatusType.NOT_VALID, "Something Wrong", false);
        }
        public async Task<ResponseModel> Delete(Guid id)
        {
            var res=await _dbKeeperContext.Tags.FindAsync(id);
            if (res != null)
            {
                _dbKeeperContext.Tags.Remove(res);
                _dbKeeperContext.SaveChanges();
                return GetResponse(StatusType.OK, "Record Deleted", true, res);
            }

            return GetResponse(StatusType.NOT_VALID, "Something Wrong", false);
        }
    }
}
