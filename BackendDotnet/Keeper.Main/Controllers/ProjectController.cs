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
            if(ModelState.IsValid)
            {
                return await _projectService.Insert(projectVM);

            }
            return new ResponseModel();
        }
        [HttpGet("")]
        public async Task<ResponseModel> Get(Guid UserId)
        {
            return await _projectService.GetProjects(UserId);
           
        }
    }
}
