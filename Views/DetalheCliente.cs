using System;
using Models;
using System.Drawing;
using System.Windows.Forms;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public class ClienteDetalhe : Form
    {
        Library.PictureBox pb_Detalhe;
        Library.Label lbl_IdCliente;
        Library.Label lbl_Nome;
        Library.Label lbl_DataNasc;
        Library.Label lbl_CPF;
        Library.Label lbl_DiasDevol;
        Library.GroupBox gb_ClienteDetalhe;
        Library.Button btn_SairDetalhe;
        Form parent;

        int idCliente;
        ClienteModels clienteX;

        // Detailed customer window
        public ClienteDetalhe(Form parent, ClienteModels cliente)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 445);
            this.idCliente = cliente.IdCliente;
            this.clienteX = cliente;
            this.parent = parent;

            // PictureBox
            this.pb_Detalhe = new Library.PictureBox();
            this.pb_Detalhe.Load("./Views/assets/cliente.jpg");
            this.Controls.Add(pb_Detalhe);

            // Label + Database Informations
            this.lbl_IdCliente = new Library.Label();
            this.lbl_IdCliente.Text = "ID do Cliente: " + cliente.IdCliente;
            this.lbl_IdCliente.Location = new Point(20, 110);
            this.lbl_IdCliente.Font = new Font(lbl_IdCliente.Font, FontStyle.Bold);
            this.lbl_IdCliente.ForeColor = Color.White;
            this.Controls.Add(lbl_IdCliente);

            this.lbl_Nome = new Library.Label();
            this.lbl_Nome.Text = "Nome: " + cliente.NomeCliente;
            this.lbl_Nome.Location = new Point(20, 150);
            this.lbl_Nome.Font = new Font(lbl_Nome.Font, FontStyle.Bold);
            this.lbl_Nome.ForeColor = Color.White;
            this.Controls.Add(lbl_Nome);

            this.lbl_DataNasc = new Library.Label();
            this.lbl_DataNasc.Text = "Data de Nascimento: " + cliente.DataNascimento.ToString();
            this.lbl_DataNasc.Location = new Point(20, 190);
            this.lbl_DataNasc.Font = new Font(lbl_DataNasc.Font, FontStyle.Bold);
            this.lbl_DataNasc.ForeColor = Color.White;
            this.Controls.Add(lbl_DataNasc);

            this.lbl_CPF = new Library.Label();
            this.lbl_CPF.Text = "CPF: " + cliente.CpfCliente;
            this.lbl_CPF.Location = new Point(20, 230);
            this.lbl_CPF.Font = new Font(lbl_CPF.Font, FontStyle.Bold);
            this.lbl_CPF.ForeColor = Color.White;
            this.Controls.Add(lbl_CPF);

            this.lbl_DiasDevol = new Library.Label();
            this.lbl_DiasDevol.Text = "Dias P/ Devolução: " + cliente.DiasDevolucao.ToString();
            this.lbl_DiasDevol.Location = new Point(20, 270);
            this.lbl_DiasDevol.Font = new Font(lbl_DiasDevol.Font, FontStyle.Bold);
            this.lbl_DiasDevol.ForeColor = Color.White;
            this.Controls.Add(lbl_DiasDevol);

            // Detail customer grouping box
            this.gb_ClienteDetalhe = new Library.GroupBox();
            this.gb_ClienteDetalhe.Location = new Point(10, 80);
            this.gb_ClienteDetalhe.Size = new Size(460, 240);
            this.gb_ClienteDetalhe.Text = "CONSULTA CLIENTES";
            this.Controls.Add(gb_ClienteDetalhe);

            // Buttons
            this.btn_SairDetalhe = new Library.Button();
            this.btn_SairDetalhe.Text = "SAIR";
            this.btn_SairDetalhe.Location = new Point(160, 340);
            this.btn_SairDetalhe.Click += new EventHandler(this.btn_SairDetalheClick);
            this.Controls.Add(btn_SairDetalhe);
        }

        /// <summary>
        /// Event button to exit and back to customer "consult" window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SairDetalheClick(object sender, EventArgs e)
        {
            // MessageBox.Show ("CONCLUÍDO!");
            this.Close();
            this.parent.Show();
        }
    }
}