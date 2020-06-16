using System;
using Models;
using System.Drawing;
using System.Windows.Forms;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_IF
{
    public partial class FilmeDetalhe : Form
    {
        public FilmeDetalhe(Form parent, FilmeModels filme)
        {
            InitializeComponent(parent, filme);
        }

        /// <summary>
        /// Event button to exit and back to movie "consult" window
        /// </summary
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SairDetalheClick(object sender, EventArgs e)
        {
            // MessageBox.Show ("CONCLUÍDO!");
            this.Close();
            this.parent.Show();
        }

        /// <summary>
        /// Event button to acess update interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpdateFilmeClick(object sender, EventArgs e)
        {
            CadastroFilme btn_UpdateFilmeClick = new CadastroFilme(this, idFilme);
            btn_UpdateFilmeClick.Show();
            this.Close();
        }

        /// <summary>
        /// Event button to customer delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteFilmeClick(object sender, EventArgs e)
        {
            MessageBox.Show("TESTE!");
        }
    }
}