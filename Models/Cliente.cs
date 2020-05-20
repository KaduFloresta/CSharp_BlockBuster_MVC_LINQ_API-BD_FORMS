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
        /// <summary>
        /// 2nd Constructor - ClienteModels Object
        /// Using on Entity Framework DONT REMOVE!!!
        /// </summary>
        public ClienteModels()
        {

        }

        /// <summary>
        ///  To find a customer (LinQ)
        /// </summary>
        public static ClienteModels GetCliente(int idCliente)
        {
            var db = new Context();
            return (from cliente in db.Clientes
                    where cliente.IdCliente == idCliente
                    select cliente).First();
        }

        /// <summary>
        /// Add rent
        /// </summary>
        public void AdicionarLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao);
        }     

        /// <summary>
        /// Return customer list from DB
        /// </summary>
        public static List<ClienteModels> GetClientes()
        {
            var db = new Context();
            return db.Clientes.ToList();
        }
    }
}