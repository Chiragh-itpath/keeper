using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService) 
        { 
            _fileService = fileService;
        }
        [HttpPost]
        public async Task<ResponseModel<string>> Post([FromForm]FileVM fileVM)
        {
            return await _fileService.UploadAsync(fileVM);
        }
    }
}
