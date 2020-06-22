using System;
using System.Linq;
using DbRespositorie;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class FilmeModels
    {
        /* 
            Getters and Setters 
        */
        [Key] // Data Annotations - Main key
        public int IdFilme { get; set; }
        [Required] // Data Annotations - Mandatory data entry
        public string Titulo { get; set; }
        [Required]
        public string DataLancamento { get; set; }
        [Required]
        public string Sinopse { get; set; }
        [Required]
        public double ValorLocacaoFilme { get; set; }
        [Required]
        public int EstoqueFilme { get; set; }
        public int FilmeLocado { get; set; }
        public List<LocacaoModels> locacoes = new List<LocacaoModels>();

        /// <summary>
        /// Constructor - FilmeModels Object
        /// </summary>
        public FilmeModels(string titulo, string dataLancamento, string sinopse, double valorLocacaoFilme, int estoqueFilme)
        {
            Titulo = titulo;
            DataLancamento = dataLancamento;
            Sinopse = sinopse;
            ValorLocacaoFilme = valorLocacaoFilme;
            EstoqueFilme = estoqueFilme;
            FilmeLocado = 0;

            var db = new Context();
            db.Filmes.Add(this);
            db.SaveChanges();
        }

        /// <summary>
        /// 2nd Constructor - FilmeModels Object
        /// Using on Entity Framework DONT REMOVE!!!
        /// </summary>
        public FilmeModels()
        {

        }

        /// <summary>
        /// To find a movie (LinQ)
        /// </summary>
        /// <param name="idFilme"></param>
        /// <returns></returns>
        public static FilmeModels GetFilme(int idFilme)
        {
            var db = new Context();
            return (from filme in db.Filmes
                    where filme.IdFilme == idFilme
                    select filme).First();
        }

        /// <summary>
        /// Add rent
        /// </summary>
        /// <param name="locacao"></param>
        public void AtribuirLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao);
        }

        /// <summary>
        /// Return movies list from DB
        /// </summary>
        /// <returns></returns>
        public static List<FilmeModels> GetFilmes()
        {
            var db = new Context();
            return db.Filmes.ToList();
        }
        public static void Updatefilme(
            int idFilme,
            string titulo,
            string dataLancamento,
            string sinopse,
            double valorLocacaoFilme,
            int estoqueFilme
        )
        {
            Context db = new Context();
            try
            {
                FilmeModels filme = db.Filmes.First(filme => filme.IdFilme == idFilme);
                filme.Titulo = titulo;
                filme.DataLancamento = dataLancamento;
                filme.Sinopse = sinopse;
                filme.ValorLocacaoFilme = valorLocacaoFilme;
                filme.EstoqueFilme = estoqueFilme;
                db.SaveChanges(); // Cria a transação do BD
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Delete movie into the database
        /// </summary>
        public static void DeleteFilme(int idFilme)
        {
            Context db = new Context();
            try
            {
                FilmeModels filme = db.Filmes.First(filme => filme.IdFilme == idFilme);
                db.Remove(filme);
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // List<LocacaoModels> locacoes = db.Locacoes.TakeWhile(locacao => locacao.IdFilme == idFilme).ToList();
                    // locacoes.ForEach(locacao => db.Remove(locacao));
                    // db.SaveChanges();
                    throw new ArgumentException();
                }
            }
            catch
            {
                throw new ArgumentException();
            }
        }
    }
}