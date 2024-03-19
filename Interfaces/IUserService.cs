using DigitusCase.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace DigitusCase.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<bool> ValidateUserAsync(UserLoginDto userLoginDto);
        Task<string> CreateTokenAsync();

    }
}
