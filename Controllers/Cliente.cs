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
        /// <param name="nomeCliente"></param>
        /// <param name="dataNascimento"></param>
        /// <param name="cpfCliente"></param>
        /// <param name="diasDevolucao"></param>
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
        /// <returns></returns>
        public static List<ClienteModels> GetClientes()
        {
            return ClienteModels.GetClientes();
        }

        internal static void CadastrarCliente(string text, decimal value1, decimal value2, decimal value3, MaskedTextBox mtxt_CpfCLiente, ComboBox cb_DiasDevol)
        {
            throw new NotImplementedException();
        }
    }
}