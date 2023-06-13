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
        Task<ResponseModel<string>> Insert(ProjectVM projectVM);
        Task<ResponseModel<List<ProjectModel>>> GetProjects(Guid UserId);
        Task<ResponseModel<ProjectModel>> GetProjectById(Guid Id);
        Task<ResponseModel<string>> Delete(Guid Id);
        Task<ResponseModel<string>> Update(ProjectVM project);
    }
}
