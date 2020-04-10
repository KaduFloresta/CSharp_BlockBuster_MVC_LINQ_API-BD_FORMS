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
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static LocacaoModels addLocacao(ClienteModels cliente)
        {
            return new LocacaoModels(cliente, DateTime.Now);
        }

        /// <summary>
        /// Return date calculation 
        /// </summary>
        /// <param name="DtLocacao"></param>
        /// <param name="Cliente"></param>
        /// <returns></returns>
        public static DateTime CalculoDataDevolucao(DateTime DtLocacao, ClienteModels Cliente)
        {
            return DtLocacao.AddDays(Cliente.DiasDevolucao);
        }

        /// <summary>
        /// Access find a customer rental
        /// </summary>
        /// <returns></returns>
        public static List<LocacaoModels> GetLocacao()
        {
            return LocacaoModels.GetLocacao();
        }
    }
}