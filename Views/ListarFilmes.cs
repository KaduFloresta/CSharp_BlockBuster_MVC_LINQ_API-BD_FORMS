using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class ListaFilme : Form 
    {
        PictureBox pb_Lista;
        ListView lv_ListaFilmes;
        GroupBox gb_ListaFilmes;
        Button btn_Confirmar;
        Button btn_Cancelar;

        // GUIDE FOR LOCATION n SIZE (X Y) 
        // Location (X = Horizontal - Y = Vertical)
        // Size     (X = Largura    - Y = Altura) 

        public ListaFilme () 
        {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 640);

            // Image to Bloclbuster
            pb_Lista = new PictureBox();
            pb_Lista.Location = new Point (10, 10);    
            pb_Lista.Size = new Size(480 , 100);
            pb_Lista.ClientSize = new Size (460 , 60);
            pb_Lista.BackColor = Color.Black;
            pb_Lista.Load ("lista.jpg");
            pb_Lista.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Lista); 

            // ListView
            lv_ListaFilmes = new ListView();
            lv_ListaFilmes.Location = new Point(20, 100);
            lv_ListaFilmes.Size = new Size(440, 400);
            // lv_ListaFilmes.View = View.Details;
            ListViewItem filme1 = new ListViewItem("10");
            filme1.SubItems.Add("Ben-Hur");
            filme1.SubItems.Add("1959");
            filme1.SubItems.Add("R$ 3.99");
            filme1.SubItems.Add("5");            
            ListViewItem filme2 = new ListViewItem("121");
            filme2.SubItems.Add("Riddick 3");
            filme2.SubItems.Add("2018");
            filme2.SubItems.Add("R$ 4.99");
            filme2.SubItems.Add("4");
            ListViewItem filme3 = new ListViewItem("125");
            filme3.SubItems.Add("Laranja Mecânica");
            filme3.SubItems.Add("1975");
            filme3.SubItems.Add("R$ 2.99");
            filme3.SubItems.Add("3");
            ListViewItem filme4 = new ListViewItem("402");
            filme4.SubItems.Add("Rei Leão");
            filme4.SubItems.Add("1994");
            filme4.SubItems.Add("R$ 4.99");
            filme4.SubItems.Add("2");
            ListViewItem filme5 = new ListViewItem("302");
            filme5.SubItems.Add("Valerian");
            filme5.SubItems.Add("2019");
            filme5.SubItems.Add("R$ 3.99");
            filme5.SubItems.Add("1");
            lv_ListaFilmes.Items.AddRange(new ListViewItem[]{filme1, filme2, filme3, filme4, filme5});
            lv_ListaFilmes.FullRowSelect = true;
            lv_ListaFilmes.GridLines = true;
            lv_ListaFilmes.AllowColumnReorder = true;
            lv_ListaFilmes.Sorting = SortOrder.Ascending;
            lv_ListaFilmes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Título", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Ano Lançamento", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Valor", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Estoque", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaFilmes);

            // Movie grouping box
            gb_ListaFilmes = new GroupBox();
            gb_ListaFilmes.Location = new Point(10, 80);
            gb_ListaFilmes.Size = new Size(460, 430);
            gb_ListaFilmes.Text= "LISTA DE FILMES";
            gb_ListaFilmes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaFilmes); 

            // Descision Buttons
            btn_Confirmar = new Button ();
            btn_Confirmar.Text = "CONFIRMAR";
            btn_Confirmar.Location = new Point (80, 530);
            btn_Confirmar.Size = new Size (150, 40);  
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Confirmar.ForeColor = Color.Black;          
            btn_Confirmar.Click += new EventHandler (this.btn_ConfirmarClick);
            this.Controls.Add (btn_Confirmar);

            btn_Cancelar = new Button ();
            btn_Cancelar.Text = "CANCELAR";
            btn_Cancelar.Location = new Point (260, 530);
            btn_Cancelar.Size = new Size (150, 40);  
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Cancelar.ForeColor = Color.Black;          
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add (btn_Cancelar);
        }

        private void btn_ConfirmarClick (object sender, EventArgs e) 
        {
            MessageBox.Show (
                $"Idfilme.:> {lv_ListaFilmes.Text}\n",
                "filme",
                MessageBoxButtons.OK
            );
        }

        private void btn_CancelarClick (object sender, EventArgs e) 
        {
           MessageBox.Show("Cancelado!!");
            this.Close();
            TelaInicial telaInicial = new TelaInicial();
            telaInicial.Show();
        }
    }
}