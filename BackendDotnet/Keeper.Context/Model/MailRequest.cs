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
        public Guid? ParentId { get; set;}
        public Guid UserId { get; set; }
       
    }
}
