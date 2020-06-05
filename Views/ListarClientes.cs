using System;
using Models;
using Controllers;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.View;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public class ListaCliente : Form
    {
        Library.PictureBox pb_Lista;
        Library.ListView lv_ListaClientes;
        Library.GroupBox gb_ListaClientes;
        Library.Button btn_ListaSair;
        Form parent;

        // List customer window
        public ListaCliente(Form parent)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 640);
            this.parent = parent;

            // PictureBox
            this.pb_Lista = new Library.PictureBox();
            this.pb_Lista.Size = new Size(460, 75);
            this.pb_Lista.Load("./Views/assets/lista.jpg");
            this.Controls.Add(pb_Lista);

            // ListView - Customer
            this.lv_ListaClientes = new Library.ListView();
            this.lv_ListaClientes.Location = new Point(20, 100);
            this.lv_ListaClientes.Size = new Size(440, 400);
            ListViewItem clientes = new ListViewItem();
            List<ClienteModels> clientesLista = ClienteController.GetClientes();
            foreach (var cliente in clientesLista)
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaClientes.Items.Add(lv_ListaCliente);
            }
            this.lv_ListaClientes.MultiSelect = false;
            this.lv_ListaClientes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            this.lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("Dias Devolução", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            // List grouping box
            this.gb_ListaClientes = new Library.GroupBox();
            this.gb_ListaClientes.Location = new Point(10, 80);
            this.gb_ListaClientes.Size = new Size(460, 430);
            this.gb_ListaClientes.Text = "LISTA DE CLIENTES";
            this.Controls.Add(gb_ListaClientes);

            // Buttons
            this.btn_ListaSair = new Library.Button();
            this.btn_ListaSair.Location = new Point(160, 530);
            this.btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.Click += new EventHandler(btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }

        /// <summary>
        /// Event button to exit and back to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ListaSairClick(object sender, EventArgs e)
        {
            // MessageBox.Show ("CONCLUÍDO!");
            this.Close();
            this.parent.Show();
        }
    }
}