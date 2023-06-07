using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Common.Enums
{
    public enum ItemType
    {
        [Description("Ticket")]
        TICKET,
        [Description("Pull Request")]
        PR
    }
}
