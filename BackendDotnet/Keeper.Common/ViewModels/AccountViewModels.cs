namespace Keeper.Common.ViewModels
{
    public class LoginModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
    public class RegisterModel : LoginModel
    {
        public string UserName { get; set; } = default!;
        public string Contact {  get; set; } = default!;
    }
    public class PasswordResetModel : LoginModel { }
}
