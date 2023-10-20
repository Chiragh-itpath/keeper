using Keeper.Common.Enums;
using Keeper.Common.OtherModels;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Keeper.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        private readonly IConfiguration _configuration;
        private readonly IUserRepo _userRepo;
        private readonly IMailService _mail;
        public AccountService(IAccountRepo accountRepo, IConfiguration configuration, IUserRepo userRepo, IMailService mail)
        {
            _accountRepo = accountRepo;
            _configuration = configuration;
            _userRepo = userRepo;
            _mail = mail;
        }
        public async Task<ResponseModel<string>> RegisterAsync(RegisterModel register)
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
            if (user != null)
            {
                return new ResponseModel<string>
                {
                    IsSuccess = false,
                    StatusName = StatusType.ALREADY_EXISTS,
                    Message = "Email already exists"
                };
            }
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(register.Password);
            await _accountRepo.RegisterAsync(userModel);
            return new ResponseModel<string>
            {
                IsSuccess = true,
                StatusName = StatusType.SUCCESS,
                Message = "Registered successfully"
            };
        }
        public async Task<ResponseModel<TokenModel>> LoginAsync(LoginModel login)
        {
            var user = await _userRepo.GetByEmailAsync(login.Email);
            if (user == null)
            {

                return new ResponseModel<TokenModel>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = "Email is not registered"
                };
            }
            if (!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                return new ResponseModel<TokenModel>
                {
                    StatusName = StatusType.NOT_VALID,
                    IsSuccess = false,
                    Message = "Password does not match"
                };
            }
            var Token = new TokenModel
            {
                Token = GenerateToken(user)
            };
            return new ResponseModel<TokenModel>
            {
                IsSuccess = true,
                StatusName = StatusType.SUCCESS,
                Message = "",
                Data = Token
            };
        }
        public async Task<ResponseModel<string>> GetOTP(string email)
        {
            string otp = OtpGenerator;
            await _mail.SendEmailAsync(new MailModel
            {
                Category = MailCategory.OTP,
                From = "",
                To = email,
                Subject = "Email Verification",
                Message = otp
            });
            return new ResponseModel<string>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "Mail Sent",
                Data = otp
            };
        }
        public async Task<ResponseModel<string>> UpdatePasswordAsync(PasswordResetModel resetModel)
        {
            var user = await _userRepo.GetByEmailAsync(resetModel.Email);
            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(resetModel.Password);
                if (await _accountRepo.UpdatePasswordAsync(user))
                {
                    return new ResponseModel<string>()
                    {
                        StatusName = StatusType.SUCCESS,
                        IsSuccess = true,
                        Message = "Password changed successfully!"
                    };
                }
            }
            return new ResponseModel<string>()
            {
                StatusName = StatusType.NOT_VALID,
                IsSuccess = false,
                Message = "Password is not changed!"
            };
        }
        private string GenerateToken(UserModel user)
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
        private static string OtpGenerator
        {
            get
            {
                const string characters = "0123456789";
                const int otpLength = 6;
                Random random = new();
                string otp = new(Enumerable.Repeat(characters, otpLength)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                return otp;
            }
        }
    }
}
