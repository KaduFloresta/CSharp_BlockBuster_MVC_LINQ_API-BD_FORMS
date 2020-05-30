using System;
using Models;
using Controllers;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public class ConsultaLocacao : Form
    {
        PictureBox pb_Consulta;
        Label lbl_NomeLocacao;
        ToolTip tt_BuscaCliente;
        RichTextBox rtxt_BuscaCliente;
        ListView lv_ListaLocacoes;
        GroupBox gb_ConsultaLocacao;
        GroupBox gb_ListaLocacoes;
        Button btn_ListaConsulta;
        Button btn_ListaSair;
        Form parent;

        // Consult registered rentals
        public ConsultaLocacao(Form parent)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 500);
            this.parent = parent;

            // PictureBox
            pb_Consulta = new PictureBox();
            pb_Consulta.Location = new Point(10, 10);
            pb_Consulta.Size = new Size(480, 100);
            pb_Consulta.ClientSize = new Size(460, 60);
            pb_Consulta.BackColor = Color.Black;
            pb_Consulta.Load("./Views/assets/locacao.jpg");
            pb_Consulta.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Consulta);

            // Label
            lbl_NomeLocacao = new Label();
            lbl_NomeLocacao.Text = "Busca Por Cliente :";
            lbl_NomeLocacao.Location = new Point(20, 100);
            lbl_NomeLocacao.AutoSize = true;
            this.Controls.Add(lbl_NomeLocacao);

            // Fill orientation tip
            tt_BuscaCliente = new ToolTip();
            tt_BuscaCliente.AutoPopDelay = 5000;
            tt_BuscaCliente.InitialDelay = 1000;
            tt_BuscaCliente.ReshowDelay = 500;
            tt_BuscaCliente.ShowAlways = true;

            // RichTextBox (Edited text - Keypress mode to filter a rental by customer in ListView)
            rtxt_BuscaCliente = new RichTextBox();
            rtxt_BuscaCliente.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);
            rtxt_BuscaCliente.SelectionColor = System.Drawing.Color.Black;
            rtxt_BuscaCliente.Location = new Point(150, 100);
            rtxt_BuscaCliente.Size = new Size(300, 20);
            this.Controls.Add(rtxt_BuscaCliente);
            tt_BuscaCliente.SetToolTip(rtxt_BuscaCliente, "Digite o nome ou selecione abaixo");
            rtxt_BuscaCliente.KeyPress += new KeyPressEventHandler(keypressed);

            // ListView - Rentals
            lv_ListaLocacoes = new ListView();
            lv_ListaLocacoes.Location = new Point(20, 170);
            lv_ListaLocacoes.Size = new Size(440, 185);
            lv_ListaLocacoes.View = View.Details;
            List<ClienteModels> listaCliente = (from cliente in ClienteController.GetClientes() where cliente.NomeCliente.Contains(rtxt_BuscaCliente.Text) select cliente).ToList();
            ListViewItem locacoes = new ListViewItem();
            foreach (LocacaoModels locacao in LocacaoController.GetLocacoes())
            {
                ListViewItem lv_ListaLocacao = new ListViewItem(locacao.IdLocacao.ToString());
                ClienteModels cliente = ClienteController.GetCliente(locacao.IdCliente);
                lv_ListaLocacao.SubItems.Add(cliente.NomeCliente.ToString());
                lv_ListaLocacao.SubItems.Add(cliente.CpfCliente.ToString());
                lv_ListaLocacao.SubItems.Add(locacao.DataLocacao.ToString("dd/MM/yyyy"));
                lv_ListaLocacao.SubItems.Add(locacao.CalculoDataDevol().ToString("dd/MM/yyyy"));
                lv_ListaLocacao.SubItems.Add(locacao.QtdeFilmes().ToString());
                lv_ListaLocacao.SubItems.Add(locacao.ValorTotal().ToString("C2"));
                lv_ListaLocacoes.Items.Add(lv_ListaLocacao);
            }
            lv_ListaLocacoes.FullRowSelect = true;
            lv_ListaLocacoes.GridLines = true;
            lv_ListaLocacoes.AllowColumnReorder = true;
            lv_ListaLocacoes.Sorting = SortOrder.None;
            lv_ListaLocacoes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Locatário", -2, HorizontalAlignment.Left);
            lv_ListaLocacoes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Data Locação", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Data Devolução", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Qtde Filmes", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Total", -2, HorizontalAlignment.Left);
            this.Controls.Add(lv_ListaLocacoes);

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            // ListView grouping box
            gb_ConsultaLocacao = new GroupBox();
            gb_ConsultaLocacao.Location = new Point(10, 80);
            gb_ConsultaLocacao.Size = new Size(460, 55);
            gb_ConsultaLocacao.Text = "BUSCAR LOCAÇÃO";
            gb_ConsultaLocacao.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ConsultaLocacao);

            gb_ListaLocacoes = new GroupBox();
            gb_ListaLocacoes.Location = new Point(10, 150);
            gb_ListaLocacoes.Size = new Size(460, 220);
            gb_ListaLocacoes.Text = "LISTA DE LOCAÇÕES";
            gb_ListaLocacoes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaLocacoes);

            // Buttons
            btn_ListaConsulta = new Button();
            btn_ListaConsulta.Location = new Point(80, 390);
            btn_ListaConsulta.Size = new Size(150, 40);
            btn_ListaConsulta.Text = "CONSULTA";
            this.btn_ListaConsulta.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaConsulta.ForeColor = Color.Black;
            btn_ListaConsulta.Click += new EventHandler(this.btn_ListaConsultaClick);
            this.Controls.Add(btn_ListaConsulta);

            btn_ListaSair = new Button();
            btn_ListaSair.Location = new Point(260, 390);
            btn_ListaSair.Size = new Size(150, 40);
            btn_ListaSair.Text = "CANCELAR";
            this.btn_ListaSair.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaSair.ForeColor = Color.Black;
            btn_ListaSair.Click += new EventHandler(this.btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }

        /// <summary>
        /// RefreshForm to keypress
        /// </summary>
        public void RefreshForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.RefreshForm));
            }
            Application.DoEvents();
        }

        /// <summary>
        /// Keypress event to find a rental by customer
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void keypressed(Object o, KeyPressEventArgs e)
        {
            lv_ListaLocacoes.Items.Clear();
            List<ClienteModels> listaCliente = (from cliente in ClienteController.GetClientes() where cliente.NomeCliente.Contains(rtxt_BuscaCliente.Text, StringComparison.OrdinalIgnoreCase) select cliente).ToList();
            ListViewItem clientes = new ListViewItem();
            foreach (ClienteModels cliente in listaCliente)
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaLocacoes.Items.Add(lv_ListaCliente);
            }
            this.Refresh();
            Application.DoEvents();
        }

        /// <summary>
        /// Event button to consult a selected rental
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ListaConsultaClick(object sender, EventArgs e)
        {
            try
            {
                string IdLocacao = this.lv_ListaLocacoes.SelectedItems[0].Text;
                LocacaoModels locacao = LocacaoController.GetLocacao(Int32.Parse(IdLocacao));
                LocacaoDetalhe btn_ListaConsultaClick = new LocacaoDetalhe(this, locacao);
                btn_ListaConsultaClick.Show();
            }
            catch
            {
                MessageBox.Show("SELECIONE UMA LOCAÇÃO!");
            }
        }

        /// <summary>
        /// Event button to exit and back to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ListaSairClick(object sender, EventArgs e)
        {
            // MessageBox.Show("CONCLUÍDO!");
            this.Close();
            this.parent.Show();
        }
    }
}