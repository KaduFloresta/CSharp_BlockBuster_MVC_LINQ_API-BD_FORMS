using System;
using Models;
using Controllers;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Windows.Forms.View;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class ListaLocacao : Form 
    {
        PictureBox pb_Lista;
        ListView lv_ListaLocacoes;
        GroupBox gb_ListaLocacoes;
        Button btn_ListaSair;
        Form parent;

        // GUIDE FOR LOCATION n SIZE (X Y) 
        // Location (X = Horizontal - Y = Vertical)
        // Size     (X = Largura    - Y = Altura) 

        public ListaLocacao (Form parent) 
        {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600, 640);
            this.parent = parent;

            // Image to Bloclbuster
            pb_Lista = new PictureBox();
            pb_Lista.Location = new Point (10, 10);    
            pb_Lista.Size = new Size(180 , 100);
            pb_Lista.ClientSize = new Size (560 , 60);
            pb_Lista.BackColor = Color.Black;
            pb_Lista.Load ("./Views/assets/lista.jpg");
            pb_Lista.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Lista); 

            // ListView
            lv_ListaLocacoes = new ListView();
            lv_ListaLocacoes.Location = new Point(20, 100);
            lv_ListaLocacoes.Size = new Size(540, 400);
            lv_ListaLocacoes.View = View.Details;ListViewItem clientes = new ListViewItem();
            List<ClienteModels> clientesLista = ClienteController.GetClientes();
            foreach (var cliente in clientesLista)
            {
                ListViewItem lv_ListaLocacao = new ListViewItem(cliente.IdCliente.ToString());                
                lv_ListaLocacao.SubItems.Add(cliente.NomeCliente);
                lv_ListaLocacao.SubItems.Add(cliente.CpfCliente);
                lv_ListaLocacao.SubItems.Add(cliente.DataNascimento);
                lv_ListaLocacao.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaLocacao.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaLocacao.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaLocacoes.Items.Add(lv_ListaLocacao);
            }
            lv_ListaLocacoes.FullRowSelect = true;
            lv_ListaLocacoes.GridLines = true;
            lv_ListaLocacoes.AllowColumnReorder = true;
            lv_ListaLocacoes.Sorting = SortOrder.Ascending;
            lv_ListaLocacoes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Nome", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Data", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Qtde", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Total", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Pagto", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaLocacoes);

            // Movie grouping box
            gb_ListaLocacoes = new GroupBox();
            gb_ListaLocacoes.Location = new Point(10, 80);
            gb_ListaLocacoes.Size = new Size(560, 430);
            gb_ListaLocacoes.Text= "LISTA DE LOCAÇÕES";
            gb_ListaLocacoes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaLocacoes); 

            // Descision Buttons
            btn_ListaSair = new Button ();
            btn_ListaSair.Text = "SAIR";
            btn_ListaSair.Location = new Point (200, 530);
            btn_ListaSair.Size = new Size (150, 40);  
            this.btn_ListaSair.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaSair.ForeColor = Color.Black;          
            btn_ListaSair.Click += new EventHandler (this.btn_ListaSairClick);
            this.Controls.Add (btn_ListaSair);
        }

        private void btn_ListaSairClick (object sender, EventArgs e) 
        {
            MessageBox.Show ("CONCLUÍDO!");
            this.Close ();
            this.parent.Show ();
        }
    }
}