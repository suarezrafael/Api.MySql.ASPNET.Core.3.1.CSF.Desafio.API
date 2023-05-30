using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSF.Desafio.API.Entities
{
    /// <summary>
    /// TB_CLIENTE
    /// </summary>
    [Table("TB_CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("NOME")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("RG")] 
        public string Rg { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("CPF")] 
        public string Cpf { get; set; }

        [Required]
        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("TELEFONE")]
        public string Telefone { get; set; }

        
        [MaxLength(150)]
        [Column("EMAIL")]
        public string Email { get; set; }

        /// <summary>
        /// 1 – Carrefour
        /// 2 – Atacadão
        /// </summary>
        [Required]
        [Column("COD_EMPRESA")]
        public int CodEmpresa { get; set; }

        public ICollection<ClienteEndereco> ClienteEnderecos { get; set; }
            = new List<ClienteEndereco>();
    }
}
