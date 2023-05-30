using AutoMapper;
using CSF.Desafio.API.Entities;
using Newtonsoft.Json.Linq;

namespace CSF.Desafio.API.Profiles
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<Entities.Cidade, Models.CidadeDto>().ReverseMap();
            
        }

    }
}
