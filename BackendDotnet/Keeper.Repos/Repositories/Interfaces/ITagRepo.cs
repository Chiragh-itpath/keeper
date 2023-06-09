﻿using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface ITagRepo
    {
        Task<bool> DeleteByIdAsync(Guid id);
        Task<IEnumerable<TagModel>> GetAllAsync();
        Task<TagModel> GetByIdAsync(Guid Id);
        Task<IEnumerable<TagModel>> GetByTypeAsync(TagType type);
        Task<TagModel> GetByTitleAsync(string title);
        Task<TagModel> SaveAsync(TagModel tag);
        Task<IEnumerable<TagModel>> GetForProjectAsync(Guid userid);
        Task<IEnumerable<TagModel>> GetForKeepAsync(Guid userid,Guid projectid);
    }
}
