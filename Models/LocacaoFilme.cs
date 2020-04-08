using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class LocacaoFilmeModels
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("locacoes")]
        public int IdLocacao { get; set; }
        public virtual LocacaoModels Locacao { get; set; }
        [ForeignKey("filmes")]
        public int IdFilme { get; set; }
        public virtual FilmeModels Filme { get; set; }

    }
}