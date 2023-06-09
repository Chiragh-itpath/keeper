using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Services.Interfaces;


namespace KeeperCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var res = await _userRepo.GetAllUsers();
            return res;
        }
        public async Task<ResponseModel> RegisterUser(RegisterVM register)
        {
            ResponseModel responseModel;
            UserModel userModel = new()
            {
                Id = Guid.NewGuid(),
                UserName = register.UserName,
                Email = register.Email,
                Password = register.Password,
                Contact = register.Contact,
                CreatedOn = register.CreatedOn,
                UpdateOn = null
            };
            var user = await _userRepo.GetUserByEmail(register.Email);
            if (user.Id != Guid.Empty)
            {
                responseModel = new()
                {
                    IsSuccess = false,
                    StatusCode = EResponse.ALREADY_EXISTS,
                    Message = "Email already exists"
                };
                return responseModel;
            }
            try
            {
                userModel.Password = BCrypt.Net.BCrypt.HashPassword(register.Password);
                bool res = await _userRepo.Register(userModel);
                if (res)
                {
                    responseModel = new()
                    {
                        IsSuccess = true,
                        StatusCode = EResponse.OK,
                        Message = "Registered successfully"
                    };
                    return responseModel;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                responseModel = new()
                {
                    IsSuccess = false,
                    StatusCode = EResponse.NOT_VALID,
                    Message = "Error occured"
                };
                return responseModel;
            }
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _userRepo.GetUserByEmail(email);
        }

        public async Task<ResponseModel> Login(string email, string password)
        {

            ResponseModel responseModel = new();
            var user = await _userRepo.GetUserByEmail(email);
            if (user.Id == Guid.Empty)
            {
                responseModel = new()
                {
                    StatusCode = EResponse.NOT_FOUND,
                    Message = "Email is not registered",
                    IsSuccess = false
                };
                return responseModel;
            }
            try
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    responseModel = new()
                    {
                        IsSuccess = true,
                        StatusCode = EResponse.OK,
                        Message = "Logged in successfully"

                    };
                }
                else
                {
                    responseModel = new()
                    {
                        StatusCode = EResponse.NOT_VALID,
                        Message = "Password is not matched",
                        IsSuccess = false
                    };
                }
            }
            catch (Exception)
            {
                responseModel = new()
                {
                    IsSuccess = false,
                    StatusCode = EResponse.NOT_VALID,
                    Message = "Error occured"
                };
            }
            return responseModel;
        }
    }
}
