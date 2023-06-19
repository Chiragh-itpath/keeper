using Keeper.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Keeper.Context.Model
{
    public class ItemModel : IDisposable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50), Required]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string? URL { get; set; }
        public ItemType Type { get; set; }
        [StringLength(10)]
        public string Number { get; set; } = default!;
        public string? To { get; set; }
        public string? DiscussedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid KeepId { get; set; }
        public virtual KeepModel? Keep { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid TagId { get; set; }
        public virtual ICollection<FileModel>? Files { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
