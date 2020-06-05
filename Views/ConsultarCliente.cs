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
        Library.PictureBox pb_Consulta;
        Library.Label lbl_ConsultaCliente;
        ToolTip tt_BuscaCliente;
        Library.RichTextBox rtxt_ConsultaCliente;
        Library.ListView lv_ListaClientes;
        Library.GroupBox gb_ListaClientes;
        Library.Button btn_ListaConsulta;
        Library.Button btn_ListaSair;
        Form parent;

        // Consult registered customers 
        public ConsultaCliente(Form parent)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 620);
            this.Dock = DockStyle.Fill;
            this.parent = parent;

            // PictureBox
            this.pb_Consulta = new Library.PictureBox();
            this.pb_Consulta.Load("./Views/assets/consulta.jpg");
            this.Controls.Add(pb_Consulta);

            // Label
            this.lbl_ConsultaCliente = new Library.Label();
            this.lbl_ConsultaCliente.Text = "Buscar Cliente :";
            this.lbl_ConsultaCliente.Location = new Point(30, 80);
            this.Controls.Add(lbl_ConsultaCliente);

            // Fill orientation tip
            this.tt_BuscaCliente = new Library.ToolTip();

            // RichTextBox (Edited text - Keypress mode to filter a customer in ListView)
            this.rtxt_ConsultaCliente = new Library.RichTextBox();
            this.rtxt_ConsultaCliente.Location = new Point(150, 80);
            this.Controls.Add(rtxt_ConsultaCliente);
            this.tt_BuscaCliente.SetToolTip(rtxt_ConsultaCliente, "Digite o nome ou selecione abaixo");
            this.rtxt_ConsultaCliente.KeyPress += new KeyPressEventHandler(keypressed);

            // ListView - Customer
            this.lv_ListaClientes = new Library.ListView();
            this.lv_ListaClientes.Location = new Point(20, 130);
            this.lv_ListaClientes.Size = new Size(440, 350);
            List<ClienteModels> listaCliente = (from cliente in ClienteController.GetClientes() where cliente.NomeCliente.Contains(rtxt_ConsultaCliente.Text) select cliente).ToList();
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
            this.lv_ListaClientes.MultiSelect = false;
            this.lv_ListaClientes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            this.lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("Dias Devolução", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            // ListView grouping box
            this.gb_ListaClientes = new Library.GroupBox();
            this.gb_ListaClientes.Location = new Point(10, 110);
            this.gb_ListaClientes.Size = new Size(460, 380);
            this.gb_ListaClientes.Text = "LISTA DE CLIENTES";
            this.Controls.Add(gb_ListaClientes);

            // Buttons
            this.btn_ListaConsulta = new Library.Button();
            this.btn_ListaConsulta.Location = new Point(80, 510);
            this.btn_ListaConsulta.Text = "CONSULTA";
            this.btn_ListaConsulta.Click += new EventHandler(btn_ListaConsultaClick);
            this.Controls.Add(btn_ListaConsulta);

            this.btn_ListaSair = new Library.Button();
            this.btn_ListaSair.Location = new Point(260, 510);
            this.btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.Click += new EventHandler(btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }

        /// <summary>
        /// RefreshForm to keypress
        /// </summary>
        public void RefreshForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.RefreshForm));
            }
            Application.DoEvents();
        }

        /// <summary>
        /// Keypress event to find a customer
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void keypressed(Object o, KeyPressEventArgs e)
        {
            lv_ListaClientes.Items.Clear();
            List<ClienteModels> listaCliente = (from cliente in ClienteController.GetClientes() where cliente.NomeCliente.Contains(rtxt_ConsultaCliente.Text, StringComparison.OrdinalIgnoreCase) select cliente).ToList();
            ListViewItem clientes = new ListViewItem();
            foreach (ClienteModels cliente in listaCliente)
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaClientes.Items.Add(lv_ListaCliente);
            }
            this.Refresh();
            Application.DoEvents();
        }

        /// <summary>
        /// Event button to consult a selected customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ListaConsultaClick(object sender, EventArgs e)
        {
            try
            {
                string IdCliente = this.lv_ListaClientes.SelectedItems[0].Text;
                ClienteModels cliente = ClienteController.GetCliente(Int32.Parse(IdCliente));
                ClienteDetalhe btn_ListaConsultaClick = new ClienteDetalhe(this, cliente);
                btn_ListaConsultaClick.Show();
            }
            catch
            {
                MessageBox.Show("SELECIONE UM CLIENTE!");
            }
        }

        /// <summary>
        /// Event button to exit and back to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ListaSairClick(object sender, EventArgs e)
        {
            // MessageBox.Show("CONCLUÍDO!");
            this.Close();
            this.parent.Show();
        }
    }
}