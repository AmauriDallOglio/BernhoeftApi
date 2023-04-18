using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidade
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "numeric(12, 2)")]
        public decimal Preco { get; set; }
        [Required]
        public short Situacao { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public Produto()
        {

        }
 

    }
}
