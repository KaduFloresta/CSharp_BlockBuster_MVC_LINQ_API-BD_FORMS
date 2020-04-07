using System;
using Models;
using Controllers;
using System.Linq;
using System.Collections;

namespace View
{
    public class ClienteView
    {
        // Criação do Cliente
        public static void CadastrarCliente()
        {
            Console.WriteLine("---===[ CADASTRO DO CLIENTE ]===---");
            Console.WriteLine("Nome: ");
            string nomeCliente = Console.ReadLine();
            Console.WriteLine("\nData de Nascimento (dd/mm/yyyy): ");
            string dataNascimento = Console.ReadLine();
            Console.WriteLine("\nC.P.F.: ");
            string cpfCLiente = Console.ReadLine();
            Console.WriteLine("\nDias P/ Devolução: ");
            int diasDevolucao = Convert.ToInt32(Console.ReadLine());

            ClienteController.CadastrarCliente(nomeCliente, dataNascimento, cpfCLiente, diasDevolucao);
        }

        // Lista de Clientes Cadastrados
        public static void ListarClientes()
        {
            Console.WriteLine("=================[ LISTA DE CLIENTES ]=================");
            ClienteController.GetClientes().ForEach(filme => Console.WriteLine(filme));
        }

        // Consulta Cliente pelo ID via LINQ
        public static void ConsultarCliente()
        {
            Console.WriteLine("Digite o ID do Cliente: ");
            int idCliente = Convert.ToInt32(Console.ReadLine());
            try
            {
                ClienteModels cliente =
                (from cliente1 in ClienteController.GetClientes()
                 where cliente1.IdCliente == idCliente
                 select cliente1).First();


                Console.WriteLine("=================[ CONSULTA CLIENTE ]==================");
                Console.WriteLine(cliente.ToString());
            }
            catch
            {
                Console.WriteLine("==> CLIENTE NÃO EXISTE!");
            }
        }
    }
}