using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<ResponseModel<string>> Post(ProjectVM projectVM)
        {
            return await _projectService.SaveAsync(projectVM);
        }
        [HttpGet("")]
        public async Task<ResponseModel<List<ProjectModel>>> GetAll(Guid UserId)
        {
            return await _projectService.GetAllAsync(UserId);

        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ResponseModel<ProjectModel>> GetById(Guid Id)
        {
            return await _projectService.GetByIdAsync(Id);

        }
        [HttpGet]
        [Route("Tag/{userId}/{tagId}")]
        public async Task<ResponseModel<List<ProjectModel>>> GetByTag(Guid userId,Guid tagId)
        {
            return await _projectService.GetByTagAsync(userId,tagId);

        }
        [HttpPut]
        public async Task<ResponseModel<string>> Update(ProjectVM project)
        {
            return await _projectService.UpdatedAsync(project);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            return await _projectService.DeleteByIdAsync(id);
        }

    }
}
