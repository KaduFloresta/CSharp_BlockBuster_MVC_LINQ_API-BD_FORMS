using System;
using Controllers;
using Repositories;
using System.Collections.Generic;

namespace Models
{
    public class FilmeModels
    {
        // Atributos
        public int IdFilme { get; set; }
        public String Titulo { get; set; }
        public string DataLancamento { get; set; }
        public string Sinopse { get; set; }
        public double ValorLocacaoFilme { get; set; }
        public int EstoqueFilme { get; set; }
        public int FilmeLocado { get; set; }

        public List<LocacaoModels> locacoes = new List<LocacaoModels>();

        // Construtor
        public FilmeModels(string titulo, string dataLancamento, string sinopse, double valorLocacaoFilme, int estoqueFilme)
        {
            IdFilme = FilmeRepositories.GetId();
            Titulo = titulo;
            DataLancamento = dataLancamento;
            Sinopse = sinopse;
            ValorLocacaoFilme = valorLocacaoFilme;
            EstoqueFilme = estoqueFilme;
            FilmeLocado = 0;

            FilmeRepositories.filmes.Add(this);
        }

        public void AtribuirLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao);
        }

        // Retorno do Filme pelo ID
        public static FilmeModels GetFilme(int idFilme)
        {
            return FilmeRepositories.Filmes().Find(filme => filme.IdFilme == idFilme);
        }

        // Método com a Quantidade de locações Realizadas
        public void QtdeFilmeLocado()
        {
            EstoqueFilme -= 1;
            FilmeLocado += 1;
        }

        // Impressão Dados do Filme
        public override string ToString()
        {
            return $"------------------------===[ FILME ]===------------------------------------------------------------------------------------------------\n" +
                    $"--> Nº ID DO FILME: {IdFilme}\n" +
                    $"-> TÍTULO: {Titulo}\n" +
                    $"-> DATA DE LANÇAMENTO: {DataLancamento}\n" +
                    $"-> SINOPSE: {Sinopse}\n" +
                    $"-> VALOR DA LOCAÇÃO: {ValorLocacaoFilme.ToString("C")}\n" +
                    $"-> QTDE EM ESTOQUE: {EstoqueFilme}\n" +
                    $"-> QTDE DE LOCAÇÕES REALIZADAS: {FilmeLocado}\n" +
                    $"---------------------------------------------------------------------------------------------------------------------------------------";
        }

        // Retorno da Lista de Filmes
        public static List<FilmeModels> GetFilmes()
        {
            return Repositories.FilmeRepositories.filmes;
        }
    }
}