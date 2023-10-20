using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Authorize]
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
        public async Task<ResponseModel<KeepViewModel>> Post(AddKeep keep)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _keepService.AddAsync(keep, userId);
        }
        [HttpGet("")]
        public async Task<ResponseModel<List<KeepViewModel>>> GetAll(Guid ProjectId)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _keepService.GetAllAsync(ProjectId, userId);
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<KeepViewModel>> GetById([FromRoute] Guid Id)
        {
            return await _keepService.GetAsync(Id);
        }
        [HttpPut]
        public async Task<ResponseModel<KeepViewModel>> Update(EditKeep keep)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _keepService.UpdateAsync(keep, userId);
        }
        [HttpDelete("{Id}")]
        public async Task<ResponseModel<string>> Delete(Guid Id)
        {
            return await _keepService.DeleteAsync(Id);
        }
    }
}
