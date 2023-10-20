using Keeper.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper.Context.Model
{
    [Table("Items")]
    public class ItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string? URL { get; set; }
        public ItemType Type { get; set; }
        public string Number { get; set; } = default!;
        public string? To { get; set; }
        public string? DiscussedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("KeepId")]
        public Guid KeepId { get; set; }
        public virtual KeepModel Keep { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid CreatedById { get; set; }
        public virtual UserModel CreatedBy { get; set; }
        public Guid? UpdatedById { get; set; }
        public virtual UserModel? UpdatedBy { get; set; }
    }
}
