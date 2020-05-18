using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Windows.Forms.View;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class ConsultaFilme : Form 
    {
        PictureBox pb_Consulta;
        Label lbl_ConsultaFilme;
        RichTextBox rtxt_ConsultaFilme;
        ListView lv_ListaFilmes;
        GroupBox gb_ListaFilme;
        Button btn_Confirmar;
        Button btn_Cancelar;

        // GUIDE FOR LOCATION n SIZE (X Y) 
        // Location (X = Horizontal - Y = Vertical)
        // Size     (X = Largura    - Y = Altura) 

        public ConsultaFilme () {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 430);

            // Image to Bloclbuster
            pb_Consulta = new PictureBox();
            pb_Consulta.Location = new Point (10, 10);    
            pb_Consulta.Size = new Size(480 , 100);
            pb_Consulta.ClientSize = new Size (460 , 60);
            pb_Consulta.BackColor = Color.Black;
            pb_Consulta.Load ("consulta.jpg");
            pb_Consulta.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Consulta);

            lbl_ConsultaFilme = new Label ();
            lbl_ConsultaFilme.Text = "Buscar Filme :";
            lbl_ConsultaFilme.Location = new Point (30, 80);
            lbl_ConsultaFilme.AutoSize = true;            
            this.Controls.Add (lbl_ConsultaFilme);

            rtxt_ConsultaFilme = new RichTextBox ();
            rtxt_ConsultaFilme.SelectionFont  = new Font("Tahoma", 10, FontStyle.Bold);  
            rtxt_ConsultaFilme.SelectionColor = System.Drawing.Color.Black;
            rtxt_ConsultaFilme.Location = new Point (150, 80);
            rtxt_ConsultaFilme.Size = new Size (300, 20);
            this.Controls.Add (rtxt_ConsultaFilme);

            // ListView
            lv_ListaFilmes = new ListView();
            lv_ListaFilmes.Location = new Point(40, 130);
            lv_ListaFilmes.Size = new Size(400, 140);
            lv_ListaFilmes.View = Details;
            ListViewItem filme1 = new ListViewItem("Ben-Hur");
            filme1.SubItems.Add("1959");
            filme1.SubItems.Add("5");            
            ListViewItem filme2 = new ListViewItem("Riddick 3");
            filme2.SubItems.Add("2018");
            filme2.SubItems.Add("4");
            ListViewItem filme3 = new ListViewItem("Laranja Mecânica");
            filme3.SubItems.Add("1975");
            filme3.SubItems.Add("3");
            ListViewItem filme4 = new ListViewItem("Rei Leão");
            filme4.SubItems.Add("1994");
            filme4.SubItems.Add("2");
            ListViewItem filme5 = new ListViewItem("Valerian");
            filme5.SubItems.Add("2019");
            filme5.SubItems.Add("1");
            lv_ListaFilmes.Items.AddRange(new ListViewItem[]{filme1, filme2, filme3, filme4, filme5});
            lv_ListaFilmes.FullRowSelect = true;
            lv_ListaFilmes.GridLines = true;
            lv_ListaFilmes.AllowColumnReorder = true;
            lv_ListaFilmes.Sorting = SortOrder.Ascending;
            lv_ListaFilmes.Columns.Add("Título", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Ano Lançamento", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Estoque", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaFilmes);

            // Customer grouping box
            gb_ListaFilme = new GroupBox();    
            gb_ListaFilme.Location = new Point(30, 110);        
            gb_ListaFilme.Size = new Size(420, 170);            
            gb_ListaFilme.Text= "LISTA DE FILMES";
            gb_ListaFilme.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaFilme);

            btn_Confirmar = new Button ();
            btn_Confirmar.Location = new Point (80, 320);
            btn_Confirmar.Size = new Size (150, 40);            
            btn_Confirmar.Text = "CONFIRMAR";
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Confirmar.ForeColor = Color.Black; 
            btn_Confirmar.Click += new EventHandler (this.btn_ConfirmarClick);
            this.Controls.Add (btn_Confirmar);

            btn_Cancelar = new Button ();
             btn_Cancelar.Location = new Point (260,320);
            btn_Cancelar.Size = new Size (150, 40);           
            btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Cancelar.ForeColor = Color.Black;
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add (btn_Cancelar);
        }

        private void btn_ConfirmarClick (object sender, EventArgs e) 
        {
            MessageBox.Show (
                $"IdFilme.:> {rtxt_ConsultaFilme.Text}\n",
                "Filme",
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