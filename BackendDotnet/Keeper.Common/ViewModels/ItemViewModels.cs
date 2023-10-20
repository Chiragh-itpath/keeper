using Keeper.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace Keeper.Common.ViewModels
{
    public class CommonItem
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string? URL { get; set; }
        public ItemType Type { get; set; }
        public string Number { get; set; } = default!;
        public string? To { get; set; }
        public string? DiscussedBy { get; set; }
        public Guid KeepId { get; set; }
    }
    public class AddItem : CommonItem
    {
        public List<IFormFile>? Files { get; set; }
    }
    public class EditItem : CommonItem
    {
        public Guid Id { get; set; }
        public List<IFormFile>? Files { get; set; }
    }
    public class ItemViewModel : CommonItem
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = default!;
        public string? UpdatedBy { get; set; }
        public List<FileViewModel>? Files { get; set; }
    }
}
