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
    public class ConsultaCliente : Form
    {
        PictureBox pb_Consulta;
        Label lbl_ConsultaCliente;
        RichTextBox rtxt_ConsultaCliente;
        ListView lv_ListaClientes;
        GroupBox gb_ListaClientes;
        Button btn_ListaSair;
        Form parent;

        // GUIDE FOR LOCATION n SIZE (X Y) 
        // Location (X = Horizontal - Y = Vertical)
        // Size     (X = Largura    - Y = Altura) 

        public ConsultaCliente(Form parent)
        {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 430);
            this.parent = parent;

            // Image to Bloclbuster
            pb_Consulta = new PictureBox();
            pb_Consulta.Location = new Point(10, 10);
            pb_Consulta.Size = new Size(480, 100);
            pb_Consulta.ClientSize = new Size(460, 60);
            pb_Consulta.BackColor = Color.Black;
            pb_Consulta.Load("consulta.jpg");
            pb_Consulta.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Consulta);

            lbl_ConsultaCliente = new Label();
            lbl_ConsultaCliente.Text = "Buscar Cliente :";
            lbl_ConsultaCliente.Location = new Point(30, 80);
            lbl_ConsultaCliente.AutoSize = true;
            this.Controls.Add(lbl_ConsultaCliente);

            /// <summary>
            /// Consulting a customer by ID (LINQ)
            /// </summary>
            rtxt_ConsultaCliente = new RichTextBox();
            rtxt_ConsultaCliente.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);
            rtxt_ConsultaCliente.SelectionColor = System.Drawing.Color.Black;
            rtxt_ConsultaCliente.Location = new Point(150, 80);
            rtxt_ConsultaCliente.Size = new Size(300, 20);
            this.Controls.Add(rtxt_ConsultaCliente);
            rtxt_ConsultaCliente.KeyPress += new KeyPressEventHandler(keypressed);

            // ListView
            lv_ListaClientes = new ListView();
            lv_ListaClientes.Location = new Point(20, 100);
            lv_ListaClientes.Size = new Size(440, 400);
            lv_ListaClientes.View = Details;
            ListViewItem clientes = new ListViewItem();
            foreach (ClienteModels cliente in ClienteController.GetClientes())
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaClientes.Items.Add(lv_ListaCliente);
            }
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
            gb_ListaClientes.Location = new Point(30, 110);
            gb_ListaClientes.Size = new Size(420, 170);
            gb_ListaClientes.Text = "LISTA DE CLIENTES";
            gb_ListaClientes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaClientes);

            // Descision Buttons
            btn_ListaSair = new Button();
            btn_ListaSair.Location = new Point(160, 530);
            btn_ListaSair.Size = new Size(150, 50);
            btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaSair.ForeColor = Color.Black;
            btn_ListaSair.Click += new EventHandler(btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }

        private void keypressed(Object o, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
            }
        }
        private void btn_ListaSairClick(object sender, EventArgs e)
        {
            MessageBox.Show("CONCLUÍDO!");
            this.Close();
            this.parent.Show();
        }
    }
}