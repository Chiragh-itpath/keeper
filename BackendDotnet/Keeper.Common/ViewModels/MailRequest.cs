using Keeper.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Context.Model
{
    public class MailRequest
    {

        public string[] ToEmail { get; set; }
        public TagType Type { get; set; }
        public Guid TypeId { get; set; }

    }
}
