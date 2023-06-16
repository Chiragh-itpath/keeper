using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Keeper.Services.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepo _fileRepo;
        private readonly IWebHostEnvironment _env;
        public FileService(IFileRepo fileRepo, IWebHostEnvironment env)
        {
            _fileRepo = fileRepo;
            _env = env;
        }
        public async Task<ResponseModel<string>> UploadAsync(FileVM files)
        {
            if (
                files.Files == null ||
                files.UserId == Guid.Empty ||
                files.ProjectId == Guid.Empty
            )
                return new ResponseModel<string>
                {
                    IsSuccess = true,
                    StatusName = StatusType.NOT_VALID,
                    Message = "Not valid data",
                    Data = "Please enter valid data"
                };

            string wwwroot = _env.WebRootPath;
            string UserDirecotry = Path.Combine(wwwroot, files.UserId.ToString());
            if (!Directory.Exists(UserDirecotry))
                Directory.CreateDirectory(UserDirecotry);
            string ProjectDirecotry = Path.Combine(UserDirecotry, files.ProjectId.ToString());
            if (!Directory.Exists(ProjectDirecotry))
                Directory.CreateDirectory(ProjectDirecotry);

            List<string> FilePathList = new();
            files.Files!.ForEach(file =>
            {
                string filename = Path.Combine(ProjectDirecotry, file.FileName);
                using var stream = new FileStream(filename, FileMode.Create);
                file.CopyTo(stream);
                FilePathList.Add(
                    Path.Combine(
                        files.UserId.ToString(),
                        files.ProjectId.ToString(),
                        file.FileName
                    )
                );
            });
            string path = string.Join("|", FilePathList.ToArray<string>());

            Guid id = await _fileRepo.UploadAsync(new FileModel()
            {
                FilePath = path
            });
            return new ResponseModel<string>
            {
                Data = id.ToString()
            };
        }
    }
}
