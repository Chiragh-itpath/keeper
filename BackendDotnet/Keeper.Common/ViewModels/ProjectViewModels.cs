namespace Keeper.Common.ViewModels
{
    public class AddProject 
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string? Tag { get; set; }
    }
    public class EditProject : AddProject
    {
        public Guid Id { get; set; }
    }
    public class ProjectViewModel: AddProject
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = default!;
        public string? UpdatedBy { get; set; }
        public bool IsShared { get; set; } = false;
    }
}
