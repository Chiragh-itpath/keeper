using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services
{
    public class KeepUserService : IKeepUserService
    {
        private readonly IKeepUserRepo _repo;
        public KeepUserService(IKeepUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<KeepUserModel> SaveAsync(Guid UserId, Guid KeepId)
        {
            KeepUserModel keepUser = new()
            {
                UserId = UserId,
                KeepId = KeepId
            };
            return await _repo.SaveAsync(keepUser);

        }
    }
}
