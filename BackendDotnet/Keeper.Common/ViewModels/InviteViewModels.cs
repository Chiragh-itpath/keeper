namespace Keeper.Common.ViewModels
{
    public class ProjectInviteModel
    {
        public Guid ProjectId { get; set; }
        public List<string> Emails { get; set; } = new List<string>();
    }
    public class KeepInviteModel : ProjectInviteModel
    {
        public Guid KeepId { get; set; }
    }
    public class InviteResponseModel
    {
        public Guid InviteId { get; set; }
        public bool Response { get; set; }
    }

    public class CommonInvitedModel
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
    public class InvitedProjectModel : CommonInvitedModel
    {
        public Guid ProjectId { get; set; }
    }
    public class InviteKeepModel : CommonInvitedModel
    {
        public Guid KeepId { get; set; }
    }



}
