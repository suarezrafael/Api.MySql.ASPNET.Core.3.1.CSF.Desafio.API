using AutoMapper;
using CSF.Desafio.API.Entities;
using Newtonsoft.Json.Linq;

namespace CSF.Desafio.API.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Entities.Endereco, Models.EnderecoDto>().ReverseMap();
            CreateMap<Models.EnderecoForCreationDto, Entities.Endereco>();
            //CreateMap<Models.EnderecoForUpdateDto, Entities.Endereco>();
            //CreateMap<Entities.Endereco, Models.EnderecoForUpdateDto>().ReverseMap();

         

        }

        
    }
}
