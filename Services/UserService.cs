using AutoMapper;
using DigitusCase.Data;
using DigitusCase.Dtos;
using DigitusCase.Interfaces;
using DigitusCase.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitusCase.Services
{
    using BCrypt = BCrypt.Net.BCrypt;

    public class UserService : IUserService
    {
        private readonly LibraryContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(LibraryContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserDto Create(UserDto userDto)
        {
            if (_dbContext.Users.Any(user => user.Email.Equals(userDto.Email))){
                throw new ApplicationException();
            }

            var user = _mapper.Map<User>(userDto);
            user.Password = BCrypt.HashPassword(userDto.Password);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return _mapper.Map<UserDto>(user);   
        }
    }
}
