using CSF.Desafio.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSF.Desafio.API.Models
{
    public class EnderecoDto
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }

        /// <summary>
        ///  1 – Endereço Residencial
        ///  2 – Endereço Comercial 
        ///  3 – Outros
        /// </summary>
        public int TipoEndereco { get; set; }

        public CidadeDto Cidade { get; set; }
        public int CidadeId { get; set; }

    }
}
