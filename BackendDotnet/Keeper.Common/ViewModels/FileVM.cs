using Microsoft.AspNetCore.Http;

namespace Keeper.Common.ViewModels
{
    public class FileVM
    {
        public List<IFormFile>? Files { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
