using System;
using Models;
using Controllers;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace View
{
    public class LocacaoView
    {
        // Listando os CLientes da Lista
        public static void ListarLocacao()
        {
            Console.WriteLine("\n===================[ LISTA LOCAÇÕES ]==================");
            List<LocacaoModels> locacoes = LocacaoController.GetLocacao();

            locacoes.ForEach(locacao => Console.WriteLine(locacao));
        }

        // Adicionando Locação na Lista pelo ID do CLiente
        public static void CadastrarLocacao()
        {
            Console.WriteLine("---===[ CADASTRO DA LOCAÇÃO ]===---");
            List<ClienteModels> clientes = ClienteController.GetClientes();
            List<FilmeModels> filmes = FilmeController.GetFilmes();

            int idCliente = 0;

            Console.WriteLine("\nDigite o ID Cliente:");
            idCliente = Convert.ToInt32(Console.ReadLine());

            if (idCliente <= 5)
            {
                ClienteModels cliente = clientes.Find(cliente => cliente.IdCliente == idCliente);
                LocacaoModels locacao = LocacaoController.addLocacao(cliente);

                int idFilme = 0;

                // Eqto IdFilme não for ZERO continua adicionando Locação                           
                do
                {
                    Console.WriteLine("\nDigite o ID Filme: ");
                    Console.WriteLine("DIGITE ZERO (0) P/ FINALIZAR!");
                    idFilme = Convert.ToInt32(Console.ReadLine());

                    if (idFilme != 0)
                    {
                        FilmeModels filme = filmes.Find(filme => filme.IdFilme == idFilme);

                        locacao.AdicionarFilme(filme);
                    }
                } while (idFilme != 0);
            }
        }

        // Consulta Locacao pelo ID via LINQ
        public static void ConsultarLocacao()
        {
            Console.WriteLine("Digite o ID da Locação: ");
            int idLocacao = Convert.ToInt32(Console.ReadLine());

            try
            {
                LocacaoModels locacao =
                (from locacao1 in LocacaoController.GetLocacao()
                 where locacao1.IdLocacao == idLocacao
                 select locacao1).First();

                Console.WriteLine("\n=================[ CONSULTA LOCAÇÕES ]=================");
                Console.WriteLine(locacao.ToString());
            }
            catch
            {
                Console.WriteLine("==> LOCAÇÃO NÃO EXISTE!");
            }
        }
    }
}