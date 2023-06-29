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
        public string Name  { get; set; }
        public string FromUser { get; set; }
        public string[] ToEmail { get; set; }
       
    }
}
