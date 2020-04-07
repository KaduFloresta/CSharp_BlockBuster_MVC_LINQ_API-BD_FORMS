using System;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class FilmeController
    {
        // Adição de Filme
        public static void CadastrarFilme(
            string titulo,
            string dataLancamento,
            string sinopse,
            double valorLocacaoFilme,
            int estoqueFilme
        )
        {
            DateTime dtLancamento;
            try
            {
                dtLancamento = Convert.ToDateTime(dataLancamento);
            }
            catch
            {
                Console.WriteLine("FORMATO iNVÁLIDO!");
                dtLancamento = DateTime.Now;
            }
            new FilmeModels(
                titulo,
                dataLancamento,
                sinopse,
                valorLocacaoFilme,
                estoqueFilme
            );
        }

        // Retorno da Lista de Filmes
        public static List<FilmeModels> GetFilmes()
        {
            return FilmeModels.GetFilmes();
        }
    }
}