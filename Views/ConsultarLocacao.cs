using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class ConsultaLocacao : Form 
    {
        PictureBox pb_Consulta;
        Label lbl_NomeCliente;
        Label lbl_NomeFilme;
        RichTextBox rtxt_NomeCliente;
        RichTextBox rtxt_NomeFilme;
        ListView lv_ListaLocacoes;
        GroupBox gb_ConsultaLocacao;
        GroupBox gb_ListaLocacoes;
        Button btn_Confirmar;
        Button btn_Cancelar; 
        Form parent;

            // GUIDE FOR LOCATION n SIZE (X Y) 
            // Location (X = Horizontal - Y = Vertical)
            // Size     (X = Largura    - Y = Altura)

        public ConsultaLocacao (Form parent) {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 500);
            this.parent = parent;

            // Image to Bloclbuster
            pb_Consulta = new PictureBox();
            pb_Consulta.Location = new Point (10, 10);    
            pb_Consulta.Size = new Size(480 , 100);
            pb_Consulta.ClientSize = new Size (460 , 60);
            pb_Consulta.BackColor = Color.Black;
            pb_Consulta.Load ("consulta.jpg");
            pb_Consulta.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Consulta);

            lbl_NomeCliente = new Label ();
            lbl_NomeCliente.Text = "Nome do Cliente :";
            lbl_NomeCliente.Location = new Point (20, 100);
            lbl_NomeCliente.AutoSize = true;            
            this.Controls.Add (lbl_NomeCliente);

            lbl_NomeFilme = new Label ();
            lbl_NomeFilme.Text = "Nome do Filme :";
            lbl_NomeFilme.Location = new Point (20, 140);
            lbl_NomeFilme.AutoSize = true;            
            this.Controls.Add (lbl_NomeFilme);

            rtxt_NomeCliente = new RichTextBox ();
            rtxt_NomeCliente.SelectionFont  = new Font("Tahoma", 10, FontStyle.Bold);  
            rtxt_NomeCliente.SelectionColor = System.Drawing.Color.Black;
            rtxt_NomeCliente.Location = new Point (150, 100);
            rtxt_NomeCliente.Size = new Size (300, 20);
            this.Controls.Add (rtxt_NomeCliente);

            rtxt_NomeFilme = new RichTextBox ();
            rtxt_NomeFilme.SelectionFont  = new Font("Tahoma", 10, FontStyle.Bold);  
            rtxt_NomeFilme.SelectionColor = System.Drawing.Color.Black;
            rtxt_NomeFilme.Location = new Point (150, 140);
            rtxt_NomeFilme.Size = new Size (300, 20);
            this.Controls.Add (rtxt_NomeFilme);

            // ListView
            lv_ListaLocacoes = new ListView();
            lv_ListaLocacoes.Location = new Point(30, 210);
            lv_ListaLocacoes.Size = new Size(420, 140);
            lv_ListaLocacoes.View = View.Details;
            ListViewItem locacao1 = new ListViewItem("275");
            locacao1.SubItems.Add("Valeria Antonio");
            locacao1.SubItems.Add("2");            
            locacao1.SubItems.Add("R$ 5.99");            
            locacao1.SubItems.Add("Débito");            
            ListViewItem locacao2 = new ListViewItem("783");
            locacao2.SubItems.Add("Joao Silva");
            locacao2.SubItems.Add("4");
            locacao2.SubItems.Add("R$ 12.99");            
            locacao2.SubItems.Add("Crédito");
            ListViewItem locacao3 = new ListViewItem("125");
            locacao3.SubItems.Add("Mara Leão");
            locacao3.SubItems.Add("3");
            locacao3.SubItems.Add("R$ 9.99");            
            locacao3.SubItems.Add("Dinheiro");
            ListViewItem locacao4 = new ListViewItem("008");
            locacao4.SubItems.Add("Larissa Junqueira");
            locacao4.SubItems.Add("2");
            locacao4.SubItems.Add("R$ 5.99");            
            locacao4.SubItems.Add("Crédito");
            ListViewItem locacao5 = new ListViewItem("792");
            locacao5.SubItems.Add("Joao Andrade");
            locacao5.SubItems.Add("1");
            locacao5.SubItems.Add("R$ 4.99");            
            locacao5.SubItems.Add("PLUS");
            lv_ListaLocacoes.Items.AddRange(new ListViewItem[]{locacao1, locacao2, locacao3, locacao4, locacao5});
            lv_ListaLocacoes.FullRowSelect = true;
            lv_ListaLocacoes.GridLines = true;
            lv_ListaLocacoes.AllowColumnReorder = true;
            lv_ListaLocacoes.Sorting = SortOrder.Ascending;
            lv_ListaLocacoes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Locatário", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Qtde Filmes", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Total", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Pagto", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaLocacoes);

            // Customer grouping box
            gb_ConsultaLocacao = new GroupBox();    
            gb_ConsultaLocacao.Location = new Point(10, 80);        
            gb_ConsultaLocacao.Size = new Size(460, 100);            
            gb_ConsultaLocacao.Text= "BUSCAR LOCAÇÃO";
            gb_ConsultaLocacao.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ConsultaLocacao);
            
            gb_ListaLocacoes = new GroupBox();    
            gb_ListaLocacoes.Location = new Point(10, 190);        
            gb_ListaLocacoes.Size = new Size(460, 170);            
            gb_ListaLocacoes.Text= "LISTA DE FILMES";
            gb_ListaLocacoes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaLocacoes);

            btn_Confirmar = new Button ();
            btn_Confirmar.Location = new Point (80, 390);
            btn_Confirmar.Size = new Size (150, 40);            
            btn_Confirmar.Text = "CONFIRMAR";
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Confirmar.ForeColor = Color.Black; 
            btn_Confirmar.Click += new EventHandler (this.btn_ConfirmarClick);
            this.Controls.Add(btn_Confirmar);

            btn_Cancelar = new Button ();
            btn_Cancelar.Location = new Point (260, 390);
            btn_Cancelar.Size = new Size (150, 40);           
            btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Cancelar.ForeColor = Color.Black;
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
        }

        private void btn_ConfirmarClick (object sender, EventArgs e) 
        {
            MessageBox.Show (
                $"IdLocacao.:> {rtxt_NomeCliente.Text}\n",
                "Locacao",
                MessageBoxButtons.OK
            );
        }

        private void btn_CancelarClick (object sender, EventArgs e) 
        {
            MessageBox.Show("CONCLUÍDO!");
            this.Close();
            this.parent.Show();  
        }
    }
}