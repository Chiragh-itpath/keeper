using Keeper.Common.Enums;

namespace Keeper.Common.Response
{
    public class ResponseModel
    {
        public StatusType StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = default!;
        public object? Data { get; set; } 
        public object? MetaData { get; set; }
        public ResponseModel GeneratStatusType(StatusType statusCode, bool isSuccess, string message, object? data, object? metaData)
        {
            StatusCode = statusCode;
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
            MetaData = metaData;
            return this;
        }
    }
}
