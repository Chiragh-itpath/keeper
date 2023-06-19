using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Common.View_Models
{
    public class ProjectVM
    {
        public Guid? Id { get; set; }
        [Required]
        public string Title { get; set; }
        public Guid? TagId{ get; set; }
        public string? Description { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

}
