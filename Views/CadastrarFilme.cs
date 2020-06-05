using System;
using Controllers;
using System.Drawing;
using System.Windows.Forms;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public class CadastroFilme : Form
    {
        Library.PictureBox pb_Cadastro;
        Library.Label lbl_Titulo;
        Library.Label lbl_DataLancamento;
        Library.Label lbl_Sinopse;
        Library.Label lbl_ValorLocacao;
        Library.Label lbl_QtdeEstoque;
        Library.ToolTip tt_Titulo;
        Library.ToolTip tt_Sinopse;
        Library.RichTextBox rtxt_Titulo;
        NumericUpDown num_DtLancDia;
        NumericUpDown num_DtLancMes;
        NumericUpDown num_DtLancAno;
        Library.RichTextBox rtxt_Sinopse;
        ComboBox cb_ValorLocacao;
        NumericUpDown num_QtdeEstoque;
        Library.Button btn_Confirmar;
        Library.Button btn_Cancelar;
        Form parent;

        // Movie data entry
        public CadastroFilme(Form parent)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 450);
            this.parent = parent;

            // PictureBox
            this.pb_Cadastro = new Library.PictureBox();
            this.pb_Cadastro.Location = new Point(0, 10);
            this.pb_Cadastro.Size = new Size(480, 100);
            this.pb_Cadastro.ClientSize = new Size(480, 80);
            this.pb_Cadastro.Load("./Views/assets/cadastra.jpg");
            this.Controls.Add(pb_Cadastro);

            // Label
            this.lbl_Titulo = new Library.Label();
            this.lbl_Titulo.Text = "Título :";
            this.lbl_Titulo.Location = new Point(20, 100);
            this.Controls.Add(lbl_Titulo);

            this.lbl_DataLancamento = new Library.Label();
            this.lbl_DataLancamento.Text = "Ano de Lançamento :";
            this.lbl_DataLancamento.Location = new Point(20, 140);
            this.Controls.Add(lbl_DataLancamento);

            this.lbl_Sinopse = new Library.Label();
            this.lbl_Sinopse.Text = "Sinopse :";
            this.lbl_Sinopse.Location = new Point(20, 180);
            this.Controls.Add(lbl_Sinopse);

            this.lbl_ValorLocacao = new Library.Label();
            this.lbl_ValorLocacao.Text = "Valor da Locação :";
            this.lbl_ValorLocacao.Location = new Point(20, 250);
            this.Controls.Add(lbl_ValorLocacao);

            this.lbl_QtdeEstoque = new Library.Label();
            this.lbl_QtdeEstoque.Text = "Quantidade Estoque :";
            this.lbl_QtdeEstoque.Location = new Point(20, 290);
            this.Controls.Add(lbl_QtdeEstoque);

            // Fill orientation tip
            this.tt_Titulo = new Library.ToolTip();

            // RichTextBox (Edited text)
            this.rtxt_Titulo = new Library.RichTextBox();
            this.tt_Titulo.SetToolTip(rtxt_Titulo, "Digite o título do filme");
            this.Controls.Add(rtxt_Titulo);

            // NumericUpDown
            this.num_DtLancDia = new NumericUpDown();
            this.num_DtLancDia.Location = new Point(150, 140);
            this.num_DtLancDia.Size = new Size(50, 20);
            this.num_DtLancDia.Enter += new EventHandler(this.num_DataLancamento_Enter);
            this.num_DtLancDia.Minimum = 0;
            this.num_DtLancDia.Maximum = 31;
            this.Controls.Add(num_DtLancDia);

            this.num_DtLancMes = new NumericUpDown();
            this.num_DtLancMes.Location = new Point(210, 140);
            this.num_DtLancMes.Size = new Size(50, 20);
            this.num_DtLancMes.Enter += new EventHandler(this.num_DataLancamento_Enter);
            this.num_DtLancMes.Minimum = 0;
            this.num_DtLancMes.Maximum = 12;
            this.Controls.Add(num_DtLancMes);

            this.num_DtLancAno = new NumericUpDown();
            this.num_DtLancAno.Location = new Point(270, 140);
            this.num_DtLancAno.Size = new Size(50, 20);
            this.num_DtLancAno.Enter += new EventHandler(this.num_DataLancamento_Enter);
            this.num_DtLancAno.Minimum = 1890;
            this.num_DtLancAno.Maximum = 2020;
            this.Controls.Add(num_DtLancAno);

            // Fill orientation tip
            this.tt_Sinopse = new Library.ToolTip();

            // RichTextBox (Edited text)
            this.rtxt_Sinopse = new Library.RichTextBox();
            this.rtxt_Sinopse.Location = new Point(150, 180);
            this.rtxt_Sinopse.Size = new Size(300, 50);
            this.tt_Sinopse.SetToolTip(rtxt_Sinopse, "Digite a sinopse completa");
            this.Controls.Add(rtxt_Sinopse);

            // ComboBox
            this.cb_ValorLocacao = new ComboBox();
            this.cb_ValorLocacao.Items.Add("R$ 0.99");
            this.cb_ValorLocacao.Items.Add("R$ 1.99");
            this.cb_ValorLocacao.Items.Add("R$ 2.99");
            this.cb_ValorLocacao.Items.Add("R$ 3.99");
            this.cb_ValorLocacao.Items.Add("R$ 4.99");
            this.cb_ValorLocacao.Items.Add("R$ 5.99");
            this.cb_ValorLocacao.AutoCompleteMode = AutoCompleteMode.Append;
            this.cb_ValorLocacao.Location = new Point(150, 250);
            this.cb_ValorLocacao.Size = new Size(150, 20);
            this.Controls.Add(cb_ValorLocacao);

            // NumericUpDown
            this.num_QtdeEstoque = new NumericUpDown();
            this.num_QtdeEstoque.Location = new Point(150, 290);
            this.num_QtdeEstoque.Size = new Size(50, 20);
            this.num_QtdeEstoque.Minimum = 1;
            this.num_QtdeEstoque.Maximum = 100;
            this.Controls.Add(num_QtdeEstoque);

            // Buttons
            this.btn_Confirmar = new Library.Button();
            this.btn_Confirmar.Location = new Point(80, 330);
            this.btn_Confirmar.Text = "CONFIRMAR";
            this.btn_Confirmar.Click += new EventHandler(this.btn_ConfirmarClick);
            this.Controls.Add(btn_Confirmar);

            this.btn_Cancelar = new Library.Button();
            this.btn_Cancelar.Location = new Point(260, 330);
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.Click += new EventHandler(this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
        }

        /// <summary>
        /// Event data for number selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void num_DataLancamento_Enter(object sender, EventArgs e)
        {
            num_DtLancDia.Select(0, num_DtLancDia.Text.Length);
            num_DtLancMes.Select(0, num_DtLancMes.Text.Length);
            num_DtLancAno.Select(0, num_DtLancAno.Text.Length);
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
                && (num_DtLancDia.Value != 0)
                && (num_DtLancMes.Value != 0)
                && (rtxt_Sinopse.Text != string.Empty)
                && (cb_ValorLocacao.Text != string.Empty)
                && (num_QtdeEstoque.Value != 0))
                {
                    FilmeController.CadastrarFilme(
                        rtxt_Titulo.Text,
                        (int)num_DtLancDia.Value,
                        (int)num_DtLancMes.Value,
                        (int)num_DtLancAno.Value,
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
                    MessageBox.Show("CADASTRADO!");
                    this.Close();
                    this.parent.Show();
                }
                else
                {
                    MessageBox.Show("PREENCHA TODOS OS CAMPOS!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "PREENCHA TODOS OS CAMPOS!");
            }
        }

        /// <summary>
        /// Event button to cancel and back to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CancelarClick(object sender, EventArgs e)
        {
            // MessageBox.Show("CANCELADO!");
            this.Close();
            this.parent.Show();
        }
    }
}