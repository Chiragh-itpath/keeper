using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Keeper.Main.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<ItemViewModel>> GetById([FromRoute] Guid id)
        {
            return await _itemService.GetAsync(id);
        }

        [HttpGet("")]
        public async Task<ResponseModel<List<ItemViewModel>>> GetAll(Guid keepId)
        {
            return await _itemService.GetAllAsync(keepId);
        }

        [HttpPost("")]
        public async Task<ResponseModel<ItemViewModel>> Post([FromForm] AddItem addItem)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _itemService.SaveAsync(addItem,userId);
        }
        [HttpPut("")]
        public async Task<ResponseModel<ItemViewModel>> Put([FromForm] EditItem editItem)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _itemService.UpdateAsync(editItem,userId);
        }
        [HttpDelete("{Id}")]
        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            return await _itemService.DeleteAsync(id);
        }
    }
}
