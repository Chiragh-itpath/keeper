using Keeper.Common.Enums;
using Keeper.Common.OtherModels;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;

namespace Keeper.Services.Services
{
    public class InviteService : IInviteService
    {
        private readonly IProjectShareRepo _projectShare;
        private readonly IKeepShareRepo _shareKeep;
        private readonly IUserRepo _user;
        private readonly IProjectRepo _project;
        private readonly IKeepRepo _keep;
        private readonly IMailService _mail;
        public InviteService(IProjectShareRepo projectShare, IUserRepo user, IProjectRepo project, IKeepShareRepo shareKeep, IKeepRepo keep, IMailService mail)
        {
            _projectShare = projectShare;
            _user = user;
            _project = project;
            _shareKeep = shareKeep;
            _keep = keep;
            _mail = mail;
        }
        public async Task<ResponseModel<string>> InviteToProjectAsync(ProjectInviteModel invite, Guid userId)
        {
            var sender = await _user.GetById(userId);
            var project = await _project.GetByIdAsync(invite.ProjectId);
            for (int i = 0; i < invite.Emails.Count; i++)
            {
                var user = await _user.GetByEmailAsync(invite.Emails[i]);
                var invitemodel = new SharedProjectsModel()
                {
                    ProjectId = invite.ProjectId,
                    UserId = user!.Id
                };
                await _projectShare.AddAsync(invitemodel);
                await _mail.SendEmailAsync(new MailModel
                {
                    Category = MailCategory.SendInvitation,
                    From = sender?.Email ?? string.Empty,
                    To = user.Email,
                    Subject = "Project Invitation",
                    Message = project?.Title ?? string.Empty
                });
            }
            return new ResponseModel<string>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "Users Invited"
            };
        }
        public async Task<ResponseModel<List<InvitedProjectModel>>> GetAllInvitedProject(Guid UserId)
        {
            var invited = await _projectShare.GetAllInvited(UserId);
            invited = invited.Where(x => !x.IsAccepted).ToList();
            List<InvitedProjectModel> invitedProjects = new();
            for (int i = 0; i < invited.Count; i++)
            {
                var project = await _project.GetByIdAsync(invited[i].ProjectId);
                var user = await _user.GetById(project!.CreatedById);
                invitedProjects.Add(new InvitedProjectModel
                {
                    ProjectId = invited[i].Id,
                    Name = project!.Title,
                    Email = user!.Email
                });
            }
            return new ResponseModel<List<InvitedProjectModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Data = invitedProjects
            };
        }
        public async Task<ResponseModel<string>> ResponseToProjectInvite(InviteResponseModel projectInvite, Guid userId)
        {
            var shared = await _projectShare.GetAsync(projectInvite.InviteId);
            var project = await _project.GetByIdAsync(shared.ProjectId);
            var user = project?.CreatedBy;
            var sender = await _user.GetById(userId);
            if (projectInvite.Response)
            {
                shared.IsAccepted = true;
                await _projectShare.UpdateAsync(shared);
            }
            else
            {
                await _projectShare.DeleteAsync(shared);
            }
            await _mail.SendEmailAsync(new MailModel
            {
                Category = projectInvite.Response ? MailCategory.AcceptInvitation : MailCategory.RejectInvitation,
                From = sender?.Email ?? "",
                To = user?.Email ?? "",
                Subject = string.Concat("Invitation " + (projectInvite.Response ? "Accepted" : "Rejected"))
            });
            return new ResponseModel<string>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = string.Concat("Invitation " + (projectInvite.Response ? "Accepted" : "Rejected"))
            };
        }
        public async Task<ResponseModel<string>> InviteToKeepAsync(KeepInviteModel invite, Guid userId)
        {
            var sender = await _user.GetById(userId);
            var keep = await _keep.GetAsync(invite.KeepId);
            for (int i = 0; i < invite.Emails.Count; i++)
            {
                var user = await _user.GetByEmailAsync(invite.Emails[i]);
                var inviteModel = new SharedKeepsModel()
                {
                    KeepId = invite.KeepId,
                    ProjectId = invite.ProjectId,
                    UserId = user!.Id
                };
                await _shareKeep.AddAsync(inviteModel);
                await _mail.SendEmailAsync(new MailModel
                {
                    Category = MailCategory.SendInvitation,
                    From = sender?.Email ?? string.Empty,
                    To = user.Email,
                    Subject = "Project Invitation",
                    Message = keep?.Title ?? ""
                });
            }
            return new ResponseModel<string>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "Users Invited"
            };
        }
        public async Task<ResponseModel<List<InviteKeepModel>>> GetAllInvitedKeep(Guid UserId)
        {
            var invited = await _shareKeep.GetAllInvited(UserId);
            invited = invited.Where(x => !x.IsAccepted).ToList();
            List<InviteKeepModel> inviteKeeps = new();
            for (int i = 0; i < invited.Count; i++)
            {
                var keep = await _keep.GetAsync(invited[i].KeepId);
                var user = await _user.GetById(keep!.CreatedById);
                inviteKeeps.Add(new InviteKeepModel
                {
                    KeepId = invited[i].Id,
                    Name = keep.Title,
                    Email = user!.Email
                });
            }
            return new ResponseModel<List<InviteKeepModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Data = inviteKeeps
            };
        }
        public async Task<ResponseModel<string>> ResponseToKeepInvite(InviteResponseModel keepInvite, Guid userId)
        {
            var shared = await _shareKeep.GetAsync(keepInvite.InviteId);
            var project = await _project.GetByIdAsync(shared.ProjectId);
            var user = project?.CreatedBy;
            var sender = await _user.GetById(userId);
            if (keepInvite.Response)
            {
                shared.IsAccepted = true;
                await _shareKeep.UpdateAsync(shared);
            }
            else
            {
                await _shareKeep.DeleteAsync(shared);
            }
            await _mail.SendEmailAsync(new MailModel
            {
                Category = keepInvite.Response ? MailCategory.AcceptInvitation : MailCategory.RejectInvitation,
                From = sender?.Email ?? "",
                To = user?.Email ?? "",
                Subject = string.Concat("Invitation " + (keepInvite.Response ? "Accepted" : "Rejected"))
            });
            return new ResponseModel<string>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = string.Concat("Invitation " + (keepInvite.Response ? "Accepted" : "Rejected"))
            };
        }
        public async Task<ResponseModel<List<Collaborator>>> GetProjectCollaborators(Guid projectId)
        {
            var SharedProject = await _projectShare.GetAllAsync(projectId);
            var collaborator = SharedProject.Select(x => new Collaborator
            {
                UserName = x.User.UserName,
                Email = x.User.Email,
                HasAccepted = x.IsAccepted
            }).ToList();

            return new ResponseModel<List<Collaborator>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = collaborator
            };
        }
        public async Task<ResponseModel<List<Collaborator>>> GetKeepCollaborators(Guid keepId)
        {
            var sharedkeep = await _shareKeep.GetAllAsync(keepId);
            var collaborator = sharedkeep.Select(x => new Collaborator
            {
                UserName = x.User.UserName,
                Email = x.User.Email,
                HasAccepted = x.IsAccepted
            }).ToList();
            await Task.CompletedTask;
            return new ResponseModel<List<Collaborator>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = collaborator
            };
        }
    }
}
