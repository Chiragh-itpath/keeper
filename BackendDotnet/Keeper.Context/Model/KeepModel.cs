using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Context.Model
{
    public class KeepModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; } = default!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set;}
        public Guid TagId { get; set; }
        public virtual TagModel Tag { get; set; }

        [ForeignKey(nameof(ProjectModel))]
        public Guid ProjectId { get; set; }
        public virtual ProjectModel Project { get; set; }
        public virtual IEnumerable<UserModel> Users { get; set; }
    }
}
