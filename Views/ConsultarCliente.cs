using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class ConsultaCliente : Form 
    {
        PictureBox pb_Consulta;
        Label lbl_ConsultaCliente;
        RichTextBox rtxt_ConsultaCliente;
        ListView lv_ListaClientes;
        GroupBox gb_ListaClientes;
        Button btn_Confirmar;
        Button btn_Cancelar;

        // GUIDE FOR LOCATION n SIZE (X Y) 
        // Location (X = Horizontal - Y = Vertical)
        // Size     (X = Largura    - Y = Altura) 

        public ConsultaCliente () 
        {
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

            lbl_ConsultaCliente = new Label ();
            lbl_ConsultaCliente.Text = "Buscar Cliente :";
            lbl_ConsultaCliente.Location = new Point (30, 80);
            lbl_ConsultaCliente.AutoSize = true;            
            this.Controls.Add (lbl_ConsultaCliente);

            rtxt_ConsultaCliente = new RichTextBox ();
            rtxt_ConsultaCliente.SelectionFont  = new Font("Tahoma", 10, FontStyle.Bold);  
            rtxt_ConsultaCliente.SelectionColor = System.Drawing.Color.Black;
            rtxt_ConsultaCliente.Location = new Point (150, 80);
            rtxt_ConsultaCliente.Size = new Size (300, 20);
            this.Controls.Add (rtxt_ConsultaCliente);

            // ListView
            lv_ListaClientes = new ListView();
            lv_ListaClientes.Location = new Point(40, 130);
            lv_ListaClientes.Size = new Size(400, 140);
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
            lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            // Movie grouping box
            gb_ListaClientes = new GroupBox();
            gb_ListaClientes.Location = new Point(30, 110);
            gb_ListaClientes.Size = new Size(420, 170);
            gb_ListaClientes.Text= "LISTA DE CLIENTES";
            gb_ListaClientes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaClientes);  

            btn_Confirmar = new Button ();
            btn_Confirmar.Text = "CONFIRMAR";
            btn_Confirmar.Location = new Point (80, 320);
            btn_Confirmar.Size = new Size (150, 40);  
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Confirmar.ForeColor = Color.Black;          
            btn_Confirmar.Click += new EventHandler (this.btn_ConfirmarClick);
            this.Controls.Add (btn_Confirmar);

            btn_Cancelar = new Button ();
            btn_Cancelar.Text = "CANCELAR";
            btn_Cancelar.Location = new Point (260, 320);
            btn_Cancelar.Size = new Size (150, 40);  
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Cancelar.ForeColor = Color.Black;          
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add (btn_Cancelar);
        }

        private void btn_ConfirmarClick (object sender, EventArgs e) 
        {
            MessageBox.Show (
                $"IdCliente.:> {rtxt_ConsultaCliente.Text}\n",
                "Cliente",
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