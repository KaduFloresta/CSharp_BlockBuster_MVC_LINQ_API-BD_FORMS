using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Locadora_MVC_LINQ_API_BD_Interface;

namespace Locadora_MVC_LINQ_API_BD_IF
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaInicial());
        }
        public class TelaInicial : Form
        {
            //Image for main window
            Library.PictureBox pb_Menu;
            // Grouping by class
            Library.GroupBox gb_Cliente;
            Library.GroupBox gb_Filme;
            Library.GroupBox gb_Locaçao;
            // Choice buttons
            Library.Button btn_CadastroCliente;
            Library.Button btn_ConsultaCliente;
            Library.Button btn_ListaClientes;
            Library.Button btn_CadastroFilme;
            Library.Button btn_ConsultaFilme;
            Library.Button btn_ListaFilmes;
            Library.Button btn_CadastroLocacao;
            Library.Button btn_ConsultaLocacao;
            Library.Button btn_ListaLocacoes;
            Library.Button btn_MenuSair;

            public TelaInicial()
            {
                // Bar and some window details
                this.Text = "BLOCKBUSTER - SENAC 2020";
                this.BackColor = ColorTranslator.FromHtml("#38323e");
                this.Font = new Font(this.Font, FontStyle.Bold);
                this.Size = new Size(600, 560);

                // Image to Bloclbuster
                this.pb_Menu = new Library.PictureBox();
                this.pb_Menu.Location = new Point(10, 10);
                this.pb_Menu.Size = new Size(560, 100);
                this.pb_Menu.ClientSize = new Size(560, 120);
                this.pb_Menu.Load("./Views/assets/menu.jpg");
                this.Controls.Add(pb_Menu);

                // Selection button for customer data entry           
                this.btn_CadastroCliente = new Library.Button();
                this.btn_CadastroCliente.Location = new Point(40, 160);
                this.btn_CadastroCliente.Size = new Size(200, 30);
                this.btn_CadastroCliente.Text = "CADASTRO DO CLIENTE";
                this.Controls.Add(btn_CadastroCliente);
                this.btn_CadastroCliente.Click += new EventHandler(btn_CadastroClienteClick);
                // this.btn_CadastroCliente.MouseEnter += new EventHandler(btn_MouseEnter);
                // this.btn_CadastroCliente.MouseLeave += new EventHandler(btn_MouseLeave);

                // Selection button for querying customer data
                this.btn_ConsultaCliente = new Library.Button();
                this.btn_ConsultaCliente.Location = new Point(40, 200);
                this.btn_ConsultaCliente.Size = new Size(200, 30);
                this.btn_ConsultaCliente.Text = "CONSULTA CLIENTE";
                this.Controls.Add(btn_ConsultaCliente);
                this.btn_ConsultaCliente.Click += new EventHandler(btn_ConsultaClienteClick);

                // Selection button for customer data list
                this.btn_ListaClientes = new Library.Button();
                this.btn_ListaClientes.Location = new Point(40, 240);
                this.btn_ListaClientes.Size = new Size(200, 30);
                this.btn_ListaClientes.Text = "LISTA DE CLIENTES";
                this.Controls.Add(btn_ListaClientes);
                this.btn_ListaClientes.Click += new EventHandler(btn_ListaClientesClick);

                // Customer grouping box
                this.gb_Cliente = new Library.GroupBox();
                this.gb_Cliente.Location = new Point(25, 135);
                this.gb_Cliente.Text = "CLIENTE";
                this.Controls.Add(gb_Cliente);

                // Selection button for movie data entry
                this.btn_CadastroFilme = new Library.Button();
                this.btn_CadastroFilme.Location = new Point(350, 160);
                this.btn_CadastroFilme.Size = new Size(200, 30);
                this.btn_CadastroFilme.Text = "CADASTRO DO FILME";
                this.Controls.Add(btn_CadastroFilme);
                this.btn_CadastroFilme.Click += new EventHandler(btn_CadastroFilmeClick);

                // Selection button for querying movie data
                this.btn_ConsultaFilme = new Library.Button();
                this.btn_ConsultaFilme.Location = new Point(350, 200);
                this.btn_ConsultaFilme.Size = new Size(200, 30);
                this.btn_ConsultaFilme.Text = "CONSULTA FILME";
                this.Controls.Add(btn_ConsultaFilme);
                this.btn_ConsultaFilme.Click += new EventHandler(btn_ConsultaFilmeClick);

                // Selection button for movie data list
                this.btn_ListaFilmes = new Library.Button();
                this.btn_ListaFilmes.Location = new Point(350, 240);
                this.btn_ListaFilmes.Size = new Size(200, 30);
                this.btn_ListaFilmes.Text = "LISTA DE FILMES";
                this.Controls.Add(btn_ListaFilmes);
                this.btn_ListaFilmes.Click += new EventHandler(btn_ListaFilmesClick);

                // Movie grouping box
                this.gb_Filme = new Library.GroupBox();
                this.gb_Filme.Location = new Point(335, 135);
                this.gb_Filme.Text = "FILME";
                this.Controls.Add(gb_Filme);

                // Selection button for entering rental data
                this.btn_CadastroLocacao = new Library.Button();
                this.btn_CadastroLocacao.Location = new Point(195, 320);
                this.btn_CadastroLocacao.Size = new Size(200, 30);
                this.btn_CadastroLocacao.Text = "CADASTRO DA LOCAÇÃO";
                this.Controls.Add(btn_CadastroLocacao);
                this.btn_CadastroLocacao.Click += new EventHandler(btn_CadastroLocacaoClick);

                // Selection button for querying rental data
                this.btn_ConsultaLocacao = new Library.Button();
                this.btn_ConsultaLocacao.Location = new Point(195, 360);
                this.btn_ConsultaLocacao.Size = new Size(200, 30);
                this.btn_ConsultaLocacao.Text = "CONSULTA LOCAÇÃO";
                this.Controls.Add(btn_ConsultaLocacao);
                this.btn_ConsultaLocacao.Click += new EventHandler(btn_ConsultaLocacaoClick);

                // Selection button to list rentals
                this.btn_ListaLocacoes = new Library.Button();
                this.btn_ListaLocacoes.Location = new Point(195, 400);
                this.btn_ListaLocacoes.Size = new Size(200, 30);
                this.btn_ListaLocacoes.Text = "LISTA DE LOCAÇÕES";
                this.Controls.Add(btn_ListaLocacoes);
                this.btn_ListaLocacoes.Click += new EventHandler(btn_ListaLocacoesClick);

                // Rent grouping box
                this.gb_Locaçao = new Library.GroupBox();
                this.gb_Locaçao.Location = new Point(180, 295);
                this.gb_Locaçao.Text = "LOCAÇÃO";
                this.Controls.Add(gb_Locaçao);

                this.btn_MenuSair = new Library.Button();
                this.btn_MenuSair.Location = new Point(220, 455);
                this.btn_MenuSair.Text = "SAIR";
                this.Controls.Add(btn_MenuSair);
                this.btn_MenuSair.Click += new EventHandler(btn_MenuSairClick);
            }

            // Access to the customer register
            private void btn_CadastroClienteClick(object sender, EventArgs e)
            {
                CadastroCliente cadastrarClienteClick = new CadastroCliente(this);
                cadastrarClienteClick.Show();
            }

            //Access to customer consultation
            private void btn_ConsultaClienteClick(object sender, EventArgs e)
            {
                ConsultaCliente consultaClienteClick = new ConsultaCliente(this);
                consultaClienteClick.Show();
            }

            //Access to list customers
            private void btn_ListaClientesClick(object sender, EventArgs e)
            {
                ListaCliente listaClienteClick = new ListaCliente(this);
                listaClienteClick.Show();
            }

            // // Access to the movie register
            private void btn_CadastroFilmeClick(object sender, EventArgs e)
            {
                CadastroFilme cadastrarFilmeClick = new CadastroFilme(this);
                cadastrarFilmeClick.Show();
            }

            // Access to movie consultation
            private void btn_ConsultaFilmeClick(object sender, EventArgs e)
            {
                ConsultaFilme consultarFilmeClick = new ConsultaFilme(this);
                consultarFilmeClick.Show();
            }

            // Access to list movies
            private void btn_ListaFilmesClick(object sender, EventArgs e)
            {
                ListaFilme listaFilmeClick = new ListaFilme(this);
                listaFilmeClick.Show();
            }

            // Access to the rental register
            private void btn_CadastroLocacaoClick(object sender, EventArgs e)
            {
                CadastroLocacao cadastrarLocacaoClick = new CadastroLocacao(this);
                cadastrarLocacaoClick.Show();
            }

            // Access to rental consultation
            private void btn_ConsultaLocacaoClick(object sender, EventArgs e)
            {
                ConsultaLocacao consultarLocacaoClick = new ConsultaLocacao(this);
                consultarLocacaoClick.Show();
            }

            // Access to list rentals
            private void btn_ListaLocacoesClick(object sender, EventArgs e)
            {
                ListaLocacao listaLocacaoClick = new ListaLocacao(this);
                listaLocacaoClick.Show();
            }

            // Method to close system
            private void btn_MenuSairClick(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
}
