using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSF.Desafio.API.Models
{
    public class ClienteForUpdateDto
    {
        [Required(ErrorMessage = "Nome deve ser informado.")]
        [MaxLength(100, ErrorMessage = "Nome nao deve ter mais que 100 caracteres.")]

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
