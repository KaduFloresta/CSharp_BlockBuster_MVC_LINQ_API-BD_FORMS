using System;
using System.Linq;
using Controllers;
using Repositories;
using DbRespositorie;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class LocacaoModels
    {
        // Atributos
        [Key]
        public int IdLocacao { get; set; }
        [Required]
        public ClienteModels Cliente { get; set; }
        [Required]
        public DateTime DataLocacao { get; set; }

        // Lista de Filmes da Locação
        public List<FilmeModels> filmes = new List<FilmeModels>();

        public LocacaoModels ()
        {
            
        }

        // Construtor
        public LocacaoModels(ClienteModels cliente, DateTime dataLocacao)
        {
            Cliente = cliente;
            DataLocacao = dataLocacao;
            filmes = new List<FilmeModels>();
            cliente.AdicionarLocacao(this);

            var db = new Context();
            db.Locacoes.Add(this);
            db.SaveChanges();
        }

        // Adição de Filmes
        public void AdicionarFilme(FilmeModels filme)
        {
            filmes.Add(filme);
            filme.AtribuirLocacao(this);
        }

        // Informações da Locação
        public override string ToString()
        {
            string retorno = Cliente +
                $"\n----------------===[ DADOS LOCAÇÃO ]===----------------\n" +
                $"-> PREÇO TOTAL DAS LOCAÇÕES: R$ {LocacaoController.PrecoTotalLocaçoes(this)}\n" +
                $"-> DATA DE DEVOLUÇÃO: {LocacaoController.CalculoDataDevolucao(this)}\n" +
                $"-> QTDE TOTAL DE FILMES: {LocacaoController.TotalFilmes(filmes)}\n" +
                $"-------------------------------------------------------\n\n" +
                $"===================[ FILMES LOCADOS ]==================\n";


            if (filmes.Count > 0)
            {
                filmes.ForEach(
                    filme => retorno +=
                    $"--> ID do Filme: {filme.IdFilme}  " +
                    $" Título: {filme.Titulo}\n"
                );
            }
            else
            {
                retorno += "    NÃO HÁ FILMES!";
            }
            return retorno +
            $"=======================================================\n";
        }

        // Retorno da Lista de Locações
        public static List<LocacaoModels> GetLocacao()
        {
            var db = new Context();
            return db.Locacoes.ToList();
        }
        // Retorno da Locação pelo ID
        public static LocacaoModels GetLocacao(int idLocacao)
        {
            var db = new Context();
            return (from locacao in db.Locacoes
            where locacao.IdLocacao == idLocacao
            select locacao).First();
        }
    }
}