using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Keeper.Services.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepo _itemRepo;
        private readonly IWebHostEnvironment _env;
        public ItemService(IItemRepo itemRepo, IWebHostEnvironment env)
        {
            _itemRepo = itemRepo;
            _env = env;

        }

        public async Task<ResponseModel<ItemModel>> GetByIdAsync(Guid id)
        {
            var item = await _itemRepo.GetByIdAsync(id);
            if(item.Id == Guid.Empty)
                return new ResponseModel<ItemModel>
                {
                    IsSuccess = true,
                    StatusName = StatusType.NOT_FOUND,
                    Message = "Not Found"
                };
            return new ResponseModel<ItemModel>
            {
                IsSuccess = true,
                StatusName = StatusType.SUCCESS,
                Data = item
            };

        }

        public async Task<ResponseModel<string>> DeleteAsync(Guid id)
        {
            ItemModel item = await _itemRepo.GetByIdAsync(id);
            item.IsDeleted = true;
            await _itemRepo.DeleteAsync(item);
            return new ResponseModel<string>
            {
                IsSuccess = true,
                StatusName = StatusType.SUCCESS,
                Message = "deleted"
            };
        }

        public async Task<ResponseModel<string>> SaveAsync(ItemVM itemVM)
        {
            ItemModel item = new()
            {
                Title = itemVM.Title,
                Description = itemVM.Description,
                URL = itemVM.URL,
                Type = itemVM.Type,
                Number = itemVM.Number,
                To = itemVM.To,
                DiscussedBy = itemVM.DiscussedBy,
                KeepId = itemVM.KeepId,
                CreatedBy = itemVM.CreatedBy,
                CreatedOn = DateTime.Now,
                TagId = itemVM.TagId,
                Files = new List<FileModel>()
            };
            string wwwroot = _env.WebRootPath;
            string UserDirecotry = Path.Combine(wwwroot, itemVM.CreatedBy.ToString());
            if (!Directory.Exists(UserDirecotry))
                Directory.CreateDirectory(UserDirecotry);
            string ProjectDirecotry = Path.Combine(UserDirecotry, itemVM.ProjectId.ToString());
            if (!Directory.Exists(ProjectDirecotry))
                Directory.CreateDirectory(ProjectDirecotry);
            List<FileModel> files = new();

            itemVM.Files?.ForEach(file =>
            {
                string FileName = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString() + Path.GetExtension(file.FileName);
                string FilePath = Path.Combine(UserDirecotry, FileName);
                using var stream = new FileStream(FilePath, FileMode.Create);
                file.CopyTo(stream);
                FileModel filemodel = new()
                {
                    FilePath = Path.Combine(itemVM.CreatedBy.ToString(), itemVM.ProjectId.ToString(), FileName),
                    Items = new List<ItemModel>()
                };
                files.Add(filemodel);
            });


            await _itemRepo.SaveAsync(item, files);
            return new ResponseModel<string>
            {
                IsSuccess = true,
                StatusName = StatusType.SUCCESS,
                Message = "inserted"
            };
        }
        public async Task<ResponseModel<string>> UpdateAsync(ItemVM itemVM)
        {
            ItemModel existingItem = await _itemRepo.GetByIdAsync(itemVM.Id);
            if (existingItem.Id == Guid.Empty)
                return new ResponseModel<string>
                {
                    IsSuccess = true,
                    StatusName = StatusType.NOT_FOUND,
                    Message = "Not Found"

                };
            existingItem.Title = itemVM.Title;
            existingItem.Description = itemVM.Description;
            existingItem.URL = itemVM.URL;
            existingItem.Type = itemVM.Type;
            existingItem.Number = itemVM.Number;
            existingItem.To = itemVM.To;
            existingItem.DiscussedBy = itemVM.DiscussedBy;
            existingItem.UpdatedBy = itemVM.UpdatedBy;
            existingItem.UpdatedOn = DateTime.Now;
            string wwwroot = _env.WebRootPath;

            string UserDirecotry = Path.Combine(wwwroot, existingItem.CreatedBy.ToString());
            if (!Directory.Exists(UserDirecotry))
                Directory.CreateDirectory(UserDirecotry);
            string ProjectDirecotry = Path.Combine(UserDirecotry, itemVM.ProjectId.ToString());
            if (!Directory.Exists(ProjectDirecotry))
                Directory.CreateDirectory(ProjectDirecotry);
            List<FileModel> files = new();

            itemVM.Files?.ForEach(file =>
            {
                string FileName = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString() + Path.GetExtension(file.FileName);
                string FilePath = Path.Combine(ProjectDirecotry, FileName);
                using var stream = new FileStream(FilePath, FileMode.Create);
                file.CopyTo(stream);
                FileModel filemodel = new()
                {
                    FilePath = Path.Combine(itemVM.CreatedBy.ToString(), itemVM.ProjectId.ToString(), FileName),
                    Items = new List<ItemModel>() { existingItem }
                };
                files.Add(filemodel);
            });
            await _itemRepo.UpdateAsync(existingItem, files);
            return new ResponseModel<string>
            {
                IsSuccess = true,
                StatusName = StatusType.SUCCESS,
                Message = "Updated"
            };
        }

        public async Task<ResponseModel<IEnumerable<ItemModel>>> GetAllAsync(Guid KeepId)
        {
            var items = await _itemRepo.GetAllAsync(KeepId);
            return new ResponseModel<IEnumerable<ItemModel>>()
            {
                IsSuccess = true,
                StatusName = StatusType.SUCCESS,
                Message = "list of all items",
                Data = items
            };
        }
    }
}
