using AutoMapper;
using DigitusCase.Dtos.User;
using DigitusCase.Models;

namespace DigitusCase.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserLoginDto>();
            CreateMap<UserRegisterDto, User>();

        }

    }
}
