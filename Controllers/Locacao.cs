using System;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class LocacaoController
    {
        /// <summary>
        /// Add a rent
        /// </summary>        
        public static LocacaoModels Add(ClienteModels cliente)
        {
            return new LocacaoModels(cliente, DateTime.Now);
        }

        /// <summary>
        /// Return date calculation 
        /// </summary>
        public static DateTime CalculoDataDevolucao(DateTime DtLocacao, ClienteModels Cliente)
        {
            return DtLocacao.AddDays(Cliente.DiasDevolucao);
        }

        /// <summary>
        /// Access find a customer rental
        /// </summary>
        public static List<LocacaoModels> GetLocacoes() 
        {
        return LocacaoModels.GetLocacoes();
        }
        public static LocacaoModels GetLocacao(int idLocacao)
        {
            return LocacaoModels.GetLocacao(idLocacao);
        }
    }
}