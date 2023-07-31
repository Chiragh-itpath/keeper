using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Services.Interfaces
{
    public interface IKeepUserService
    {
        Task<KeepUserModel> SaveAsync(Guid UserId, Guid KeepId);
    }
}
