using System;
using Models;
using Controllers;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class ClienteDetalhe : Form 
    {
        PictureBox pb_Detalhe;
        Label lbl_IdCliente;
        Label lbl_Nome;  
        Label lbl_DataNasc;      
        Label lbl_CPF;
        Label lbl_DiasDevol;
        GroupBox gb_ClienteDetalhe;
        Button btn_SairDetalhe;
        Form parent;

        int idCliente;
        ClienteModels clienteX; 

        // Detailed customer window
        public ClienteDetalhe (Form parent, ClienteModels cliente) 
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 445);
            this.idCliente = cliente.IdCliente;
            this.clienteX = cliente;
            this.parent = parent;

            // PictureBox
            pb_Detalhe = new PictureBox();
            pb_Detalhe.Location = new Point (10, 10);    
            pb_Detalhe.Size = new Size(480 , 100);
            pb_Detalhe.ClientSize = new Size (460 , 60);
            pb_Detalhe.BackColor = Color.Black;
            pb_Detalhe.Load ("./Views/assets/cliente.jpg");
            pb_Detalhe.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Detalhe);  

            // Label + Database Informations
            lbl_IdCliente = new Label ();
            lbl_IdCliente.Text = "ID do Cliente: " + cliente.IdCliente;
            lbl_IdCliente.Location = new Point (20, 110);
            lbl_IdCliente.AutoSize = true;
            lbl_IdCliente.Font = new Font(lbl_IdCliente.Font, FontStyle.Bold);
            this.lbl_IdCliente.ForeColor = Color.White;
            this.Controls.Add(lbl_IdCliente);

            lbl_Nome = new Label ();
            lbl_Nome.Text = "Nome: " + cliente.NomeCliente;
            lbl_Nome.Location = new Point (20, 150);
            lbl_Nome.AutoSize = true;
            lbl_Nome.Font = new Font(lbl_Nome.Font, FontStyle.Bold);
            this.lbl_Nome.ForeColor = Color.White;
            this.Controls.Add(lbl_Nome);

            lbl_DataNasc = new Label ();
            lbl_DataNasc.Text = "Data de Nascimento: " + cliente.DataNascimento.ToString();
            lbl_DataNasc.Location = new Point (20, 190);            
            lbl_DataNasc.AutoSize = true;
            lbl_DataNasc.Font = new Font(lbl_DataNasc.Font, FontStyle.Bold);
            this.lbl_DataNasc.ForeColor = Color.White;
            this.Controls.Add(lbl_DataNasc);

            lbl_CPF = new Label ();
            lbl_CPF.Text = "CPF: " + cliente.CpfCliente;
            lbl_CPF.Location = new Point (20, 230);
            lbl_CPF.AutoSize = true;
            lbl_CPF.Font = new Font(lbl_CPF.Font, FontStyle.Bold);
            this.lbl_CPF.ForeColor = Color.White;
            this.Controls.Add(lbl_CPF);

            lbl_DiasDevol = new Label ();
            lbl_DiasDevol.Text = "Dias P/ Devolução: " + cliente.DiasDevolucao.ToString();
            lbl_DiasDevol.Location = new Point (20, 270);
            lbl_DiasDevol.AutoSize = true;
            lbl_DiasDevol.Font = new Font(lbl_DiasDevol.Font, FontStyle.Bold);
            this.lbl_DiasDevol.ForeColor = Color.White;
            this.Controls.Add(lbl_DiasDevol);

            // Detail customer grouping box
            gb_ClienteDetalhe = new GroupBox();
            gb_ClienteDetalhe.Location = new Point(10, 80);
            gb_ClienteDetalhe.Size = new Size(460, 240);
            gb_ClienteDetalhe.Text= "CONSULTA CLIENTES";
            gb_ClienteDetalhe.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ClienteDetalhe);

            // Buttons
            btn_SairDetalhe = new Button ();
            btn_SairDetalhe.Text = "SAIR";
            btn_SairDetalhe.Location = new Point (160, 340);
            btn_SairDetalhe.Size = new Size (150, 40);            
            this.btn_SairDetalhe.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_SairDetalhe.ForeColor = Color.Black;         
            btn_SairDetalhe.Click += new EventHandler (this.btn_SairDetalheClick);
            this.Controls.Add(btn_SairDetalhe);
        }

        /// <summary>
        /// Event button to exit and back to customer "consult" window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SairDetalheClick(object sender, EventArgs e)
        {
            MessageBox.Show ("CONCLUÍDO!");
            this.Close ();
            this.parent.Show ();    
        }
    }
}