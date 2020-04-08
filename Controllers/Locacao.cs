using System;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class LocacaoController
    {
        // Adição da Locação
        public static LocacaoModels addLocacao(ClienteModels cliente)
        {
            return new LocacaoModels(cliente, DateTime.Now);
        }

        // Calculo Data de Devolução
        public static DateTime CalculoDataDevolucao(DateTime DtLocacao, ClienteModels Cliente)
        {
            return DtLocacao.AddDays(Cliente.DiasDevolucao);
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