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

        /// <summary>
        /// Access find a customer rental by ID
        /// </summary>
        public static LocacaoModels GetLocacao(int idLocacao)
        {
            return LocacaoModels.GetLocacao(idLocacao);
        }

        /// <summary>
        /// Access to Update rental
        /// </summary>
        public static ClienteModels UpdateLocacao()
        {
            return UpdateLocacao();
        }

        /// <summary>
        /// Access to Delete customer
        /// </summary>
        public static void DeleteLocacao(int idLocacao)
        {
            LocacaoController.DeleteLocacao(idLocacao);
        }
    }
}