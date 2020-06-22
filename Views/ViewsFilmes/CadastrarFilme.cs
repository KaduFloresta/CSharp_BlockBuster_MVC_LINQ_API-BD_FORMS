using System;
using Models;
using Controllers;
using System.Windows.Forms;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public partial class CadastroFilme : Form
    {
        FilmeModels filme;
        public CadastroFilme(Form parent, int id = 0)
        {
            try
            {
                filme = FilmeController.GetFilme(id);
            }
            catch
            {

            }
            InitializeComponent(parent, id > 0);
        }

        /// <summary>
        /// Event data for number selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void num_DataLancamento_Enter(object sender, EventArgs e)
        {
            num_DataLancDia.Select(0, num_DataLancDia.Text.Length);
            num_DataLancMes.Select(0, num_DataLancMes.Text.Length);
            num_DataLancAno.Select(0, num_DataLancAno.Text.Length);
        }

        /// <summary>
        /// Event data button to enter information into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                if ((rtxt_Titulo.Text != string.Empty)
                && (num_DataLancDia.Value != 0)
                && (num_DataLancMes.Value != 0)
                && (rtxt_Sinopse.Text != string.Empty)
                && (cb_ValorLocacao.Text != string.Empty)
                && (num_QtdeEstoque.Value != 0))
                {
                    if (filme == null)
                    {
                        FilmeController.CadastrarFilme(
                            rtxt_Titulo.Text,
                            (int)num_DataLancDia.Value,
                            (int)num_DataLancMes.Value,
                            (int)num_DataLancAno.Value,
                            rtxt_Sinopse.Text,
                            cb_ValorLocacao.Text == "R$ 0.99"
                            ? 0.99
                                : cb_ValorLocacao.Text == "R$ 1.99"
                                ? 1.99
                                    : cb_ValorLocacao.Text == "R$ 2.99"
                                    ? 2.99
                                    : cb_ValorLocacao.Text == "R$ 3.99"
                                        ? 3.99
                                        : cb_ValorLocacao.Text == "R$ 4.99"
                                            ? 4.99
                                            : 5.99,
                            (int)num_QtdeEstoque.Value
                        );
                        MessageBox.Show("Cadastrado Com Sucesso!");

                    }
                    else
                    {
                        FilmeController.UpdateFilme(
                            filme.IdFilme,
                             rtxt_Titulo.Text,
                             (int)num_DataLancDia.Value,
                             (int)num_DataLancMes.Value,
                             (int)num_DataLancAno.Value,
                             rtxt_Sinopse.Text,
                             cb_ValorLocacao.Text == "R$ 0.99"
                             ? 0.99
                                 : cb_ValorLocacao.Text == "R$ 1.99"
                                 ? 1.99
                                     : cb_ValorLocacao.Text == "R$ 2.99"
                                     ? 2.99
                                     : cb_ValorLocacao.Text == "R$ 3.99"
                                         ? 3.99
                                         : cb_ValorLocacao.Text == "R$ 4.99"
                                             ? 4.99
                                             : 5.99,
                             (int)num_QtdeEstoque.Value
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

        /// <summary>
        /// Event to customer update data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadForm(object sender, EventArgs e)
        {
            this.rtxt_Titulo.Text = filme.Titulo;

            string iDate = filme.DataLancamento;
            DateTime oDate = Convert.ToDateTime(iDate);

            this.num_DataLancDia.Value = oDate.Day;
            this.num_DataLancMes.Value = oDate.Month;
            this.num_DataLancAno.Value = oDate.Year;
            this.rtxt_Sinopse.Text = filme.Sinopse;
            this.cb_ValorLocacao.SelectedValue = filme.ValorLocacaoFilme;
        }
    }
}