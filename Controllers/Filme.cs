using System;
using Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controllers
{
    public class FilmeController
    {
        /// <summary>
        /// Insert movie into the database
        /// <summary>
        public static void CadastrarFilme(
            string titulo,
            int dataLancDia,
            int dataLancMes,
            int dataLancAno,
            string sinopse,
            double valorLocacaoFilme,
            int estoqueFilme
        )
        {
            string dataLancamento = "" + dataLancDia + "/" + dataLancMes + "/" + dataLancAno;
            DateTime dtLanc;
            try
            {
                dtLanc = Convert.ToDateTime(dataLancamento);
            }
            catch
            {
                Console.WriteLine("FORMATO iNVÁLIDO!");
                dtLanc = DateTime.Now;
            }
            new FilmeModels(
                titulo,
                dataLancamento,
                sinopse,
                valorLocacaoFilme,
                estoqueFilme
            );
        }

        /// <summary>
        /// Access all movies
        /// </summary>
        public static List<FilmeModels> GetFilmes()
        {
            return FilmeModels.GetFilmes();
        }

        /// <summary>
        ///  Access to find a movie by ID
        /// </summary>
        public static FilmeModels GetFilme(int idFilme)
        {
            return FilmeModels.GetFilme(idFilme);
        }

        /// <summary>
        /// Access to Update movie
        /// </summary>
        public static void UpdateFilme(
            int idFilme,
            string titulo,
            int day,
            int month, 
            int year, 
            string sinopse,
            double valorLocacaoFilme,
            int estoqueFilme
            )
        {
            string dataLancamento = "" + day + "/" + month + "/" + year;
            FilmeModels.Updatefilme(
            idFilme, 
            titulo, 
            dataLancamento,
            sinopse,
            valorLocacaoFilme,
            estoqueFilme
            );
        }

        /// <summary>
        /// Access to Delete movie
        /// </summary>
        public static FilmeModels DeleteFilme()
        {
            return DeleteFilme();
        }
    }
}