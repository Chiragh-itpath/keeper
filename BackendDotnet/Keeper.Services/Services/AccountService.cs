using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.Win32;

namespace Keeper.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        private readonly IConfiguration _configuration;
        private readonly IUserRepo _userRepo;
        private readonly IProjectRepo _projectRepo;
        private readonly IKeepRepo _keepRepo;
        public AccountService(IAccountRepo accountRepo, IConfiguration configuration, IUserRepo userRepo,IProjectRepo projectRepo, IKeepRepo keepRepo)
        {
            _accountRepo = accountRepo;
            _configuration = configuration;
            _userRepo = userRepo;
            _projectRepo = projectRepo;
            _keepRepo = keepRepo;
        }
        public async Task<ResponseModel<string>> RegisterAsync(RegisterVM register)
        {
            UserModel userModel = new()
            {
                UserName = register.UserName,
                Email = register.Email,
                Password = register.Password,
                Contact = register.Contact,
                CreatedOn = DateTime.Now,
                UpdateOn = null
            };
            var user = await _userRepo.GetByEmailAsync(register.Email);
            if (user.Id != Guid.Empty)
            {
                return new ResponseModel<string>
                {
                    IsSuccess = false,
                    StatusName = StatusType.ALREADY_EXISTS,
                    Message = "Email already exists"
                };
            }
            try
            {
                userModel.Password = BCrypt.Net.BCrypt.HashPassword(register.Password);
                bool res = await _accountRepo.RegisterAsync(userModel);
                if (res)
                {
                    return new ResponseModel<string>
                    {
                        IsSuccess = true,
                        StatusName = StatusType.SUCCESS,
                        Message = "Registered successfully"
                    };
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                return new ResponseModel<string>
                {
                    IsSuccess = false,
                    StatusName = StatusType.INTERNAL_SERVER_ERROR,
                    Message = "Error occured"
                };
            }
        }

        public async Task<ResponseModel<TokenModel>> LoginAsync(LoginVM loginVM)
        {
            var user = await _userRepo.GetByEmailAsync(loginVM.Email);
            if (user.Id == Guid.Empty)
            {
                return new ResponseModel<TokenModel>
                {
                    StatusName = StatusType.NOT_FOUND,
                    Message = "Email is not registered",
                    IsSuccess = false
                };
            }
            try
            {
                if (BCrypt.Net.BCrypt.Verify(loginVM.Password, user.Password))
                {

                    return new ResponseModel<TokenModel>
                    {
                        IsSuccess = true,
                        StatusName = StatusType.SUCCESS,
                        Message = "Logged in successfully",
                        Data = new TokenModel() { UserId = user.Id, Token = GenerateToken(user) }
                    };
                }
                else
                {
                    return new ResponseModel<TokenModel>
                    {
                        StatusName = StatusType.NOT_VALID,
                        Message = "Password is not matched",
                        IsSuccess = false
                    };
                }
            }
            catch (Exception)
            {
                return new ResponseModel<TokenModel>
                {
                    IsSuccess = false,
                    StatusName = StatusType.INTERNAL_SERVER_ERROR,
                    Message = "Error occured"
                };
            }
        }
        public string GenerateToken(UserModel user)
        {
            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<ResponseModel<string>> UpdatePasswordAsync(LoginVM user)
        {
            user.Password= BCrypt.Net.BCrypt.HashPassword(user.Password);
            if(await _accountRepo.UpdatePasswordAsync(user))
            {
                return new ResponseModel<string>()
                {
                    IsSuccess = true,
                    Message = "Password changed successfully!",
                    StatusName = StatusType.SUCCESS
                };
            }
            return new ResponseModel<string>()
            {
                IsSuccess = false,
                Message = "Password is not changed!",
                StatusName = StatusType.NOT_VALID
            };
        }
        public async Task<ResponseModel<OTPModel>> GenerateOTP(string email)
        {
            var user = await _userRepo.GetByEmailAsync(email);
            if (user.Id == Guid.Empty)
            {
                return new ResponseModel<OTPModel>
                {
                    StatusName = StatusType.NOT_FOUND,
                    Message = "Email is not registered",
                    IsSuccess = false
                };
            }

            var otp = SendOTP(email);
            if(otp!=0)
            {
                return new ResponseModel<OTPModel>
                {
                    StatusName = StatusType.SUCCESS,
                    Message = "OTP send",
                    IsSuccess = true,
                    Data=new OTPModel()
                    {
                        Email=email,
                        OTP=otp
                    }
                };
            }
            return new ResponseModel<OTPModel>
            {
                StatusName = StatusType.NOT_VALID,
                Message = "Incorrect Email Address",
                IsSuccess = false
            };
        }
        public int SendOTP(string email)
        {
            try
            {
                var fromMail = "keeper.vueproject@outlook.com";
                var userName = "keeper.vueproject@outlook.com";
                var emailPassword = "Keeper123@@";
                int otp = Convert.ToInt32(new Random().Next(0, 1000000).ToString("D6"));
                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress(fromMail);
                message.Subject = "OTP Verification";
                message.Body = $"<div style=\"font-family: Helvetica,Arial,sans-serif;min-width:1000px;overflow:auto;line-height:2\">\r\n  <div style=\"margin:50px auto;width:70%;padding:20px 0\">\r\n    <div style=\"border-bottom:1px solid #eee\">\r\n      <a href=\"\" style=\"font-size:1.4em;color: #00466a;text-decoration:none;font-weight:600\">Keeper</a>\r\n    </div>\r\n    <p style=\"font-size:1.1em\">Hi,</p>\r\n    <p>Thank you for choosing Keeper. Use the following OTP to complete your change the password procedures. OTP is valid for 5 minutes</p>\r\n    <h2 style=\"background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;\">{otp}</h2>\r\n    <p style=\"font-size:0.9em;\">Regards,<br />Keeper Team</p>\r\n    <hr style=\"border:none;border-top:1px solid #eee\" />\r\n    <div style=\"float:right;padding:8px 0;color:#aaa;font-size:0.8em;line-height:1;font-weight:300\">\r\n      <p>SMS</p>\r\n      <p>Ahmedabad</p>\r\n      <p>India</p>\r\n    </div>\r\n  </div>\r\n</div>";
                message.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.office365.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(userName, emailPassword);
                smtp.EnableSsl = true;

                message.IsBodyHtml = true;
                smtp.Send(message);
                return otp;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<ResponseModel<string>> ConfirmationOfSharedItemAsync(SharedItemVM sharedItem)
        {
            List<UserModel> users = new();
            List<ProjectModel> projects = new();
            List<KeepModel> Keeps = new();
            if (sharedItem.Type == 0)
            {
                var userdata = await _userRepo.GetByIdAsync(sharedItem.UId);
                var projectdata = await _projectRepo.GetByIdAsync(sharedItem.TypeId);
                users.Add(userdata);
                projects.Add(projectdata);
                projectdata.Users = users;
                userdata.Projects = projects;
                await _projectRepo.UpdatedAsync(projectdata);
                _userRepo.UpdateUser(userdata);
            }
            else
            {
                var userdata = await _userRepo.GetByIdAsync(sharedItem.UId);
                var keepdata = await _keepRepo.GetByIdAsync(sharedItem.TypeId);
                users.Add(userdata);
                Keeps.Add(keepdata);
                keepdata.Users = users;
                userdata.Keeps = Keeps;
                await _keepRepo.UpdatedAsync(keepdata);
                _userRepo.UpdateUser(userdata);
            }
            return new ResponseModel<string>()
            {
                StatusName=StatusType.SUCCESS,
                IsSuccess=true,
                Message="Confirmation Done"
            };
        }
    }
}
