using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KeeperCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepo userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var res = await _userRepo.GetAllAsync();
            return res;
        }
        public async Task<ResponseModel<string>> RegisterAsync(RegisterVM register)
        {
            UserModel userModel = new()
            {
                Id = Guid.NewGuid(),
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
                bool res = await _userRepo.RegisterAsync(userModel);
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

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            return await _userRepo.GetByEmailAsync(email);
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

            var claims = new[] {
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

        public async Task<ResponseModel<UserVM>> GetByIdAsync(Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if(user.Id == Guid.Empty)
            {
                return new ResponseModel<UserVM>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = true,
                    Message = "No User found with this id",
                };
            }
            var userVm = new UserVM()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Contact = user.Contact,
            };
            return new ResponseModel<UserVM>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "User Found",
                Data = userVm
            };
        }
    }
}
