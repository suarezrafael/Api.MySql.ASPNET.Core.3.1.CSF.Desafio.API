using AutoMapper;
using CSF.Desafio.API.Entities;
using Newtonsoft.Json.Linq;

namespace CSF.Desafio.API.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Entities.Cliente, Models.ClienteDto>().ReverseMap();
            CreateMap<Models.ClienteForCreationDto, Entities.Cliente>();
            CreateMap<Models.ClienteForUpdateDto, Entities.Cliente>();
            CreateMap<Entities.Cliente, Models.ClienteForUpdateDto>().ReverseMap();
        }

        
    }
}
