using System.Linq;
using DbRespositorie;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ClienteModels
    {
        // Atributos
        [Key]
        public int IdCliente { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public string DataNascimento { get; set; }
        [Required]
        public string CpfCliente { get; set; }
        [Required]
        public int DiasDevolucao { get; set; }

        public List<LocacaoModels> locacoes = new List<LocacaoModels>();

        // Construtor
        public ClienteModels(string nomeCliente, string dataNascimento, string cpfCliente, int diasDevolucao)
        {
            NomeCliente = nomeCliente;
            DataNascimento = dataNascimento;
            CpfCliente = cpfCliente;
            DiasDevolucao = diasDevolucao;
            locacoes = new List<LocacaoModels>();

            var db = new Context();
            db.Clientes.Add(this);
            db.SaveChanges();
        }

        public ClienteModels()
        {

        }

        // Retorno do Cliente pelo ID
        public static ClienteModels GetCliente(int idCliente)
        {
            var db = new Context();
            return (from cliente in db.Clientes
            where cliente.IdCliente == idCliente
            select cliente).First();
        }

        // Método com a Quantidade de Filmes Locados
        public int QtdeFilmesLocadosCliente()
        {
            return locacoes.Count;
        }

        // Impressão Dados do Cliente
        public override string ToString()
        {
            return $"-------------------===[ CLIENTE ]===-------------------\n" +
                    $"--> Nº ID DO CLIENTE: {IdCliente}\n" +
                    $"-> NOME COMPLETO: {NomeCliente}\n" +
                    $"-> DATA DE NASCIMENTO: {DataNascimento}\n" +
                    $"-> CPF: {CpfCliente}\n" +
                    $"-> DIAS P/ DEVOLUÇÃO: {DiasDevolucao}\n" +
                    $"-------------------------------------------------------";
        }

        // Adição de Locações
        public void AdicionarLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao);
        }

        // Retorno da Lista de Cliente
        public static List<ClienteModels> GetClientes()
        {
            var db = new Context();
            return db.Clientes.ToList();
        }
    }
}