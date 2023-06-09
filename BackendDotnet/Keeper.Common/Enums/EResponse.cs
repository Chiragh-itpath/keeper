using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Common.Enums
{
    public enum EResponse
    {
        OK,
        ALREADY_EXISTS,
        NOT_FOUND,
        NOT_AUTHORISED,
        NOT_VALID,
        INTERNAL_SERVER_ERROR
    }
}
