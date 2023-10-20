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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost("")]
        public async Task<ResponseModel<ProjectViewModel>> Post(AddProject project)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _projectService.SaveAsync(project, userId);
        }
        [HttpGet("")]
        public async Task<ResponseModel<List<ProjectViewModel>>> GetAll()
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _projectService.GetAllAsync(userId);
        }
        [HttpGet("Shared")]
        public async Task<ResponseModel<List<ProjectViewModel>>> GetShared()
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _projectService.GetShared(userId);
        }
        [HttpGet("{Id}")]
        public async Task<ResponseModel<ProjectViewModel>> GetById([FromRoute] Guid Id)
        {
            return await _projectService.GetByIdAsync(Id);
        }
        [HttpPut]
        public async Task<ResponseModel<ProjectViewModel>> Update(EditProject project)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _projectService.UpdateAsync(project, userId);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            return await _projectService.DeleteByIdAsync(id);
        }

    }
}
