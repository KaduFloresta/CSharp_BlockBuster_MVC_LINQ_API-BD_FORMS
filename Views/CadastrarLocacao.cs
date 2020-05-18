using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class CadastroLocacao : Form 
    {
        //Image for main window
        PictureBox pb_Cadastro;
        Label lbl_BuscaCliente;
        Label lbl_BuscaFilme;        
        RichTextBox rtxt_BuscaCliente;
        RichTextBox rtxt_BuscaFilme;
        ListView lv_ListaClientes;
        ListView lv_ListaFilmes;
        GroupBox gb_ListaCliente;
        GroupBox gb_ListaFilme;
        Button btn_Confirmar;
        Button btn_Cancelar;    

        // GUIDE FOR LOCATION n SIZE (X Y) 
        // Location (X = Horizontal - Y = Vertical)
        // Size     (X = Largura    - Y = Altura)     

        public CadastroLocacao ()         
        {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 580);

            // Image to Bloclbuster
            pb_Cadastro = new PictureBox();
            pb_Cadastro.Location = new Point (10, 10);    
            pb_Cadastro.Size = new Size(480 , 100);
            pb_Cadastro.ClientSize = new Size (460 , 60);
            pb_Cadastro.BackColor = Color.Black;
            pb_Cadastro.Load ("cadastra.jpg");
            pb_Cadastro.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Cadastro); 

            lbl_BuscaCliente = new Label ();
            lbl_BuscaCliente.Text = "Busca Cliente :";
            lbl_BuscaCliente.Location = new Point (30, 80);
            lbl_BuscaCliente.AutoSize = true;            
            this.Controls.Add(lbl_BuscaCliente);  

            lbl_BuscaFilme = new Label ();
            lbl_BuscaFilme.Text = "Busca Filme :";
            lbl_BuscaFilme.Location = new Point (30, 270);
            lbl_BuscaFilme.AutoSize = true;            
            this.Controls.Add(lbl_BuscaFilme);          

            rtxt_BuscaCliente = new RichTextBox ();
            rtxt_BuscaCliente.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);  
            rtxt_BuscaCliente.SelectionColor = System.Drawing.Color.Black;
            rtxt_BuscaCliente.Location = new Point (150, 80);
            rtxt_BuscaCliente.Size = new Size (300, 20);
            this.Controls.Add(rtxt_BuscaCliente);

            rtxt_BuscaFilme = new RichTextBox ();
            rtxt_BuscaFilme.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);  
            rtxt_BuscaFilme.SelectionColor = System.Drawing.Color.Black;
            rtxt_BuscaFilme.Location = new Point (150, 270);
            rtxt_BuscaFilme.Size = new Size (300, 20);            
            this.Controls.Add(rtxt_BuscaFilme);

            // ListView
            lv_ListaClientes = new ListView();
            lv_ListaClientes.Location = new Point(40, 130);
            lv_ListaClientes.Size = new Size(400, 120);
            //lv_ListaClientes.View = View.Details;
            ListViewItem cliente1 = new ListViewItem("Joao Silva");
            cliente1.SubItems.Add("12/01/1976");
            cliente1.SubItems.Add("111.111.111-11");            
            ListViewItem cliente2 = new ListViewItem("Joao Andrade");
            cliente2.SubItems.Add("10/01/1978");
            cliente2.SubItems.Add("222.222.222-22");
            ListViewItem cliente3 = new ListViewItem("Larissa Junqueira");
            cliente3.SubItems.Add("25/12/1985");
            cliente3.SubItems.Add("333.333.333-33");
            ListViewItem cliente4 = new ListViewItem("Mara Leão");
            cliente4.SubItems.Add("03/05/1956");
            cliente4.SubItems.Add("444.444.444-44");
            ListViewItem cliente5 = new ListViewItem("Valeria Antonio");
            cliente5.SubItems.Add("12/12/1972");
            cliente5.SubItems.Add("555.555.555-55");
            lv_ListaClientes.Items.AddRange(new ListViewItem[]{cliente1, cliente2, cliente3, cliente4, cliente5});
            lv_ListaClientes.FullRowSelect = true;
            lv_ListaClientes.GridLines = true;
            lv_ListaClientes.AllowColumnReorder = true;
            lv_ListaClientes.Sorting = SortOrder.Ascending;
            lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            // Movie grouping box
            gb_ListaCliente = new GroupBox();
            gb_ListaCliente.Location = new Point(30, 110);
            gb_ListaCliente.Size = new Size(420, 150);
            gb_ListaCliente.Text= "LISTA DE CLIENTES";
            gb_ListaCliente.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaCliente);            

            // ListView
            lv_ListaFilmes = new ListView();
            lv_ListaFilmes.Location = new Point(40, 320);
            lv_ListaFilmes.Size = new Size(400, 120);
            //lv_ListaFilmes.View = View.Details;
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
            lv_ListaFilmes.Columns.Add("Título", -2, HorizontalAlignment.Left);
            lv_ListaFilmes.Columns.Add("Ano Lançamento", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Estoque", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaFilmes);

            // Customer grouping box
            gb_ListaFilme = new GroupBox();    
            gb_ListaFilme.Location = new Point(30, 300);        
            gb_ListaFilme.Size = new Size(420, 150);            
            gb_ListaFilme.Text= "LISTA DE FILMES";
            gb_ListaFilme.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaFilme);

            btn_Confirmar = new Button ();
            btn_Confirmar.Text = "CONFIRMAR";
            btn_Confirmar.Location = new Point (80, 470);
            btn_Confirmar.Size = new Size (150, 40);
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Confirmar.ForeColor = Color.Black;          
            btn_Confirmar.Click += new EventHandler (this.btn_ConfirmarClick);            
            this.Controls.Add(btn_Confirmar);

            btn_Cancelar = new Button ();
            btn_Cancelar.Text = "CANCELAR";
            btn_Cancelar.Location = new Point (260, 470);
            btn_Cancelar.Size = new Size (150, 40);  
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Cancelar.ForeColor = Color.Black;          
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
        }

        private void btn_ConfirmarClick (object sender, EventArgs e) {
            MessageBox.Show (
                $"IdCliente.:> {rtxt_BuscaCliente.Text}\n" +
                $"IdFilme.:> {rtxt_BuscaFilme.Text}\n",
                "Locacao",
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