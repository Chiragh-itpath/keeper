using Keeper.Common.Response;
using Keeper.Common.ViewModels;

namespace Keeper.Services.Services.Interfaces
{
    public interface IInviteService
    {
        Task<ResponseModel<string>> InviteToProjectAsync(ProjectInviteModel invite,Guid userId);
        Task<ResponseModel<List<InvitedProjectModel>>> GetAllInvitedProject(Guid UserId);
        Task<ResponseModel<string>> ResponseToProjectInvite(InviteResponseModel projectInvite,Guid userId);
        Task<ResponseModel<string>> InviteToKeepAsync(KeepInviteModel invite,Guid userId);
        Task<ResponseModel<List<InviteKeepModel>>> GetAllInvitedKeep(Guid UserId);
        Task<ResponseModel<string>> ResponseToKeepInvite(InviteResponseModel keepInvite,Guid userId);
        Task<ResponseModel<List<Collaborator>>> GetProjectCollaborators(Guid projectId);
        Task<ResponseModel<List<Collaborator>>> GetKeepCollaborators(Guid keepId);
    }
}
