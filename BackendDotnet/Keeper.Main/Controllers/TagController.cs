using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Context.Model;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Keeper.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        public readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpGet]
        public async Task<ResponseModel> Get()
        {
            return await _tagService.Get();
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel> Get(Guid id)
        {
            return await _tagService.Get(id);
        }
        [HttpGet("{type}")]
        public async Task<ResponseModel> Get(TagType type)
        {
            return await _tagService.Get(type);
        }
        [HttpGet("{title}")]
        public async Task<ResponseModel> Get(string title)
        {
            return await _tagService.Get(title);
        }

        [HttpPost]
        public async Task<ResponseModel> Post(TagModel tagModel)
        {
            return await _tagService.Post(tagModel);
        }
        [HttpDelete]
        public async Task<ResponseModel> Delete(Guid id)
        {
            return await _tagService.Delete(id);
        }
    }
}
