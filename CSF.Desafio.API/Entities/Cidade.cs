using CSF.Desafio.API.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSF.Desafio.API.Entities
{
    [Table("TB_CIDADE")]
    public class Cidade
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("NOME")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(2)]
        [Column("ESTADO")]
        public string Estado { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }
             = new List<Endereco>();
    }
}
