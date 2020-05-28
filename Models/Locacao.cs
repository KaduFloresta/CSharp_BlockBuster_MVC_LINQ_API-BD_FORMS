using System;
using Models;
using System.Linq;
using Controllers;
using DbRespositorie;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class LocacaoModels
    {
        /* 
            Getters and Setters 
        */
        [Key] // Data Annotations - Main key
        public int IdLocacao { get; set; }
        
        public ClienteModels Cliente { get; set; }
        
        [ForeignKey("clientes")] // Data Annotations - Foreign Key
        public int IdCliente { get; set; }
        
        [Required] // Data Annotations - Mandatory data entry
        public DateTime DataLocacao { get; set; }
        
        public List<FilmeModels> filmes = new List<FilmeModels>();

        /// <summary>
        /// Constructor - LocacaoModels Object
        /// </summary>
        public LocacaoModels(ClienteModels cliente, DateTime dataLocacao)
        {
            IdCliente = cliente.IdCliente;
            DataLocacao = dataLocacao;
            filmes = new List<FilmeModels>();
            cliente.AdicionarLocacao(this);

            var db = new Context();
            db.Locacoes.Add(this);
            db.SaveChanges();
        }
        /// <summary>
        /// 2nd Constructor - LocacaoModels Object
        /// Using on Entity Framework DONT REMOVE!!!
        /// </summary>
        public LocacaoModels()
        {

        }

        /// <summary>
        /// Add movies
        /// </summary>
        public void AdicionarFilme(FilmeModels filme)
        {
            var db = new Context();
            LocacaoFilmeModels locacaoFilme = new LocacaoFilmeModels()
            {
                IdFilme = filme.IdFilme,
                IdLocacao = IdLocacao
            };

            db.LocacaoFilme.Add(locacaoFilme);
            db.SaveChanges();
        }

        /// <summary>
        /// Method of return day
        /// </summary>
        public string FilmesLocados () 
        {
            var db = new Context();
            IEnumerable<int> filmes =
            from filme in db.LocacaoFilme
            where filme.IdLocacao == IdLocacao
            select filme.IdFilme;

            string strFilmes = "";
            

            if (filmes.Count() > 0)
            {
                
                foreach (int IdFilme in filmes)
                {
                    // for (int i = 1; i <= filmes.Count(); i++)
                    // {
                    FilmeModels filme = FilmeController.GetFilme(IdFilme);
                    strFilmes += 
                                 //$"Filme #{i} >>> " +
                                 $"ID: {filme.IdFilme} >>> " +
                                 $"Título: {filme.Titulo}\n";
                    // }
                }
            }
            else
            {
                strFilmes += "    NÃO HÁ FILMES!";
            }
    
            return strFilmes;
        }

        /// <summary>
        /// Method of return day
        /// </summary>
        public DateTime CalculoDataDevol()
        {
            var db = new Context();
            IEnumerable<int> filmes =
            from filme in db.LocacaoFilme
            where filme.IdLocacao == IdLocacao
            select filme.IdFilme;

            ClienteModels cliente = ClienteModels.GetCliente(IdCliente);
            return LocacaoController.CalculoDataDevolucao(DataLocacao, cliente);
        }

        /// <summary>
        /// Method quantity of rented movies
        /// </summary>
        public int QtdeFilmes()
        {
            var db = new Context();
            IEnumerable<int> filmes =
            from filme in db.LocacaoFilme
            where filme.IdLocacao == IdLocacao
            select filme.IdFilme;

            ClienteModels cliente = ClienteModels.GetCliente(IdCliente);

            return filmes.Count();

        }

        /// <summary>
        /// Total rental amount method
        /// </summary>
        public double ValorTotal()
        {
            double total = 0;
            var db = new Context();
            IEnumerable<int> filmes =
            from filme in db.LocacaoFilme
            where filme.IdLocacao == IdLocacao
            select filme.IdFilme;

            foreach (int id in filmes)
            {
                FilmeModels filme = FilmeModels.GetFilme(id);
                total += filme.ValorLocacaoFilme;
            }
            return total;
        }

        /// <summary>
        /// To find a rent
        /// </summary>
        public static List<LocacaoModels> GetLocacoes()
        {
            var db = new Context();
            return db.Locacoes.ToList();
        }

        /// <summary>
        /// To find a rent by ID (LinQ)
        /// </summary>
        public static LocacaoModels GetLocacao(int idLocacao)
        {
            var db = new Context();
            return (from locacao in db.Locacoes
                    where locacao.IdLocacao == idLocacao
                    select locacao).First();
        }
    }
}