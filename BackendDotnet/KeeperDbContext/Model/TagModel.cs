using KeeperDbContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeperDbContext.Model
{
    public class TagModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TagType Type { get; set; }
    }
}
