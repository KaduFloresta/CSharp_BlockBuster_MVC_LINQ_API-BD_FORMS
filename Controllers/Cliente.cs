using System;
using Models;
using System.Collections.Generic;

namespace Controllers
{

    public class ClienteController
    {
        /// <summary>
        /// Insert customer into the database
        /// </summary>
        /// <param name="nomeCliente"></param>
        /// <param name="dataNascimento"></param>
        /// <param name="cpfCliente"></param>
        /// <param name="diasDevolucao"></param>
        public static void CadastrarCliente(
            string nomeCliente,
            string dataNascimento,
            string cpfCliente,
            int diasDevolucao
            )
        {
            DateTime dtNasc;
            try
            {
                dtNasc = Convert.ToDateTime(dataNascimento);
            }
            catch
            {
                Console.WriteLine("FORMATO INVÁLIDO!");
                dtNasc = DateTime.Now;
            }

            new ClienteModels(
                nomeCliente,
                dataNascimento,
                cpfCliente,
                diasDevolucao);
        }

        /// <summary>
        /// Access all customers
        /// </summary>
        /// <returns></returns>
        public static List<ClienteModels> GetClientes()
        {
            return ClienteModels.GetClientes();
        }
    }
}