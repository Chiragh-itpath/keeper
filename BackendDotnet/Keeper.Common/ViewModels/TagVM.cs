using Keeper.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Common.ViewModels
{
    public class TagVM : IDisposable
    {
        public string Title { get; set; }
        public TagType Type { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
