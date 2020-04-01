using Models;
using System.Collections.Generic;

namespace Repositories
{
    public static class LocacaoRepositories
    {
        private static readonly List<Models.LocacaoModels> locacoes = new List<Models.LocacaoModels>();

        // Retorno dos Locações da Lista
        public static List<LocacaoModels> Locacoes()
        {
            return locacoes;
        }

        // Adiciona Locação 
        public static void AdicionarLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao);
        }

        // Soma 1 a cada Locação adicionado
        public static int GetId()
        {
            return locacoes.Count + 1;
        }
    }
}