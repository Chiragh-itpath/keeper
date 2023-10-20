namespace Keeper.Common.ViewModels
{
    public class AddKeep 
    {
        public string Title { get; set; } = default!;
        public Guid ProjectId { get; set; }
        public string? Tag { get; set; }
    }
    public class EditKeep : AddKeep
    {
        public Guid Id { get; set; }
    }
    public class KeepViewModel : AddKeep
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; } = default!;
        public string? Updatedby { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
