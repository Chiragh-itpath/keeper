using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ResponseModel> Insert(ProjectVM projectVM);
        Task<ResponseModel> GetProjects(Guid UserId);
        Task<ResponseModel> GetProjectById(Guid Id);
        Task<ResponseModel> Delete(Guid Id);
        Task<ResponseModel> Update(ProjectVM project);
    }
}
