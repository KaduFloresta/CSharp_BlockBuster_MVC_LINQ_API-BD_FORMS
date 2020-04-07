using Models;
using System.Collections.Generic;

namespace Repositories
{
    public class ClienteRepositories
    {
        // Lista de CLientes
        public static List<ClienteModels> clientes = new List<ClienteModels>();
        
        // Retorno dos Clientes da Lista
        public static List<ClienteModels> Clientes()
        {
            return clientes;
        }

        public static void AddCliente(ClienteModels cliente)
        {
            clientes.Add(cliente);
        }

        // Soma 1 a cada Cliente adicionado
        public static int GetId()
        {
            return clientes.Count + 1;
        }
    }
}