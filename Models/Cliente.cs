using System.Linq;
using DbRespositorie;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ClienteModels
    {
        /* 
            Getters and Setters 
        */

        /// <value> Get and Set the value of IdCliente </value>
        [Key] // Data Annotations - Main key
        public int IdCliente { get; set; }
        /// <value> Get and Set the value of NomeCliente </value>
        [Required] // Mandatory data entry
        public string NomeCliente { get; set; }
        /// <value> Get and Set the value of DataNascimento </value>
        [Required]
        public string DataNascimento { get; set; }
        /// <value> Get and Set the value of CpfCliente </value>
        [Required]
        public string CpfCliente { get; set; }
        /// <value> Get and Set the value of DiasDevolucao </value>
        [Required]
        public int DiasDevolucao { get; set; }
        /// <value> Get and Set the value of locacoes </value>
        public List<LocacaoModels> locacoes = new List<LocacaoModels>();

        /// <summary>
        /// Constructor - ClienteModels Object
        /// </summary>
        /// <param name="nomeCliente"></param>
        /// <param name="dataNascimento"></param>
        /// <param name="cpfCliente"></param>
        /// <param name="diasDevolucao"></param>
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

        // <summary>
        /// 2nd Constructor - ClienteModels Object
        /// </summary>
        public ClienteModels()
        {

        }

        /// <summary>
        ///  To find a customer (LinQ)
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public static ClienteModels GetCliente(int idCliente)
        {
            var db = new Context();
            return (from cliente in db.Clientes
                    where cliente.IdCliente == idCliente
                    select cliente).First();
        }

        /// <summary>
        ///  String convertion 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Add rent
        /// </summary>
        /// <param name="locacao"></param>
        public void AdicionarLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao);
        }     

        /// <summary>
        /// Return customer list from DB
        /// </summary>
        /// <returns></returns>
        public static List<ClienteModels> GetClientes()
        {
            var db = new Context();
            return db.Clientes.ToList();
        }
    }
}