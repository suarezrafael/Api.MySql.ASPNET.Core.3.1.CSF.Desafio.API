using System;
using System.Collections.Generic;

namespace CSF.Desafio.API.Models
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CodEmpresa { get; set; }

        public ICollection<ClienteEnderecoDto> ClienteEnderecos { get; set; }
           = new List<ClienteEnderecoDto>();
    }
}
