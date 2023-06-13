using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Common.ViewModels
{
    public class LoginVM
    {
        [
            Required(ErrorMessage = "This field is required"),
            EmailAddress(ErrorMessage = "Enter an valid email")
        ]
        public string Email { get; set; }
        
        [
            Required(ErrorMessage = "This field is required"),
            StringLength(8, ErrorMessage = "Password must be 8 charecter long"),
        ]
        public string Password { get; set; } = default!;
    }
}
