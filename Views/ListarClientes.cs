using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class ListaCliente : Form 
    {
        PictureBox pb_Lista;
        ListView lv_ListaClientes;
        GroupBox gb_ListaClientes;
        Button btn_Confirmar;
        Button btn_Cancelar;

        // GUIDE FOR LOCATION n SIZE (X Y) 
        // Location (X = Horizontal - Y = Vertical)
        // Size     (X = Largura    - Y = Altura) 

        public ListaCliente () 
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
            lv_ListaClientes = new ListView();
            lv_ListaClientes.Location = new Point(20, 100);
            lv_ListaClientes.Size = new Size(440, 400);
            //lv_ListaClientes.View = View.Details;
            ListViewItem cliente1 = new ListViewItem("005");
            cliente1.SubItems.Add("Joao Silva");
            cliente1.SubItems.Add("12/01/1976");
            cliente1.SubItems.Add("111.111.111-11");            
            cliente1.SubItems.Add("5");            
            ListViewItem cliente2 = new ListViewItem("006");
            cliente2.SubItems.Add("Joao Andrade");
            cliente2.SubItems.Add("10/01/1978");
            cliente2.SubItems.Add("222.222.222-22");
            cliente2.SubItems.Add("4");
            ListViewItem cliente3 = new ListViewItem("007");
            cliente3.SubItems.Add("Larissa Junqueira");
            cliente3.SubItems.Add("25/12/1985");
            cliente3.SubItems.Add("333.333.333-33");
            cliente3.SubItems.Add("3");
            ListViewItem cliente4 = new ListViewItem("008");
            cliente4.SubItems.Add("Mara Leão");
            cliente4.SubItems.Add("03/05/1956");
            cliente4.SubItems.Add("444.444.444-44");
            cliente4.SubItems.Add("2");
            ListViewItem cliente5 = new ListViewItem("009");
            cliente5.SubItems.Add("Valeria Antonio");
            cliente5.SubItems.Add("12/12/1972");
            cliente5.SubItems.Add("555.555.555-55");
            cliente5.SubItems.Add("1");
            lv_ListaClientes.Items.AddRange(new ListViewItem[]{cliente1, cliente2, cliente3, cliente4, cliente5});
            lv_ListaClientes.FullRowSelect = true;
            lv_ListaClientes.GridLines = true;
            lv_ListaClientes.AllowColumnReorder = true;
            lv_ListaClientes.Sorting = SortOrder.Ascending;
            lv_ListaClientes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Dias Devolução", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            // Movie grouping box
            gb_ListaClientes = new GroupBox();
            gb_ListaClientes.Location = new Point(10, 80);
            gb_ListaClientes.Size = new Size(460, 430);
            gb_ListaClientes.Text= "LISTA DE CLIENTES";
            gb_ListaClientes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaClientes); 

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
                $"IdCliente.:> {lv_ListaClientes.Text}\n",
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