using System;
using Repositories;
using System.Collections.Generic;

namespace Models
{
    public class ClienteModels
    {
        // Atributos
        public int IdCliente { get; set; }
        public String NomeCliente { get; set; }
        public String DataNascimento { get; set; }
        public String CpfCliente { get; set; }
        public int DiasDevolucao { get; set; }

        public List<LocacaoModels> locacoes = new List<LocacaoModels>();

        // Construtor
        public ClienteModels(string nomeCliente, string dataNascimento, string cpfCliente, int diasDevolucao)
        {
            IdCliente = ClienteRepositories.GetId();
            NomeCliente = nomeCliente;
            DataNascimento = dataNascimento;
            CpfCliente = cpfCliente;
            DiasDevolucao = diasDevolucao;
            locacoes = new List<LocacaoModels>();

            ClienteRepositories.clientes.Add(this);
        }

        // Retorno do Cliente pelo ID
        public static ClienteModels GetCliente(int idCliente)
        {
            return ClienteRepositories.Clientes().Find(cliente => cliente.IdCliente == idCliente);
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
            return Repositories.ClienteRepositories.clientes;
        }
    }
}