using System;
using System.Collections.Generic;
using Controllers;
using Repositories;

namespace Models
{
    public class LocacaoModels
    {
        // Atributos
        public int IdLocacao { get; set; }
        public ClienteModels Cliente { get; set; }
        public DateTime DataLocacao { get; set; }

        // Lista de Filmes da Locação
        public List<FilmeModels> filmes = new List<FilmeModels>();

        // Construtor
        public LocacaoModels(ClienteModels cliente, DateTime dataLocacao)
        {
            IdLocacao = LocacaoRepositories.GetId();
            Cliente = cliente;
            DataLocacao = dataLocacao;
            filmes = new List<FilmeModels>();
            cliente.AdicionarLocacao(this);

            Repositories.LocacaoRepositories.AdicionarLocacao(this);
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
                retorno += "    Não há filmes";
            }

            return retorno;
        }

        // Retorno da Lista de Locações
        public static List<LocacaoModels> GetLocacao()
        {
            return LocacaoRepositories.Locacoes();
        }
        // Retorno da Locação pelo ID
        public static LocacaoModels GetLocacao(int idLocacao)
        {
            return LocacaoRepositories.Locacoes().Find(locacao => locacao.IdLocacao == idLocacao);
        }
    }
}