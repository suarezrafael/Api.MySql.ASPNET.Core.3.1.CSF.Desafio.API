using System.Collections.Generic;
using System;

namespace CSF.Desafio.API.Models
{
    public class ClienteForCreationDto
    {
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CodEmpresa { get; set; }
        public ICollection<EnderecoForCreationDto> Enderecos { get; set; }
          = new List<EnderecoForCreationDto>();
    }
}
