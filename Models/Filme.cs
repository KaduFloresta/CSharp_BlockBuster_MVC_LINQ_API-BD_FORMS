using System;
using System.Linq;
using Repositories;
using DbRespositorie;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class FilmeModels
    {
        // Atributos
        [Key]
        public int IdFilme { get; set; }
        [Required]
        public String Titulo { get; set; }
        [Required]
        public string DataLancamento { get; set; }
        [Required]
        public string Sinopse { get; set; }
        [Required]
        public double ValorLocacaoFilme { get; set; }
        [Required]
        public int EstoqueFilme { get; set; }
        public int FilmeLocado { get; set; }

        public List<LocacaoModels> locacoes = new List<LocacaoModels>();

        public FilmeModels ()
        {
            
        }

        // Construtor
        public FilmeModels(string titulo, string dataLancamento, string sinopse, double valorLocacaoFilme, int estoqueFilme)
        {
            Titulo = titulo;
            DataLancamento = dataLancamento;
            Sinopse = sinopse;
            ValorLocacaoFilme = valorLocacaoFilme;
            EstoqueFilme = estoqueFilme;
            FilmeLocado = 0;

            var db = new Context();
            db.Filmes.Add(this);
            db.SaveChanges();
        }

        public void AtribuirLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao);
        }

        // Retorno do Filme pelo ID
        public static FilmeModels GetFilme(int idFilme)
        {
            var db = new Context();
            return (from filme in db.Filmes
            where filme.IdFilme == idFilme
            select filme).First();
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
            var db = new Context();
            return db.Filmes.ToList();
        }
    }
}