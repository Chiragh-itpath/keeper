using Keeper.Common.Enums;

namespace Keeper.Common.Response
{
    public class ResponseModel<T> where T : class
    {
        public StatusType StatusName { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = default!;
        public T? Data { get; set; }
    }
}
