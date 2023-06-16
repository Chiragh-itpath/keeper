using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Services.Interfaces
{
    public interface IFileService
    {
        Task<ResponseModel<string>> UploadAsync(FileVM file);
    }
}
