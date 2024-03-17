using DigitusCase.Dtos;

namespace DigitusCase.Interfaces
{
    public interface IUserService
    {
        UserDto Create(UserDto userDto);
    }
}
