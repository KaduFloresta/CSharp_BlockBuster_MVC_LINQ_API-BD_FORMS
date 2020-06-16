using System;
using Models;
using Controllers;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    partial class ListaLocacao : Form
    {
        Library.PictureBox pb_Lista;
        Library.ListView lv_ListaLocacoes;
        Library.GroupBox gb_ListaLocacoes;
        Library.Button btn_ListaSair;
        Form parent;

        // List rental window
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

            // ListView - Rentals
            this.lv_ListaLocacoes = new Library.ListView();
            this.lv_ListaLocacoes.Location = new Point(20, 100);
            this.lv_ListaLocacoes.Size = new Size(540, 400);
            ListViewItem locacoes = new ListViewItem();
            List<LocacaoModels> locacoesLista = LocacaoController.GetLocacoes();
            foreach (var locacao in locacoesLista)
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

            // List grouping box
            this.gb_ListaLocacoes = new Library.GroupBox();
            this.gb_ListaLocacoes.Location = new Point(10, 80);
            this.gb_ListaLocacoes.Size = new Size(560, 430);
            this.gb_ListaLocacoes.Text = "LISTA DE LOCAÇÕES";
            this.Controls.Add(gb_ListaLocacoes);

            // Buttons
            this.btn_ListaSair = new Library.Button();
            this.btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.Location = new Point(200, 530);
            this.btn_ListaSair.Click += new EventHandler(this.btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }
    }
}