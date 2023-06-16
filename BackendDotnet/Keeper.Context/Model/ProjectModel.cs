using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Keeper.Context.Model
{
    public class ProjectModel : IDisposable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50), Required]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid? TagId { get; set; }
        public Guid CreatedBy { get;set; }
        public Guid? UpdatedBy { get;set; }
        public virtual IEnumerable<UserModel>? Users { get; set; }
        public virtual IEnumerable<KeepModel>? Keeps { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
