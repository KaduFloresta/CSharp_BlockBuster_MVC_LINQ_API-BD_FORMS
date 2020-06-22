using System;
using System.Drawing;
using System.Windows.Forms;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    partial class CadastroFilme : Form
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
        NumericUpDown num_DataLancDia;
        NumericUpDown num_DataLancMes;
        NumericUpDown num_DataLancAno;
        Library.RichTextBox rtxt_Sinopse;
        ComboBox cb_ValorLocacao;
        NumericUpDown num_QtdeEstoque;
        Library.Button btn_Confirmar;
        Library.Button btn_Cancelar;
        Form parent;

        // Movie data entry
        public void InitializeComponent(Form parent, bool isUpdate)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 450);
            this.parent = parent;

            if (isUpdate)
            {
                this.Load += new EventHandler(this.LoadForm);
            }

            // PictureBox
            this.pb_Cadastro = new Library.PictureBox();
            this.pb_Cadastro.Location = new Point(0, 10);
            this.pb_Cadastro.Size = new Size(480, 100);
            this.pb_Cadastro.ClientSize = new Size(480, 80);
            this.pb_Cadastro.Load($"./Views/assets/{(isUpdate ? "alteracao" : "cadastra")}.jpg");
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
            this.num_DataLancDia = new NumericUpDown();
            this.num_DataLancDia.Location = new Point(150, 140);
            this.num_DataLancDia.Size = new Size(50, 20);
            this.num_DataLancDia.Enter += new EventHandler(this.num_DataLancamento_Enter);
            this.num_DataLancDia.Minimum = 0;
            this.num_DataLancDia.Maximum = 31;
            this.Controls.Add(num_DataLancDia);

            this.num_DataLancMes = new NumericUpDown();
            this.num_DataLancMes.Location = new Point(210, 140);
            this.num_DataLancMes.Size = new Size(50, 20);
            this.num_DataLancMes.Enter += new EventHandler(this.num_DataLancamento_Enter);
            this.num_DataLancMes.Minimum = 0;
            this.num_DataLancMes.Maximum = 12;
            this.Controls.Add(num_DataLancMes);

            this.num_DataLancAno = new NumericUpDown();
            this.num_DataLancAno.Location = new Point(270, 140);
            this.num_DataLancAno.Size = new Size(50, 20);
            this.num_DataLancAno.Enter += new EventHandler(this.num_DataLancamento_Enter);
            this.num_DataLancAno.Minimum = 1890;
            this.num_DataLancAno.Maximum = 2020;
            this.Controls.Add(num_DataLancAno);

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
    }
}