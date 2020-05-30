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
        ToolTip tt_BuscaCliente;
        RichTextBox rtxt_ConsultaCliente;
        ListView lv_ListaClientes;
        GroupBox gb_ListaClientes;
        Button btn_ListaConsulta;
        Button btn_ListaSair;
        Form parent;

        // Consult registered customers 
        public ConsultaCliente(Form parent)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 620);
            this.parent = parent;

            // PictureBox
            pb_Consulta = new PictureBox();
            pb_Consulta.Location = new Point(10, 10);
            pb_Consulta.Size = new Size(480, 100);
            pb_Consulta.ClientSize = new Size(460, 60);
            pb_Consulta.BackColor = Color.Black;
            pb_Consulta.Load("./Views/assets/consulta.jpg");
            pb_Consulta.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Consulta);

            // Label
            lbl_ConsultaCliente = new Label();
            lbl_ConsultaCliente.Text = "Buscar Cliente :";
            lbl_ConsultaCliente.Location = new Point(30, 80);
            lbl_ConsultaCliente.AutoSize = true;
            this.Controls.Add(lbl_ConsultaCliente);

            // Fill orientation tip
            tt_BuscaCliente = new ToolTip();
            tt_BuscaCliente.AutoPopDelay = 5000;
            tt_BuscaCliente.InitialDelay = 1000;
            tt_BuscaCliente.ReshowDelay = 500;
            tt_BuscaCliente.ShowAlways = true;

            // RichTextBox (Edited text - Keypress mode to filter a customer in ListView)
            rtxt_ConsultaCliente = new RichTextBox();
            rtxt_ConsultaCliente.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);
            rtxt_ConsultaCliente.SelectionColor = System.Drawing.Color.Black;
            rtxt_ConsultaCliente.Location = new Point(150, 80);
            rtxt_ConsultaCliente.Size = new Size(300, 20);
            this.Controls.Add(rtxt_ConsultaCliente);
            tt_BuscaCliente.SetToolTip(rtxt_ConsultaCliente, "Digite o nome ou selecione abaixo");
            rtxt_ConsultaCliente.KeyPress += new KeyPressEventHandler(keypressed);

            // ListView - Customer
            lv_ListaClientes = new ListView();
            lv_ListaClientes.Location = new Point(20, 130);
            lv_ListaClientes.Size = new Size(440, 350);
            lv_ListaClientes.View = Details;
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
            lv_ListaClientes.FullRowSelect = true;
            lv_ListaClientes.GridLines = true;
            lv_ListaClientes.AllowColumnReorder = true;
            lv_ListaClientes.Sorting = SortOrder.None;
            lv_ListaClientes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Dias Devolução", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            // ListView grouping box
            gb_ListaClientes = new GroupBox();
            gb_ListaClientes.Location = new Point(10, 110);
            gb_ListaClientes.Size = new Size(460, 380);
            gb_ListaClientes.Text = "LISTA DE CLIENTES";
            gb_ListaClientes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaClientes);

            // Buttons
            btn_ListaConsulta = new Button();
            btn_ListaConsulta.Location = new Point(80, 510);
            btn_ListaConsulta.Size = new Size(150, 50);
            btn_ListaConsulta.Text = "CONSULTA";
            this.btn_ListaConsulta.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaConsulta.ForeColor = Color.Black;
            btn_ListaConsulta.Click += new EventHandler(btn_ListaConsultaClick);
            this.Controls.Add(btn_ListaConsulta);

            btn_ListaSair = new Button();
            btn_ListaSair.Location = new Point(260, 510);
            btn_ListaSair.Size = new Size(150, 50);
            btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaSair.ForeColor = Color.Black;
            btn_ListaSair.Click += new EventHandler(btn_ListaSairClick);
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