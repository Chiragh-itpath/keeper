using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Common.ViewModels
{
    public class TokenModel : IDisposable
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
