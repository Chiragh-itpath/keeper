using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
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
        Task<ResponseModel<string>> SaveAsync(ProjectVM projectVM);
        Task<ResponseModel<List<ProjectModel>>> GetAllAsync(Guid UserId);
        Task<ResponseModel<ProjectModel>> GetByIdAsync(Guid Id);
        Task<ResponseModel<string>> DeleteByIdAsync(Guid Id);
        Task<ResponseModel<string>> UpdatedAsync(ProjectUpdateVM projectUpdate);
    }
}
