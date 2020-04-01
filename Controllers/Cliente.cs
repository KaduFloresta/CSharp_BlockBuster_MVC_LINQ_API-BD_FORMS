using System;
using Models;
using System.Collections.Generic;

namespace Controllers
{

    public class ClienteController
    {
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

        // Adição de Locações
        public string getCliente(ClienteModels cliente)
        {
            string clienteValue = cliente.ToString();

            clienteValue += $"-> QTDE LOCAÇÕES: {this.getLocacoes(cliente)}\n";
            clienteValue += "----------------------------------------";

            return clienteValue;
        }

        // Retorno da Quantidade de Locações por Cliente
        public int getLocacoes(ClienteModels cliente)
        {
            int qtd = 0;

            foreach (LocacaoModels locacao in cliente.locacoes)
            {
                foreach (FilmeModels filme in locacao.filmes)
                {
                    qtd++;
                }
            }

            return qtd;
        }

        // Retorno do Cliente pelo ID 
        public static ClienteModels GetCliente(int idCliente)
        {
            return ClienteModels.GetCliente(idCliente);
        }

        // Retorno da Lista de Clientes
        public static List<ClienteModels> GetClientes()
        {
            return ClienteModels.GetClientes();
        }
    }
}