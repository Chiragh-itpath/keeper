using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;

namespace Keeper.Services.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepo _repo;
        private readonly IFileService _file;
        public ItemService(IItemRepo itemRepo, IFileService file)
        {
            _repo = itemRepo;
            _file = file;
        }
        public async Task<ResponseModel<List<ItemViewModel>>> GetAllAsync(Guid keepId)
        {
            var data = await _repo.GetAllAsync(keepId);
            var items = data.Select(item => new ItemViewModel
            {
                Id = item.Id,
                Title = item.Title,
                Type = item.Type,
                Number = item.Number,
                URL = item.URL,
                Description = item.Description,
                KeepId = item.KeepId,
                CreatedBy = item.CreatedBy.Email,
                CreatedOn = item.CreatedOn,
                UpdatedOn = item.UpdatedOn,
                UpdatedBy = item.UpdatedBy?.Email,
                To = item.To,
                DiscussedBy = item.DiscussedBy,
            }).ToList();
            return new ResponseModel<List<ItemViewModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = items
            };
        }
        public async Task<ResponseModel<ItemViewModel>> GetAsync(Guid id)
        {
            var data = await _repo.GetAsync(id);
            if (data == null)
            {
                return new ResponseModel<ItemViewModel>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = "Not Found",
                };
            }
            var res = await _file.GetAllFiles(data.Id);

            var item = new ItemViewModel()
            {
                Id = data.Id,
                Title = data.Title,
                Type = data.Type,
                Number = data.Number,
                URL = data.URL,
                Description = data.Description,
                CreatedBy = data.CreatedBy.Email,
                CreatedOn = data.CreatedOn,
                UpdatedOn = data.UpdatedOn,
                UpdatedBy = data.UpdatedBy?.Email,
                To = data.To,
                DiscussedBy = data.DiscussedBy,
                Files = res
            };
            return new ResponseModel<ItemViewModel>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = item
            };
        }
        public async Task<ResponseModel<ItemViewModel>> SaveAsync(AddItem addItem, Guid userId)
        {
            ItemModel item = new()
            {
                Title = addItem.Title,
                Description = addItem.Description,
                Type = addItem.Type,
                URL = addItem.URL,
                Number = addItem.Number,
                KeepId = addItem.KeepId,
                CreatedById = userId,
                CreatedOn = DateTime.Now,
                To = addItem.To,
                DiscussedBy = addItem.DiscussedBy,
            };
            var itemId = await _repo.SaveAsync(item);
            if (addItem.Files != null)
            {
                await _file.AddAsync(userId, item.KeepId, itemId, addItem.Files);
            }
            var res = await GetAsync(itemId);
            res.Message = "Item Added";
            return res;
        }
        public async Task<ResponseModel<ItemViewModel>> UpdateAsync(EditItem editItem, Guid userId)
        {
            var res = await _repo.GetAsync(editItem.Id);
            if (res == null)
            {
                return new ResponseModel<ItemViewModel>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = "Item Not Found",
                };
            }
            res.Title = editItem.Title;
            res.Description = editItem.Description;
            res.Type = editItem.Type;
            res.URL = editItem.URL;
            res.Number = editItem.Number;
            res.To = editItem.To;
            res.DiscussedBy = editItem.DiscussedBy;
            res.UpdatedById = userId;
            res.UpdatedOn = DateTime.Now;
            var itemId = await _repo.Update(res);
            if (editItem.Files != null)
            {
                await _file.AddAsync(res.CreatedById, res.KeepId, res.Id, editItem.Files);
            }
            var response = await GetAsync(itemId);
            response.Message = "Item Updated";
            return response;
        }
        public async Task<ResponseModel<string>> DeleteAsync(Guid id)
        {
            var res = await _repo.GetAsync(id);
            if (res == null)
            {
                return new ResponseModel<string>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = "Item Not Found",
                };
            }
            await _repo.Delete(res);
            return new ResponseModel<string>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "Item Deleted",
                Data = id.ToString()
            };
        }
    }
}
