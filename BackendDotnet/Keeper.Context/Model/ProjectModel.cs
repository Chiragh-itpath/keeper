using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper.Context.Model
{
    [Table("Projects")]
    public class ProjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid? TagId { get; set; }
        public virtual TagModel? Tag { get; set; }
        public Guid CreatedById { get; set; }
        public virtual UserModel CreatedBy { get; set; }
        public Guid? UpdatedById { get; set; }
        public virtual UserModel? UpdatedBy { get; set; }
    }
}
