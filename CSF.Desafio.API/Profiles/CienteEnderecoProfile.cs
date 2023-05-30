using AutoMapper;
using CSF.Desafio.API.Entities;
using Newtonsoft.Json.Linq;

namespace CSF.Desafio.API.Profiles
{
    public class ClienteEnderecoProfile : Profile
    {
        public ClienteEnderecoProfile()
        {
            CreateMap<Entities.ClienteEndereco, Models.ClienteEnderecoDto>().ReverseMap();   
        }

    }
}
