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

        // List rental window
        public ListaLocacao (Form parent) 
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600, 640);
            this.parent = parent;

            // PictureBox
            pb_Lista = new PictureBox();
            pb_Lista.Location = new Point (10, 10);    
            pb_Lista.Size = new Size(180 , 100);
            pb_Lista.ClientSize = new Size (560 , 60);
            pb_Lista.BackColor = Color.Black;
            pb_Lista.Load ("./Views/assets/lista.jpg");
            pb_Lista.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Lista); 

            // ListView - Rentals
            lv_ListaLocacoes = new ListView();
            lv_ListaLocacoes.Location = new Point(20, 100);
            lv_ListaLocacoes.Size = new Size(540, 400);
            lv_ListaLocacoes.View = View.Details;
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

            // List grouping box
            gb_ListaLocacoes = new GroupBox();
            gb_ListaLocacoes.Location = new Point(10, 80);
            gb_ListaLocacoes.Size = new Size(560, 430);
            gb_ListaLocacoes.Text= "LISTA DE LOCAÇÕES";
            gb_ListaLocacoes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaLocacoes); 

            // Buttons
            btn_ListaSair = new Button ();
            btn_ListaSair.Text = "SAIR";
            btn_ListaSair.Location = new Point (200, 530);
            btn_ListaSair.Size = new Size (150, 40);  
            this.btn_ListaSair.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaSair.ForeColor = Color.Black;          
            btn_ListaSair.Click += new EventHandler (this.btn_ListaSairClick);
            this.Controls.Add (btn_ListaSair);
        }

        /// <summary>
        /// Event button to exit and back to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ListaSairClick (object sender, EventArgs e) 
        {
            MessageBox.Show ("CONCLUÍDO!");
            this.Close ();
            this.parent.Show ();
        }
    }
}