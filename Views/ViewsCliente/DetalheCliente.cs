using System;
using Models;
using Controllers;
using System.Windows.Forms;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public partial class ClienteDetalhe : Form
    {
        public ClienteDetalhe(Form parent, ClienteModels cliente)
        {
            InitializeComponent(parent, cliente);
        }

        /// <summary>
        /// Event button to exit and back to customer "consult" window
        /// </summary>
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
        private void btn_UpdateClienteClick(object sender, EventArgs e)
        {
            CadastroCliente btn_UpdateClienteClick = new CadastroCliente(this, idCliente);
            btn_UpdateClienteClick.Show();
        }

        /// <summary>
        /// Event button to movie delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteClienteClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir Esse Cliente?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    ClienteController.DeleteCliente(idCliente);
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