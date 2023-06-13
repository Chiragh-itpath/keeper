using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Keeper.Context.Model
{
    public class ProjectModel : IDisposable
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        [NotNull]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid TagId { get; set; }
        public Guid CreatedBy { get;set; }
        public Guid UpdatedBy { get;set; }
        public virtual IEnumerable<UserModel> Users { get; set; }
        public virtual IEnumerable<KeepModel> Keeps { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
