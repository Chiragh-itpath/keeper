using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeperDbContext.Model
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public bool Type { get; set; }
        public string Number { get; set; }
        public string To { get; set; }
        public string DiscussedBy { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
