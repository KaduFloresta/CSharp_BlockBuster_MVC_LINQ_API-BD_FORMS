using System;
using Models;
using System.Windows.Forms;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public partial class LocacaoDetalhe : Form
    {
        public LocacaoDetalhe(Form parent, LocacaoModels locacao)
        {
            InitializeComponent(parent, locacao);
        }

        /// <summary>
        /// Event button to exit and back to rental "consult" window
        /// </summary>
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
        private void btn_UpdateLocacaoClick(object sender, EventArgs e)
        {
            MessageBox.Show("TESTE!");
        }

        /// <summary>
        /// Event button to movie delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteLocacaoClick(object sender, EventArgs e)
        {
            MessageBox.Show("TESTE!");
        }
    }
}