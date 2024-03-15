using DigitusCase.Dtos;

namespace DigitusCase.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Create(UserDto userDto);
    }
}
