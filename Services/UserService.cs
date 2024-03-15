using DigitusCase.Data;
using DigitusCase.Dtos;
using DigitusCase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitusCase.Services
{
    public class UserService : IUserService
    {
        private readonly LibraryContext _dbContext;

        public UserService(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<UserDto> Create(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
