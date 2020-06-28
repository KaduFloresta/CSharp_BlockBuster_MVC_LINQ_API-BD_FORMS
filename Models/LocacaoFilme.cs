using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbRespositorie;

namespace Models
{
    /// <summary>
    /// 'N to N' relation class
    /// </summary>
    public class LocacaoFilmeModels
    {
        [Key] // Data Annotations - Main key
        public int Id { get; set; }
        [ForeignKey("locacoes")] // Data Annotations - Foreign Key
        public int IdLocacao { get; set; }
        public virtual LocacaoModels Locacao { get; set; }
        [ForeignKey("filmes")] // Data Annotations - Foreign Key
        public int IdFilme { get; set; }
        public virtual FilmeModels Filme { get; set; }

        /// <summary>
        /// Get movie rentals from the database
        /// </summary>
        /// <param name="IdFilme"></param>
        /// <returns></returns>
        public static List<LocacaoFilmeModels> GetLocacoesByFilme(int IdFilme)
        {
            var db = new Context();
            return (from locacao in db.LocacaoFilme
                    where locacao.IdFilme == IdFilme
                    select locacao).ToList();
        }

    }
}