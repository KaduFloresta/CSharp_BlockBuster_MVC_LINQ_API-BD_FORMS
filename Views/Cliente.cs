using System;
using Models;
using Controllers;
using System.Linq;
using System.Collections;

namespace View
{
    public class ClienteView
    {
        public static void CadastrarCliente()
        {
            Console.WriteLine("---===[ CADASTRO DO CLIENTE ]===---");
            Console.WriteLine("Nome: ");
            String nomeCliente = Console.ReadLine();
            Console.WriteLine("Data de Nascimento (dd/mm/yyyy): ");
            String dataNascimento = Console.ReadLine();
            Console.WriteLine("C.P.F.: ");
            String cpfCLiente = Console.ReadLine();
            Console.WriteLine("Dias P/ devolução: ");
            int diasDevolucao = Convert.ToInt32(Console.ReadLine());

            ClienteController.CadastrarCliente(nomeCliente, dataNascimento, cpfCLiente, diasDevolucao);
        }

        // Relação de Clientes da Lista
        public static void ListarClientes()
        {
            Console.WriteLine("=================[ LISTA DE CLIENTES ]=================");
            ClienteController.GetClientes().ForEach(filme => Console.WriteLine(filme));
        }

        // Teste Consulta LINQ
        public static void ConsultarCliente()
        {
            Console.WriteLine("Digite o ID do Cliente: ");
            int idCliente = Convert.ToInt32(Console.ReadLine());

            IEnumerable query =
            from cliente in ClienteController.GetClientes()
            where cliente.IdCliente == idCliente
            select cliente.ToString();

            foreach (string cliente in query)
            {
                Console.WriteLine("=================[ CONSULTA CLIENTE ]==================");
                Console.WriteLine(cliente.ToString());
            }
        }
    }
}