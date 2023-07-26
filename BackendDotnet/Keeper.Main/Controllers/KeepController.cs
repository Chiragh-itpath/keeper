using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Services.Services;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    /*[Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class KeepController : ControllerBase
    {
        private readonly IKeepService _keepService;
        public KeepController(IKeepService keepService)
        {
            _keepService = keepService;
        }
        [HttpPost("")]
        public async Task<ResponseModel<string>> Post(KeepVM keep)
        {
            return await _keepService.SaveAsync(keep);
        }
        [HttpGet]
        [Route("{ProjectId}/{UserId}")]
        public async Task<ResponseModel<IEnumerable<KeepModel>>> GetAll(Guid ProjectId,Guid UserId)
        {
            return await _keepService.GetAllAsync(ProjectId,UserId);

        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ResponseModel<KeepModel>> GetById(Guid Id)
        {
            return await _keepService.GetByIdAsync(Id);

        }
        [HttpGet]
        [Route("Tag/{userId}/{tagId}")]
        public async Task<ResponseModel<List<KeepModel>>> GetByTag(Guid userId, Guid tagId)
        {
            return await _keepService.GetByTagAsync(userId, tagId);
        }
        [HttpPut]
        public async Task<ResponseModel<string>> Update(KeepVM keep)
        {
            return await _keepService.UpdatedAsync(keep);
        }
        [HttpDelete("{Id}")]
        public async Task<ResponseModel<string>> Delete(Guid Id)
        {
            return await _keepService.DeleteByIdAsync(Id);
        }
        [HttpGet("shared/{userid}")]
        public async Task<ResponseModel<IEnumerable<KeepModel>>> SharedKeeps(Guid userid)
        {
            return await _keepService.SharedKeepsAsync(userid);
        }
    }
}
