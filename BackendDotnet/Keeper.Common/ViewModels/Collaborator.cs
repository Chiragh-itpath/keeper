namespace Keeper.Common.ViewModels
{
    public class Collaborator
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool HasAccepted { get; set; } = false;
    }
}
