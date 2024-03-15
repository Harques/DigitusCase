using AutoMapper;
using DigitusCase.Dtos;
using DigitusCase.Models;

namespace DigitusCase.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }

    }
}
