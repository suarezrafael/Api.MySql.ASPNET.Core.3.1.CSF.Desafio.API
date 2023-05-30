using CSF.Desafio.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSF.Desafio.API.Models
{
    public class ClienteEnderecoDto
    {
        public EnderecoDto Endereco { get; set; }

    }
}
