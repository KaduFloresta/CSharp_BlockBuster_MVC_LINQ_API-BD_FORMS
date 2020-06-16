using System;
using Models;
using Controllers;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.View;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    partial class ListaFilme : Form
    {
        Library.PictureBox pb_Lista;
        Library.ListView lv_ListaFilmes;
        Library.GroupBox gb_ListaFilmes;
        Library.Button btn_ListaSair;
        Form parent;

        // List movie window
         public void InitializeComponent(Form parent)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600, 640);
            this.parent = parent;

            // PictureBox
            this.pb_Lista = new Library.PictureBox();
            this.pb_Lista.Location = new Point(50, 0);
            this.pb_Lista.Size = new Size(470, 80);
            this.pb_Lista.ClientSize = new Size(470, 80);
            this.pb_Lista.Load("./Views/assets/lista.jpg");
            this.Controls.Add(pb_Lista);

            // ListView - Movie
            this.lv_ListaFilmes = new Library.ListView();
            this.lv_ListaFilmes.Location = new Point(20, 100);
            this.lv_ListaFilmes.Size = new Size(540, 400);
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
            this.lv_ListaFilmes.MultiSelect = false;
            this.lv_ListaFilmes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Título", -2, HorizontalAlignment.Left);
            this.lv_ListaFilmes.Columns.Add("Data Lançamento", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Valor", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Estoque", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Sinopse", -2, HorizontalAlignment.Left);
            this.Controls.Add(lv_ListaFilmes);

            // List grouping box
            this.gb_ListaFilmes = new Library.GroupBox();
            this.gb_ListaFilmes.Location = new Point(10, 80);
            this.gb_ListaFilmes.Size = new Size(560, 430);
            this.gb_ListaFilmes.Text = "LISTA DE FILMES";
            this.Controls.Add(gb_ListaFilmes);

            // Buttons
            this.btn_ListaSair = new Library.Button();
            this.btn_ListaSair.Location = new Point(200, 530);
            this.btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.Click += new EventHandler(btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }
    }
}