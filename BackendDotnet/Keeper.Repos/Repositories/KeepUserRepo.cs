using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories
{
    public class KeepUserRepo : IKeepUserRepo
    {
        private readonly DbKeeperContext _context;
        public KeepUserRepo(DbKeeperContext context)
        {
            _context = context;
        }

        public async Task<KeepUserModel> SaveAsync(KeepUserModel model)
        {
            model.Id = Guid.NewGuid();
            await _context.keepUser.AddAsync(model);
            _context.SaveChanges();
            return model;

        }
    }
}
