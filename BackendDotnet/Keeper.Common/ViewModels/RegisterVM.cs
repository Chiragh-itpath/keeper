using System.ComponentModel.DataAnnotations;
namespace Keeper.Common.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "This field is required")]
        public string UserName { get; set; } 
        [
            Required(ErrorMessage = "This field is required"),
            EmailAddress(ErrorMessage = "Enter an valid email")
        ]
        public string Email { get; set; }

        [
            Required(ErrorMessage = "This field is required"),
            RegularExpression(@"^[6-9]{1}[0-9]{9}", ErrorMessage = "Enter valid Phone number")
        ]
        public string Contact { get; set; } = default!;

        [
            Required(ErrorMessage = "This field is required"),            
            StringLength(8,ErrorMessage = "Password must be 8 charecter long")
        ]

        public string Password { get; set; } = default!;
        [
            Required(ErrorMessage = "This field is required"),
            StringLength(8, ErrorMessage = "Password must be 8 charecter long"),
            Compare("Password",ErrorMessage ="Confrim password and Password must be same")
        ]
        public string ConfirmPassword { get; set; } = default!;
    }
}
