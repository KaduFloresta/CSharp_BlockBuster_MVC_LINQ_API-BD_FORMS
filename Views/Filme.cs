using System;
using Models;
using Controllers;
using System.Linq;
using System.Collections;

namespace View
{
    public class FilmeView
    {
        public static void CadastrarFilme()
        {
            Console.WriteLine("---===[ CADASTRO DO FILME ]===---");
            Console.WriteLine("Título: ");
            String titulo = Console.ReadLine();
            Console.WriteLine("Data de Lançamento (dd/mm/yyyy): ");
            String dataLancamento = Console.ReadLine();
            Console.WriteLine("Sinopse: ");
            String sinopse = Console.ReadLine();
            Console.WriteLine("Valor para Locação: ");
            double valorLocacaoFilme = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quantidade em Estoque: ");
            int estoqueFilme = Convert.ToInt32(Console.ReadLine());

            FilmeController.CadastrarFilme(
                titulo,
                dataLancamento,
                sinopse,
                valorLocacaoFilme,
                estoqueFilme
            );
        }

        public void getFilme(FilmeModels filmes)
        {
            Console.Write(filmes);
        }

        // Relação de Filmes da Lista
        public static void ListarFilmes()
        {
            Console.WriteLine("=====================[ LISTA DE FILMES ]===============================================================================================");
            FilmeController.GetFilmes().ForEach(filme => Console.WriteLine(filme));
        }

        //Teste Consulta LINQ
        public static void ConsultarFilme()
        {
            Console.WriteLine("Digite o ID do Filme: ");
            int idFilme = Convert.ToInt32(Console.ReadLine());

            IEnumerable query =
            from filme in FilmeController.GetFilmes()
            where filme.IdFilme == idFilme
            select filme.ToString();

            foreach (string filmes in query)
            {
                Console.WriteLine("=====================[ CONSULTA FILMES ]===============================================================================================");
                Console.WriteLine(filmes.ToString());
            }
        }
    }
}