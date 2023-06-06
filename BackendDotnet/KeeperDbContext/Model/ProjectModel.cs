using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeperDbContext.Model
{
    public class ProjectModel
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
        public virtual TagModel Tag { get; set; }

        public Guid CreatedBy { get;set; }
        public Guid UpdatedBy { get;set; }
        public virtual IEnumerable<UserModel> Users { get; set; }
        public virtual IEnumerable<KeepModel> Keeps { get; set; }

        
    }
}
