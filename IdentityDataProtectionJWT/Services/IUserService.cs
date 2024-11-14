using IdentityAndDataProtection.Dtos;
using IdentityAndDataProtection.Entities;
using IdentityAndDataProtection.Types;
using IdentityDataProtectionJWT.Dtos;

namespace IdentityAndDataProtection.Services
{
    public interface IUserService
    {

        Task<ServiceMessage> AddUser(AddUserDto userDto);

        Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto userDto);

    }
}
