using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidade
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public short Situacao { get; set; }


        public Categoria Alteracao(string nome, short situacao)
        {
            Nome = nome;
            Situacao = situacao;

            return this;
        }

    }
}
