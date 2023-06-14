
namespace Keeper.Common.ViewModels
{
    public class UserVM : IDisposable
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Contact { get; set; } = default!;
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
