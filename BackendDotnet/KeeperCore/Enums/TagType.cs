using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Common.Enums
{
    public enum TagType
    {
        [Description("Project")]
        PROJECT,
        [Description("Item")]
        ITEM,
        [Description("Keep")]
        KEEP
    }
}
