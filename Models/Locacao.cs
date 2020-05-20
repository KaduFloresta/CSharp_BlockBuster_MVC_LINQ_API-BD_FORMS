using System;
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

        /// <value> Get and Set the value of IdLocacao </value>
        [Key] // Data Annotations - Main key
        public int IdLocacao { get; set; }
        /// <value> Get and Set the value of Cliente </value>
        public ClienteModels Cliente { get; set; }
        /// <value> Get and Set the value of IdCliente </value>
        [ForeignKey("clientes")] // Data Annotations - Foreign Key
        public int IdCliente { get; set; }
        /// <value> Get and Set the value of DataLocacao </value>
        [Required] // Data Annotations - Mandatory data entry
        public DateTime DataLocacao { get; set; }

        /// <value> Get and Set the value of filmes </value>
        public List<FilmeModels> filmes = new List<FilmeModels>();

        /// <summary>
        /// Constructor - LocacaoModels Object
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="dataLocacao"></param>
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
        /// </summary>
        public LocacaoModels()
        {

        }

        /// <summary>
        /// Add movies
        /// </summary>
        /// <param name="filme"></param>
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
        /// String convertion
        /// </summary>
        /// <returns></returns>
        // public override string ToString()
        // {
        //     var db = new Context();

        //     IEnumerable<int> filmes =
        //     from filme in db.LocacaoFilme
        //     where filme.IdLocacao == IdLocacao
        //     select filme.IdFilme;

        //     ClienteModels cliente = ClienteModels.GetCliente(IdCliente);

        //     string retorno = cliente +
        //         $"\n----------------===[ DADOS LOCAÇÃO ]===----------------\n" +
        //         $"-> DATA DE LOCAÇÃO: {DataLocacao.ToString("dd/MM/yyyy")}\n" +
        //         $"-> DATA DE DEVOLUÇÃO: {LocacaoController.CalculoDataDevolucao(DataLocacao, cliente).ToString("dd/MM/yyyy")}\n" +
        //         $"-> QTDE TOTAL DE FILMES: {filmes.Count()}\n";


        //     double ValorTotal = 0;
        //     string strFilmes = "";

        //     if (filmes.Count() > 0)
        //     {
        //         foreach (int id in filmes)
        //         {
        //             FilmeModels filme = FilmeModels.GetFilme(id);
        //             strFilmes += filme;
        //             ValorTotal += filme.ValorLocacaoFilme;
        //         }
        //     }
        //     else
        //     {
        //         strFilmes += "    NÃO HÁ FILMES!";
        //     }

        //     retorno += $"-> PREÇO TOTAL DAS LOCAÇÕES: R$ {ValorTotal.ToString("C2")}\n" +
        //     $"-------------------------------------------------------\n\n" +
        //     $"===================[ FILMES LOCADOS ]==================\n";
    
        //     return retorno + strFilmes +

        //     $"=======================================================\n";
        // }

        /// <summary>
        /// To find a rent
        /// </summary>
        /// <returns></returns>
        public static List<LocacaoModels> GetLocacao()
        {
            var db = new Context();
            return db.Locacoes.ToList();
        }

        /// <summary>
        /// To find a rent by ID (LinQ)
        /// </summary>
        /// <param name="idLocacao"></param>
        /// <returns></returns>
        public static LocacaoModels GetLocacao(int idLocacao)
        {
            var db = new Context();
            return (from locacao in db.Locacoes
                    where locacao.IdLocacao == idLocacao
                    select locacao).First();
        }
    }
}