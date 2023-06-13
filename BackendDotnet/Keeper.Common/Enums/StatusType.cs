using System.ComponentModel;

namespace Keeper.Common.Enums
{
    public enum StatusType
    {
        [Description("Success")]
        SUCCESS,
        [Description("Already Exists")]
        ALREADY_EXISTS,
        [Description("Not Found")]
        NOT_FOUND,
        [Description("Not Authorised")]
        NOT_AUTHORISED,
        [Description("Not Valid")]
        NOT_VALID,
        [Description("Internal Server Error")]
        INTERNAL_SERVER_ERROR
    }
}
