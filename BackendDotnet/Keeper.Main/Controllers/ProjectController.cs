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
        [HttpPost]
        public async Task<IActionResult> Insert(ProjectVM projectVM)
        {
            if(ModelState.IsValid)
            {
                var result= await _projectService.Insert(projectVM);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        } 
    }
}
