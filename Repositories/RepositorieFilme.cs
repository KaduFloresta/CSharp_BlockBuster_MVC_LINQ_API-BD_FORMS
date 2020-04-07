using Models;
using System.Collections.Generic;

namespace Repositories
{
    public class FilmeRepositories
    {
        //Lista de Filmes
        public static List<FilmeModels> filmes = new List<FilmeModels>();

        // Retorno dos Filmes da Lista
        public static List<FilmeModels> Filmes()
        {
            return filmes;
        }

        public static void AddFilme(FilmeModels Filme)
        {
            filmes.Add(Filme);
        }

        // Soma 1 a cada Filme adicionado
        public static int GetId()
        {
            return filmes.Count + 1;
        }
    }
}