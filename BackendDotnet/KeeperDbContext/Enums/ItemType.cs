using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeperDbContext.Enums
{
    public enum ItemType
    {
        [Description("Ticket")]
        TICKET,
        [Description("Pull Request")]
        PR
    }
}
