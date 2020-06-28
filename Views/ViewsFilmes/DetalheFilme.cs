using System;
using Models;
using Controllers;
using System.Windows.Forms;

namespace Locadora_MVC_LINQ_API_BD_Interface
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
        }

        /// <summary>
        /// Event button to customer delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteFilmeClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir Esse Filme?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    FilmeController.DeleteFilme(idFilme);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}