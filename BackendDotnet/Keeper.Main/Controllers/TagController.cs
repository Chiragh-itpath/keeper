using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Keeper.Main.Controllers
{
    [Authorize]
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
        public async Task<ResponseModel<List<TagVM>>> Get()
        {
            return await _tagService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<TagModel>> Get(Guid id)
        {
            return await _tagService.GetByIdAsync(id);
        }
        [HttpGet("Type/{type}")]
        public async Task<ResponseModel<List<TagVM>>> Get(TagType type)
        {
            return await _tagService.GetByTypeAsync(type);
        }
        [HttpGet("Title/{title}")]
        public async Task<ResponseModel<TagModel>> Get(string title)
        {
            return await _tagService.GetByTitleAsync(title);
        }

        [HttpPost("")]
        public async Task<ResponseModel<TagModel>> SaveAsync(TagModel tagModel)
        {
            return await _tagService.SaveAsync(tagModel);
        }
        [HttpDelete]
        public async Task<bool> Delete(Guid id)
        {
            return await _tagService.DeleteByIdAsync(id);
        }
        [HttpGet("Project/{userid}")]
        public async Task<ResponseModel<List<TagVM>>> GetForProjectAsync(Guid userid)
        {
            return await _tagService.GetForProjectAsync(userid);
        }
        [HttpGet("Keep/{userid}/{projectid}")]
        public async Task<ResponseModel<List<TagVM>>> GetForKeepAsync(Guid userid, Guid projectid)
        {
            return await _tagService.GetForKeepsAsync(userid, projectid);
        }
    }
}
