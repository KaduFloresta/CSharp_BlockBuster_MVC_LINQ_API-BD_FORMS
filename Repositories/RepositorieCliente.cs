using Models;
using System.Collections.Generic;

namespace Repositories
{
    public class ClienteRepositories
    {
        // Lista de CLientes
        public static List<ClienteModels> clientes = new List<ClienteModels>();


        /* Lista com 5 Clientes
        Adriano Medeiros Sá
        21/01/1978

        João Pedro Silva
        13/08/1945"

        Maria de Fátima Antunes
        02/12/2001

        Letícia Eugenia Soares
        11/02/1988"

        Belmiro Schmmitt
        15/07/1995
        */

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