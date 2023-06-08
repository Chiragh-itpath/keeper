using Keeper.Common.Enums;

namespace Keeper.Common.Response
{
    public class ResponseModel
    {
        public EResponse StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = default!;
        public object Data { get; set; } = default!;
        public object MetaData { get; set; } = default!;
    }
}
