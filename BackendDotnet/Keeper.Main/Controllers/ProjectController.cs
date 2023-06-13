using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
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
        public async Task<ResponseModel> Post(ProjectVM projectVM)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    StatusCode = StatusType.NOT_VALID,
                    Data = ModelState.Values.SelectMany(x => x.Errors)
                };
            }
            return await _projectService.Insert(projectVM);
        }
        [HttpGet("")]
        public async Task<ResponseModel> Get(Guid UserId)
        {
            return await _projectService.GetProjects(UserId);

        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ResponseModel> GetById(Guid Id)
        {
            return await _projectService.GetProjectById(Id);

        }
        [HttpPut]
        public async Task<ResponseModel> Update(ProjectVM project)
        {
            return await _projectService.Update(project);
        }
        [HttpDelete]
        public async Task<ResponseModel> Delete(Guid id)
        {
            return await _projectService.Delete(id);
        }
        
    }
}
