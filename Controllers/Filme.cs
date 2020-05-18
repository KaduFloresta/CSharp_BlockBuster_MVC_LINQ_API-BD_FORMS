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
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="dataLancamento"></param>
        /// <param name="sinopse"></param>
        /// <param name="valorLocacaoFilme"></param>
        /// <param name="estoqueFilme"></param>
        public static void CadastrarFilme(
            string titulo,
            string dataLancamento,
            string sinopse,
            double valorLocacaoFilme,
            int estoqueFilme
        )
        {
            DateTime dtLancamento;
            try
            {
                dtLancamento = Convert.ToDateTime(dataLancamento);
            }
            catch
            {
                Console.WriteLine("FORMATO iNVÁLIDO!");
                dtLancamento = DateTime.Now;
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
        /// <returns></returns>
        public static List<FilmeModels> GetFilmes()
        {
            return FilmeModels.GetFilmes();
        }

        internal static void CadastrarFilme(RichTextBox rtxt_Titulo, NumericUpDown num_AnoLancamento, RichTextBox rtxt_Sinopse, ComboBox cb_ValorLocacao, NumericUpDown num_QtdeEstoque)
        {
            throw new NotImplementedException();
        }
    }
}