using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Keeper.Services.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepo _file;
        private readonly IItemFileLInkerRepo _linker;
        private readonly IWebHostEnvironment _env;
        public FileService(IFileRepo file, IItemFileLInkerRepo linker, IWebHostEnvironment env)
        {
            _file = file;
            _linker = linker;
            _env = env;
        }
        public async Task AddAsync(Guid UserId, Guid KeepId, Guid ItemId, List<IFormFile> files)
        {
            string webRoot = _env.WebRootPath;
            string userDict = Path.Combine(webRoot, "Images", UserId.ToString());
            if (!Directory.Exists(userDict))
            {
                Directory.CreateDirectory(userDict);
            }
            string KeepDict = Path.Combine(userDict, KeepId.ToString());
            if (!Directory.Exists(KeepDict))
            {
                Directory.CreateDirectory(KeepDict);
            }
            for (int i = 0; i < files.Count; i++)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(files[i].FileName);
                string fileStorePath = Path.Combine(UserId.ToString(), KeepId.ToString(), filename);
                string fileToUpload = Path.Combine(KeepDict, filename);
                using (var stream = new FileStream(fileToUpload, FileMode.Create))
                {
                    await files[i].CopyToAsync(stream);
                }

                var file = await _file.AddAsync(new FileModel()
                {
                    FilePath = fileStorePath,
                    OriginalName = files[i].FileName,
                });
                await _linker.AddAsync(new ItemFileLinkerModel()
                {
                    FileId = file.Id,
                    ItemId = ItemId
                });
            }
        }
        public async Task<List<FileViewModel>> GetAllFiles(Guid itemId)
        {
            List<string> ImageExtensions = new() { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG", ".JFIF" };

            string ImagePath = Path.Combine("https://localhost:7134/", "Images");
            var res = await _file.GetFilesAsync(itemId);
            var files = res.Select(x => new FileViewModel
            {
                FileName = x.OriginalName,
                FileUrl = Path.Combine(ImagePath, x.FilePath),
                IsImage = ImageExtensions.Contains(Path.GetExtension(Path.Combine(ImagePath,x.FilePath)).ToUpperInvariant())
            }).ToList();
            return files;
        }

    }
}
