using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Common.ViewModels
{
    public class KeepVM
    {
        public Guid? Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid ProjectId { get; set; }
        public string? TagTitle { get; set; }
    }
}
