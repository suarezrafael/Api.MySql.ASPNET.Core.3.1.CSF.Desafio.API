using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSF.Desafio.API.Entities
{
    /// <summary>
    /// TB_CLIENTE_ENDERECO
    /// </summary>
    [Table("TB_CLIENTE_ENDERECO")]
    public class ClienteEndereco
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TB_CLIENTE_ID")]
        public int ClienteId { get; set; }
        [Column("TB_ENDERECO_ID")]
        public int EnderecoId { get; set; }
        
        public Cliente Cliente { get; set; } = null!;
        public Endereco Endereco{ get; set; } = null!;
    }
}
