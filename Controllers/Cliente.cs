using System;
using Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controllers
{
    public class ClienteController
    {
        /// <summary>
        /// Insert customer into the database
        /// </summary>
        public static void CadastrarCliente(
            string nomeCliente,
            int dataNascDia,
            int dataNascMes,
            int dataNascAno,
            string cpfCliente,
            int diasDevolucao
            )

        {
            string dataNascimento = "" + dataNascDia + "/" + dataNascMes + "/" + dataNascAno;
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
        public static List<ClienteModels> GetClientes()
        {
            return ClienteModels.GetClientes();
        }

        /// <summary>
        ///  Access to find a customer by ID
        /// </summary>
        public static ClienteModels GetCliente(int idCliente)
        {
            return ClienteModels.GetCliente(idCliente);
        }

        /// <summary>
        /// Access to Update customer
        /// </summary>
        public static void UpdateCliente(
            int idCliente,
            string nomeCliente,
            int day,
            int month,
            int year,
            string cpfCliente,
            int diasDevolucao
            )
        {
            string dataNascimento = "" + day + "/" + month + "/" + year;
            ClienteModels.UpdateCliente(
            idCliente,
            nomeCliente,
            dataNascimento,
            cpfCliente,
            diasDevolucao
            );
        }

        /// <summary>
        /// Access to Delete customer
        /// </summary>
        public static void DeleteCliente(int idCliente)
        {
            if (LocacaoController.GetLocacoesByCliente(idCliente).Count > 0)
            {
                throw new Exception("Esse Cliente Possui Locações!");
            }
            ClienteModels.DeleteCliente(idCliente);
        }
    }
}