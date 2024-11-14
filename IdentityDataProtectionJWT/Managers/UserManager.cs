using IdentityAndDataProtection.Context;
using IdentityAndDataProtection.Dtos;
using IdentityAndDataProtection.Entities;
using IdentityAndDataProtection.Services;
using IdentityAndDataProtection.Types;
using IdentityDataProtectionJWT.Dtos;

namespace IdentityAndDataProtection.Managers
{
    public class UserManager : IUserService
    {
        private readonly CustomIdentityDbContext _db;

        public UserManager(CustomIdentityDbContext db)
        {
            _db = db;   
        }
        public async Task<ServiceMessage> AddUser(AddUserDto userDto)
        {
            var userEntity = new UserEntity
            {
                Email = userDto.Email,
                Password = userDto.Password
            };

            _db.Users.Add(userEntity);
            _db.SaveChanges();

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "The register created successfully."
            };
        }

        public async Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto userDto)
        {
            var userEntity = _db.Users.Where(x => x.Email.ToLower() == userDto.Email.ToLower()).FirstOrDefault();

            if (userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Email or password is not correct"
                };
            }

            if (userEntity.Password == userDto.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Message = "",
                    Data = new UserInfoDto
                    {
                        Id = userEntity.Id,
                        Email = userEntity.Email,
                        UserType = userEntity.UserType
                    }
                };
            }

            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Email or password is not correct"
                };
            }

        }
    }
}
