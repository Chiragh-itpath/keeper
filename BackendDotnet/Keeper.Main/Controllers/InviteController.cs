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
    public class InviteController : ControllerBase
    {
        private readonly IInviteService _invite;

        public InviteController(IInviteService invite)
        {
            _invite = invite;
        }

        [HttpPost("InviteToProject")]
        public async Task<ResponseModel<string>> InviteToProject(ProjectInviteModel invite)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _invite.InviteToProjectAsync(invite,userId);
        }
        [HttpGet("AllInvitedProjects")]
        public async Task<ResponseModel<List<InvitedProjectModel>>> InvitedProjects()
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _invite.GetAllInvitedProject(userId);
        }
        [HttpPost("ProjectInviteResponse")]
        public async Task<ResponseModel<string>> ProjectInviteResponse(InviteResponseModel response)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _invite.ResponseToProjectInvite(response,userId);
        }
        [HttpPost("InviteToKeep")]
        public async Task<ResponseModel<string>> InviteToKeep(KeepInviteModel invite)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _invite.InviteToKeepAsync(invite,userId);
        }
        [HttpGet("InvitedKeeps")]
        public async Task<ResponseModel<List<InviteKeepModel>>> InvitedKeeps()
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _invite.GetAllInvitedKeep(userId);
        }
        [HttpPost("keepInviteResponse")]
        public async Task<ResponseModel<string>> KeepInviteResponse(InviteResponseModel response)
        {
            var user = User.Identities.First();
            var claims = user.Claims.ToList();
            var userId = Guid.Parse(claims.ElementAt(3).Value);
            return await _invite.ResponseToKeepInvite(response, userId);
        }
        [HttpGet("ProjectCollaborators")]
        public async Task<ResponseModel<List<Collaborator>>> ProjectCollaborators(Guid ProjectId)
        {
            return await _invite.GetProjectCollaborators(ProjectId);
        }
        [HttpGet("KeepCollaborators")]
        public async Task<ResponseModel<List<Collaborator>>> KeepCollaborators(Guid keepId)
        {
            return await _invite.GetKeepCollaborators(keepId);
        }
    }
}
