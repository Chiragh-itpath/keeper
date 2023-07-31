
using Keeper.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace Keeper.Common.ViewModels
{
    public class ItemVM
    {
        public Guid? Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string? URL { get; set; }
        public ItemType Type { get; set; }
        public string Number { get; set; } = default!;
        public string? To { get; set; }
        public string? DiscussedBy { get; set; }
        public Guid KeepId { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public List<IFormFile>? Files { get; set; }
    }
}
