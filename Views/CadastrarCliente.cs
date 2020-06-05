using System;
using Controllers;
using System.Drawing;
using System.Windows.Forms;
using static Locadora_MVC_LINQ_API_BD_IF.Program;


namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public class CadastroCliente : Form
    {
        Library.PictureBox pb_Cadastro;
        Library.ToolTip tt_Help;
        Library.Label lbl_Nome;
        Library.Label lbl_DataNasc;
        Library.Label lbl_CPF;
        Library.Label lbl_DiasDevol;
        Library.RichTextBox rtxt_NomeCliente;
        NumericUpDown num_DataNascDia;
        NumericUpDown num_DataNascMes;
        NumericUpDown num_DataNascAno;
        Library.MaskedTextBox mtxt_CpfCLiente;
        ComboBox cb_DiasDevol;
        Library.Button btn_Confirmar;
        Library.Button btn_Cancelar;
        Form parent;

        // Customer data entry
        public CadastroCliente(Form parent)
        {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 400);
            this.parent = parent;

            // PictureBox
            this.pb_Cadastro = new Library.PictureBox();
            this.pb_Cadastro.Location = new Point(0, 10);
            this.pb_Cadastro.Size = new Size(480, 100);
            this.pb_Cadastro.ClientSize = new Size(480, 80);
            this.pb_Cadastro.Load("./Views/assets/cadastra.jpg");
            this.Controls.Add(pb_Cadastro);

            // Fill orientation tip
            this.tt_Help = new Library.ToolTip();

            // Label
            this.lbl_Nome = new Library.Label();
            this.lbl_Nome.Text = "Nome :";
            this.lbl_Nome.Location = new Point(20, 100);
            this.Controls.Add(lbl_Nome);

            this.lbl_DataNasc = new Library.Label();
            this.lbl_DataNasc.Text = "Data de Nascimento :";
            this.lbl_DataNasc.Location = new Point(20, 140);
            this.Controls.Add(lbl_DataNasc);

            this.lbl_CPF = new Library.Label();
            this.lbl_CPF.Text = "CPF :";
            this.lbl_CPF.Location = new Point(20, 180);
            this.Controls.Add(lbl_CPF);

            this.lbl_DiasDevol = new Library.Label();
            this.lbl_DiasDevol.Text = "Dias P/ Devolução :";
            this.lbl_DiasDevol.Location = new Point(20, 220);
            this.Controls.Add(lbl_DiasDevol);

            // RichTextBox (Edited text)
            this.rtxt_NomeCliente = new Library.RichTextBox();
            this.tt_Help.SetToolTip(rtxt_NomeCliente, "Digite o nome completo");
            this.Controls.Add(rtxt_NomeCliente);

            // NumericUpDown
            this.num_DataNascDia = new NumericUpDown();
            this.num_DataNascDia.Location = new Point(150, 140);
            this.num_DataNascDia.Size = new Size(50, 20);
            this.num_DataNascDia.Enter += new EventHandler(this.num_DataNascimento_Enter);
            this.num_DataNascDia.Minimum = 0;
            this.num_DataNascDia.Maximum = 31;
            this.Controls.Add(num_DataNascDia);

            this.num_DataNascMes = new NumericUpDown();
            this.num_DataNascMes.Location = new Point(210, 140);
            this.num_DataNascMes.Size = new Size(50, 20);
            this.num_DataNascMes.Enter += new EventHandler(this.num_DataNascimento_Enter);
            this.num_DataNascMes.Minimum = 0;
            this.num_DataNascMes.Maximum = 12;
            this.Controls.Add(num_DataNascMes);

            this.num_DataNascAno = new NumericUpDown();
            this.num_DataNascAno.Location = new Point(270, 140);
            this.num_DataNascAno.Size = new Size(50, 20);
            this.num_DataNascAno.Enter += new EventHandler(this.num_DataNascimento_Enter);
            this.num_DataNascAno.Minimum = 1930;
            this.num_DataNascAno.Maximum = 2020;
            this.Controls.Add(num_DataNascAno);

            // MaskedTextBox
            this.mtxt_CpfCLiente = new Library.MaskedTextBox();
            this.mtxt_CpfCLiente.Mask = "000,000,000-00";
            this.Controls.Add(mtxt_CpfCLiente);
            //mtxt_CpfCLiente.SelectionStart = mtxt_CpfCLiente.Text.Length + 1;

            // ComboBox
            this.cb_DiasDevol = new ComboBox();
            this.cb_DiasDevol.Items.Add("2 Dias");
            this.cb_DiasDevol.Items.Add("3 Dias");
            this.cb_DiasDevol.Items.Add("4 Dias");
            this.cb_DiasDevol.Items.Add("5 Dias");
            this.cb_DiasDevol.Items.Add("PLUS - 10 Dias");
            this.cb_DiasDevol.AutoCompleteMode = AutoCompleteMode.Append;
            this.cb_DiasDevol.Location = new Point(150, 220);
            this.cb_DiasDevol.Size = new Size(170, 20);
            this.Controls.Add(cb_DiasDevol);

            // Buttons
            this.btn_Confirmar = new Library.Button();
            this.btn_Confirmar.Text = "CONFIRMAR";
            this.btn_Confirmar.Location = new Point(80, 280);
            this.btn_Confirmar.Click += new EventHandler(this.btn_ConfirmarClick);
            this.Controls.Add(btn_Confirmar);

            this.btn_Cancelar = new Library.Button();
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.Location = new Point(260, 280);
            this.btn_Cancelar.Click += new EventHandler(this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
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