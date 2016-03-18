using AutoMapper;
using OAuth.Domain.Model;
using OAuth.Service.ModelDto;

namespace OAuth.Service.Common
{
    public class RegisterAutomapper
    {
        public static void Initialize()
        {
            Mapper.CreateMap<User, UserDto>();
        }
    }
}
