using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper.Context.Model
{
    [Table("Keeps")]
    public class KeepModel 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50), Required]
        public string Title { get; set; } = default!;
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid CreatedById { get; set; }
        public virtual UserModel CreatedBy { get; set; }
        public Guid? UpdatedById { get; set; }
        public virtual UserModel UpdatedBy { get; set; }
        public Guid? TagId { get; set; }
        public virtual TagModel? Tag {  get; set; }

        [ForeignKey("ProjectId")]
        public Guid ProjectId { get; set; }
        public virtual ProjectModel? Project { get; set; }
    }
}
