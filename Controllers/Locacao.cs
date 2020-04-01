using System;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class LocacaoController
    {
        // Adição da Locação
        public static LocacaoModels addLocacao(
            ClienteModels cliente
        )
        {
            return new LocacaoModels(cliente, DateTime.Now);
        }

        // Método com o Valor Total das Locações (Preço)
        public static double PrecoTotalLocaçoes(LocacaoModels locacao)
        {
            double ValorTotal = 0;

            locacao.filmes.ForEach(
                filme => ValorTotal += filme.ValorLocacaoFilme
            );
            return ValorTotal;
        }

        // Calculo Data de Devolução
        public static DateTime CalculoDataDevolucao(LocacaoModels locacao)
        {
            //Data.AddDays(ClienteModels.Dias);
            return locacao.DataLocacao.AddDays(locacao.Cliente.DiasDevolucao);
        }

        // Total de Filmes da Lista
        public static double TotalFilmes(List<FilmeModels> filmes)
        {
            return filmes.Count;
        }

        // Retorno da Lista de Locações
        public static List<LocacaoModels> GetLocacao()
        {
            return LocacaoModels.GetLocacao();
        }

        // Retorno da Locação pelo ID
        public static LocacaoModels GetLocacao(int idLocacao)
        {
            return LocacaoModels.GetLocacao(idLocacao);
        }
    }
}