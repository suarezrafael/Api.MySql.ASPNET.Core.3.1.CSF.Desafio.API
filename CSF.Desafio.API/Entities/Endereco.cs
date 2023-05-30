using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSF.Desafio.API.Entities
{
    [Table("TB_ENDERECO")]
    public class Endereco
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("RUA")]
        public string Rua { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("BAIRRO")]
        public string Bairro { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("NUMERO")]
        public string Numero { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("CEP")]
        public string Cep { get; set; }

        /// <summary>
        ///  1 – Endereço Residencial
        ///  2 – Endereço Comercial 
        ///  3 – Outros
        /// </summary>
        [Column("TIPO_ENDERECO")]
        public int TipoEndereco { get; set; }

        //public ICollection<Cliente> Clientes{ get; set; }
        //     = new List<Cliente>();
        public ICollection<ClienteEndereco> ClienteEnderecos { get; set; }
             = new List<ClienteEndereco>();

        public Cidade Cidade { get; set; }

        [Column("TB_CIDADE_ID")]
        public int CidadeId { get; set; }
    }
}
