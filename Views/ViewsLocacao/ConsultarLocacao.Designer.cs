using System;
using Models;
using Controllers;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    partial class ConsultaLocacao : Form
    {
        Library.PictureBox pb_Consulta;
        Library.Label lbl_NomeLocacao;
        Library.ToolTip tt_BuscaCliente;
        Library.RichTextBox rtxt_BuscaCliente;
        Library.ListView lv_ListaLocacoes;
        Library.GroupBox gb_ConsultaLocacao;
        Library.GroupBox gb_ListaLocacoes;
        Library.Button btn_ListaConsulta;
        Library.Button btn_ListaSair;
        Form parent;

        // Consult registered rentals
        public void InitializeComponent(Form parent)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 500);
            this.parent = parent;

            // PictureBox
            this.pb_Consulta = new Library.PictureBox();
            this.pb_Consulta.ClientSize = new Size(460, 80);
            this.pb_Consulta.Load("./Views/assets/locacao.jpg");
            this.Controls.Add(pb_Consulta);

            // Label
            this.lbl_NomeLocacao = new Library.Label();
            this.lbl_NomeLocacao.Text = "Busca Por Cliente :";
            this.lbl_NomeLocacao.Location = new Point(20, 100);
            this.Controls.Add(lbl_NomeLocacao);

            // Fill orientation tip
            this.tt_BuscaCliente = new Library.ToolTip();

            // RichTextBox (Edited text - Keypress mode to filter a rental by customer in ListView)
            this.rtxt_BuscaCliente = new Library.RichTextBox();
            this.rtxt_BuscaCliente.Location = new Point(150, 100);
            this.Controls.Add(rtxt_BuscaCliente);
            this.tt_BuscaCliente.SetToolTip(rtxt_BuscaCliente, "Digite o nome ou selecione abaixo");
            this.rtxt_BuscaCliente.KeyPress += new KeyPressEventHandler(keypressed);

            // ListView - Rentals
            this.lv_ListaLocacoes = new Library.ListView();
            this.lv_ListaLocacoes.Location = new Point(20, 170);
            this.lv_ListaLocacoes.Size = new Size(440, 185);
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
            this.lv_ListaLocacoes.MultiSelect = false;
            this.lv_ListaLocacoes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Locatário", -2, HorizontalAlignment.Left);
            this.lv_ListaLocacoes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Data Locação", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Data Devolução", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Qtde Filmes", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Total", -2, HorizontalAlignment.Left);
            this.Controls.Add(lv_ListaLocacoes);

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            // ListView grouping box
            this.gb_ConsultaLocacao = new Library.GroupBox();
            this.gb_ConsultaLocacao.Location = new Point(10, 80);
            this.gb_ConsultaLocacao.Size = new Size(460, 55);
            this.gb_ConsultaLocacao.Text = "BUSCAR LOCAÇÃO";
            this.Controls.Add(gb_ConsultaLocacao);

            this.gb_ListaLocacoes = new Library.GroupBox();
            this.gb_ListaLocacoes.Location = new Point(10, 150);
            this.gb_ListaLocacoes.Size = new Size(460, 220);
            this.gb_ListaLocacoes.Text = "LISTA DE LOCAÇÕES";
            this.Controls.Add(gb_ListaLocacoes);

            // Buttons
            this.btn_ListaConsulta = new Library.Button();
            this.btn_ListaConsulta.Location = new Point(80, 390);
            this.btn_ListaConsulta.Text = "CONSULTA";
            this.btn_ListaConsulta.Click += new EventHandler(this.btn_ListaConsultaClick);
            this.Controls.Add(btn_ListaConsulta);

            this.btn_ListaSair = new Library.Button();
            this.btn_ListaSair.Location = new Point(260, 390);
            this.btn_ListaSair.Text = "CANCELAR";
            this.btn_ListaSair.Click += new EventHandler(this.btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }
    }
}