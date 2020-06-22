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
    partial class CadastroLocacao : Form
    {
        Library.PictureBox pb_Cadastro;
        Library.Label lbl_BuscaCliente;
        Library.Label lbl_BuscaFilme;
        Library.ToolTip tt_BuscaCliente;
        Library.ToolTip tt_BuscaFilme;
        Library.RichTextBox rtxt_BuscaCliente;
        Library.RichTextBox rtxt_BuscaFilme;
        Library.ListView lv_ListaClientes;
        Library.ListView lv_ListaFilmes;
        Library.GroupBox gb_ListaCliente;
        Library.GroupBox gb_ListaFilme;
        Library.Button btn_Confirmar;
        Library.Button btn_Cancelar;
        Form parent;

        // Rent data entry
        public void InitializeComponent(Form parent, bool isUpdate)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 580);
            this.parent = parent;

            if (isUpdate)
            {
                this.Load += new EventHandler(this.LoadForm);
            }

            // PictureBox
            this.pb_Cadastro = new Library.PictureBox();
            this.pb_Cadastro.Load($"./Views/assets/{(isUpdate ? "alteracao" : "cadastra")}.jpg");
            this.Controls.Add(pb_Cadastro);

            this.lbl_BuscaCliente = new Library.Label();
            this.lbl_BuscaCliente.Text = "Busca Cliente :";
            this.lbl_BuscaCliente.Location = new Point(30, 80);
            this.Controls.Add(lbl_BuscaCliente);

            this.lbl_BuscaFilme = new Library.Label();
            this.lbl_BuscaFilme.Text = "Busca Filme :";
            this.lbl_BuscaFilme.Location = new Point(30, 270);
            this.Controls.Add(lbl_BuscaFilme);

            // Fill orientation tip
            this.tt_BuscaCliente = new Library.ToolTip();

            // RichTextBox (Edited text - Keypress mode to filter a customer in ListView)
            this.rtxt_BuscaCliente = new Library.RichTextBox();
            this.rtxt_BuscaCliente.Location = new Point(150, 80);
            this.Controls.Add(rtxt_BuscaCliente);
            this.tt_BuscaCliente.SetToolTip(rtxt_BuscaCliente, "Digite o nome ou selecione abaixo");
            this.rtxt_BuscaCliente.KeyPress += new KeyPressEventHandler(keypressed1);

            // Fill orientation tip
            this.tt_BuscaFilme = new Library.ToolTip();

            // RichTextBox (Edited text - Keypress mode to filter a movie in ListView)
            this.rtxt_BuscaFilme = new Library.RichTextBox();
            this.rtxt_BuscaFilme.Location = new Point(150, 270);
            this.Controls.Add(rtxt_BuscaFilme);
            this.tt_BuscaFilme.SetToolTip(rtxt_BuscaFilme, "Digite o título ou selecione abaixo");
            this.rtxt_BuscaFilme.KeyPress += new KeyPressEventHandler(keypressed2);

            // ListView - Customer
            this.lv_ListaClientes = new Library.ListView();
            this.lv_ListaClientes.Location = new Point(40, 130);
            this.lv_ListaClientes.Size = new Size(400, 120);
            List<ClienteModels> listaCliente = (from cliente in ClienteController.GetClientes() where cliente.NomeCliente.Contains(rtxt_BuscaCliente.Text) select cliente).ToList();
            ListViewItem clientes = new ListViewItem();
            foreach (ClienteModels cliente in ClienteController.GetClientes())
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaClientes.Items.Add(lv_ListaCliente);
            }
            this.lv_ListaClientes.MultiSelect = false;
            this.lv_ListaClientes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            this.lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("Dias Devolução", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            // ListView grouping box
            this.gb_ListaCliente = new Library.GroupBox();
            this.gb_ListaCliente.Location = new Point(30, 110);
            this.gb_ListaCliente.Size = new Size(420, 150);
            this.gb_ListaCliente.Text = "LISTA DE CLIENTES";
            this.Controls.Add(gb_ListaCliente);

            // ListView - Movies
            this.lv_ListaFilmes = new Library.ListView();
            this.lv_ListaFilmes.Location = new Point(40, 320);
            this.lv_ListaFilmes.Size = new Size(400, 120);
            this.lv_ListaFilmes.CheckBoxes = true;
            List<FilmeModels> listaFilme = (from filme in FilmeController.GetFilmes() where filme.Titulo.Contains(rtxt_BuscaFilme.Text) select filme).ToList();
            ListViewItem filmes = new ListViewItem();
            foreach (FilmeModels filme in FilmeController.GetFilmes())
            {
                ListViewItem lv_ListaFilme = new ListViewItem(filme.IdFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.Titulo);
                lv_ListaFilme.SubItems.Add(filme.DataLancamento);
                lv_ListaFilme.SubItems.Add(filme.ValorLocacaoFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.EstoqueFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.Sinopse);
                lv_ListaFilmes.Items.Add(lv_ListaFilme);
            }
            this.lv_ListaFilmes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Título", -2, HorizontalAlignment.Left);
            this.lv_ListaFilmes.Columns.Add("Data Lançamento", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Preço", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Estoque", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Sinopse", -2, HorizontalAlignment.Left);
            this.Controls.Add(lv_ListaFilmes);

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            // ListView grouping box
            this.gb_ListaFilme = new Library.GroupBox();
            this.gb_ListaFilme.Location = new Point(30, 300);
            this.gb_ListaFilme.Text = "LISTA DE FILMES";
            this.Controls.Add(gb_ListaFilme);

            // Buttons
            this.btn_Confirmar = new Library.Button();
            this.btn_Confirmar.Text = "CONFIRMAR";
            this.btn_Confirmar.Location = new Point(80, 470);
            this.btn_Confirmar.Click += new EventHandler(this.btn_ConfirmarClick);
            this.Controls.Add(btn_Confirmar);

            this.btn_Cancelar = new Library.Button();
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.Location = new Point(260, 470);
            this.btn_Cancelar.Click += new EventHandler(this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
        }
    }
}