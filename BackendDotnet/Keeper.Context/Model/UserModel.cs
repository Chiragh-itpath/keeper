using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Context.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Contact { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public virtual IEnumerable<ProjectModel> Projects { get; set; }
        public virtual IEnumerable<KeepModel> Keeps { get; set; }
    }
}
