using System;
using View;

/**
 *  @author Kadu Floresta
 * 
 * 
*/

namespace Locadora_MVC_LinQ
{
    public class Principal
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("LOCADORA DE FILMES MVC - LinQ - API");

            // Menu Principal - Inserir - Consultar - Listar
            int menu = 0;
            do
            {
                // Mostrar Opções do Menu
                Console.WriteLine("\n|***********************************|");
                Console.WriteLine("|=============[ MENU ]==============|");
                Console.WriteLine("|***********************************|");
                Console.WriteLine("|---|------===[ CLIENTE ]===--------|");
                Console.WriteLine("| 1 | >>> Cadastrar Cliente         |");
                Console.WriteLine("| 2 | >>> Consultar Cliente         |");
                Console.WriteLine("| 3 | >>> Listar Clientes           |");
                Console.WriteLine("|---|-------===[ FILME ]===---------|");
                Console.WriteLine("| 4 | >>> Cadastrar Filme           |");
                Console.WriteLine("| 5 | >>> Consultar Filme           |");
                Console.WriteLine("| 6 | >>> Listar Filmes             |");
                Console.WriteLine("|---|------===[ LOCAÇÃO ]===--------|");
                Console.WriteLine("| 7 | >>> Cadastrar Locação         |");
                Console.WriteLine("| 8 | >>> Consultar Locação         |");
                Console.WriteLine("| 9 | >>> Listar Locações           |");
                Console.WriteLine("| 0 | >>> SAIR                      |");
                Console.WriteLine("|---|-------------------------------|");
                Console.WriteLine("|***********************************|");

                Console.WriteLine("\nDigite a Opção: ");
                try
                {
                    menu = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA!");
                    menu = 99;
                }

                // Seleção das Opções do Menu
                switch (menu)
                {
                    case 1: // Adicionar CLiente
                        ClienteView.CadastrarCliente();
                        break;
                    case 2: // Consultar Cliente pelo ID
                        ClienteView.ConsultarCliente();
                        break;
                    case 3: // Listar Todos os Clientes 
                        ClienteView.ListarClientes();
                        break;
                    case 4: // Adicionar Filme
                        FilmeView.CadastrarFilme();
                        break;
                    case 5: // Consultar Filme pelo ID
                        FilmeView.ConsultarFilme();
                        break;
                    case 6: // Listar Todos os Filmes
                        FilmeView.ListarFilmes();
                        break;
                    case 7: // Adicionar Locacao
                        LocacaoView.CadastrarLocacao();
                        break;
                    case 8: // Consultar Locação pelo ID
                        LocacaoView.ConsultarLocacao();
                        break;
                    case 9: // Lista de Todas as Locação
                        LocacaoView.ListarLocacao();
                        break;
                }
            } while (menu != 0);

        }
    }
}
