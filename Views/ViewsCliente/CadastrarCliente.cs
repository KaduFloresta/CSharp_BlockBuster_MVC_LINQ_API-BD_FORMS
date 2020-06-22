using System;
using Models;
using Controllers;
using System.Windows.Forms;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public partial class CadastroCliente : Form
    {
        ClienteModels cliente;
        public CadastroCliente(Form parent, int id = 0)
        {
            try
            {
                cliente = ClienteController.GetCliente(id);
            }
            catch
            {

            }
            InitializeComponent(parent, id > 0);
        }

        /// <summary>
        /// Event data for number selection
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void num_DataNascimento_Enter(object sender, EventArgs e)
        {
            num_DataNascDia.Select(0, num_DataNascDia.Text.Length);
            num_DataNascMes.Select(0, num_DataNascMes.Text.Length);
            num_DataNascAno.Select(0, num_DataNascAno.Text.Length);
        }

        /// <summary>
        /// Event data button to enter information into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>//
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                if ((rtxt_NomeCliente.Text != string.Empty)
                && (num_DataNascDia.Value != 0)
                && (num_DataNascMes.Value != 0)
                && (mtxt_CpfCLiente.Text != string.Empty)
                && (cb_DiasDevol.Text != string.Empty))
                {
                    if (cliente == null)
                    {
                        ClienteController.CadastrarCliente(
                        rtxt_NomeCliente.Text,
                        (int)num_DataNascDia.Value,
                        (int)num_DataNascMes.Value,
                        (int)num_DataNascAno.Value,
                        mtxt_CpfCLiente.Text,
                        cb_DiasDevol.Text == "2 Dias"
                            ? 2
                            : cb_DiasDevol.Text == "3 Dias"
                                ? 3
                                : cb_DiasDevol.Text == "4 Dias"
                                    ? 4
                                    : cb_DiasDevol.Text == "5 Dias"
                                        ? 5
                                        : 10
                        );
                        MessageBox.Show("Cadastrado Com Sucesso!");

                    }
                    else
                    {
                        ClienteController.UpdateCliente(
                        cliente.IdCliente,
                        rtxt_NomeCliente.Text,
                        (int)num_DataNascDia.Value,
                        (int)num_DataNascMes.Value,
                        (int)num_DataNascAno.Value,
                        mtxt_CpfCLiente.Text,
                        cb_DiasDevol.Text == "2 Dias"
                            ? 2
                            : cb_DiasDevol.Text == "3 Dias"
                                ? 3
                                : cb_DiasDevol.Text == "4 Dias"
                                    ? 4
                                    : cb_DiasDevol.Text == "5 Dias"
                                        ? 5
                                        : 10
                        );
                        MessageBox.Show("Alteração Feita!");
                    }
                    this.Close();
                    this.parent.Show();
                }
                else
                {
                    MessageBox.Show("Preencha Todos Os Campos!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Preencha Todos Os Campos!");
            }
        }

        /// <summary>
        /// Event button to cancel and back to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            this.rtxt_NomeCliente.Text = cliente.NomeCliente;

            string iDate = cliente.DataNascimento;
            DateTime oDate = Convert.ToDateTime(iDate);

            this.num_DataNascDia.Value = oDate.Day;
            this.num_DataNascMes.Value = oDate.Month;
            this.num_DataNascAno.Value = oDate.Year;
            this.mtxt_CpfCLiente.Text = cliente.CpfCliente;
            this.cb_DiasDevol.SelectedValue = cliente.DiasDevolucao;
        }
    }
}