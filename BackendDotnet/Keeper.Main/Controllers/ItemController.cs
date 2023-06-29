using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        
        [HttpPost]
        public async Task<ResponseModel<string>> Post(ItemVM itemVM)
        {
            return await _itemService.SaveAsync(itemVM);
        }
        [HttpPut]
        public async Task<ResponseModel<string>> Update([FromForm] ItemVM itemVM)
        {
            return await _itemService.UpdateAsync(itemVM);
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<ItemModel>> Get(Guid id) 
        {
            return await _itemService.GetByIdAsync(id);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            return await _itemService.DeleteAsync(id);
        }
        [HttpGet("Keep/{KeepId}")]
        public async Task<ResponseModel<IEnumerable<ItemModel>>> GetAll(Guid KeepId)
        {
            return await _itemService.GetAllAsync(KeepId);
        }
    }
}
