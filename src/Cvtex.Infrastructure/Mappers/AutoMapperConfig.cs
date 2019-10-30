using AutoMapper;
using Cvtex.Core.Domain;
using Cvtex.Infrastructure.DTO;

namespace Cvtex.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserDto>();
            }).CreateMapper();
    }
}