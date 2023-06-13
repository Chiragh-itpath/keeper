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
        public async Task<ResponseModel<IEnumerable<TagModel>>> Get()
        {
            return await _tagService.Get();
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<TagModel>> Get(Guid id)
        {
            return await _tagService.Get(id);
        }
        [HttpGet("Type/{type}")]
        public async Task<ResponseModel<IEnumerable<TagModel>>> Get(TagType type)
        {
            return await _tagService.Get(type);
        }
        [HttpGet("Title/{title}")]
        public async Task<ResponseModel<IEnumerable<TagModel>>> Get(string title)
        {
            return await _tagService.Get(title);
        }

        [HttpPost]
        public async Task<ResponseModel<TagModel>> Post(TagModel tagModel)
        {
            return await _tagService.Post(tagModel);
        }
        [HttpDelete]
        public async Task<bool> Delete(Guid id)
        {
            return await _tagService.Delete(id);
        }
    }
}
