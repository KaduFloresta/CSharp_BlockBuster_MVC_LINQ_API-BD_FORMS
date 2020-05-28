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
    public class LocacaoDetalhe : Form
    {
        PictureBox pb_Detalhe;
        Label lbl_IdCliente;
        Label lbl_NomeCliente;
        Label lbl_DataNascimento;
        Label lbl_CpfCliente;
        Label lbl_IdLocacao;
        Label lbl_DataLocacao;
        Label lbl_DataDevolucao;
        Label lbl_QtdeFilmes;
        Label lbl_ValorTotal;
        RichTextBox rtxt_Filmes;
        GroupBox gb_DadosCliente;
        GroupBox gb_DadosLocacao;
        GroupBox gb_DadosFIlmes;
        Button btn_SairDetalhe;
        Form parent;

        int idLocacao;
        LocacaoModels locacaoX;

        // Detailed rental window
        public LocacaoDetalhe(Form parent, LocacaoModels locacao)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600, 640);
            this.idLocacao = locacao.IdLocacao;
            this.locacaoX = locacao;
            this.parent = parent;

            // PictureBox
            pb_Detalhe = new PictureBox();
            pb_Detalhe.Location = new Point(10, 10);
            pb_Detalhe.Size = new Size(180, 100);
            pb_Detalhe.ClientSize = new Size(560, 60);
            pb_Detalhe.BackColor = Color.Black;
            pb_Detalhe.Load("./Views/assets/Locacao.jpg");
            pb_Detalhe.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Detalhe);

            ClienteModels cliente = ClienteController.GetCliente(locacao.IdCliente);

            // Label + Database Informations
            lbl_IdCliente = new Label();
            lbl_IdCliente.Text = "ID do Cliente: " + locacao.IdCliente.ToString();
            lbl_IdCliente.Location = new Point(20, 105);
            lbl_IdCliente.AutoSize = true;
            lbl_IdCliente.Font = new Font(lbl_IdCliente.Font, FontStyle.Bold);
            this.lbl_IdCliente.ForeColor = Color.White;
            this.Controls.Add(lbl_IdCliente);

            lbl_NomeCliente = new Label();
            lbl_NomeCliente.Text = "Nome: " + cliente.NomeCliente;
            lbl_NomeCliente.Location = new Point(20, 135);
            lbl_NomeCliente.AutoSize = true;
            lbl_NomeCliente.Font = new Font(lbl_NomeCliente.Font, FontStyle.Bold);
            this.lbl_NomeCliente.ForeColor = Color.White;
            this.Controls.Add(lbl_NomeCliente);

            lbl_DataNascimento = new Label();
            lbl_DataNascimento.Text = "Data de Nascimento: " + cliente.DataNascimento;
            lbl_DataNascimento.Location = new Point(20, 165);
            lbl_DataNascimento.AutoSize = true;
            lbl_DataNascimento.Font = new Font(lbl_DataNascimento.Font, FontStyle.Bold);
            this.lbl_DataNascimento.ForeColor = Color.White;
            this.Controls.Add(lbl_DataNascimento);

            lbl_CpfCliente = new Label();
            lbl_CpfCliente.Text = "CPF: " + cliente.CpfCliente;
            lbl_CpfCliente.Location = new Point(300, 165);
            lbl_CpfCliente.AutoSize = true;
            lbl_CpfCliente.Font = new Font(lbl_CpfCliente.Font, FontStyle.Bold);
            this.lbl_CpfCliente.ForeColor = Color.White;
            this.Controls.Add(lbl_CpfCliente);

            lbl_IdLocacao = new Label();
            lbl_IdLocacao.Text = "ID da Locação: " + locacao.IdLocacao.ToString();
            lbl_IdLocacao.Location = new Point(20, 235);
            lbl_IdLocacao.AutoSize = true;
            lbl_IdLocacao.Font = new Font(lbl_IdLocacao.Font, FontStyle.Bold);
            this.lbl_IdLocacao.ForeColor = Color.White;
            this.Controls.Add(lbl_IdLocacao);

            lbl_DataLocacao = new Label();
            lbl_DataLocacao.Text = "Data da Locação: " + locacao.DataLocacao.ToString("dd/MM/yyyy");
            lbl_DataLocacao.Location = new Point(20, 265);
            lbl_DataLocacao.AutoSize = true;
            lbl_DataLocacao.Font = new Font(lbl_DataLocacao.Font, FontStyle.Bold);
            this.lbl_DataLocacao.ForeColor = Color.White;
            this.Controls.Add(lbl_DataLocacao);

            lbl_DataDevolucao = new Label();
            lbl_DataDevolucao.Text = "Data de Devolução: " + locacao.CalculoDataDevol().ToString("dd/MM/yyyy");
            lbl_DataDevolucao.Location = new Point(300, 265);
            lbl_DataDevolucao.AutoSize = true;
            lbl_DataDevolucao.Font = new Font(lbl_DataDevolucao.Font, FontStyle.Bold);
            this.lbl_DataDevolucao.ForeColor = Color.White;
            this.Controls.Add(lbl_DataDevolucao);

            lbl_QtdeFilmes = new Label();
            lbl_QtdeFilmes.Text = "Quantidade de Filmes: " + locacao.QtdeFilmes().ToString();
            lbl_QtdeFilmes.Location = new Point(20, 295);
            lbl_QtdeFilmes.AutoSize = true;
            lbl_QtdeFilmes.Font = new Font(lbl_QtdeFilmes.Font, FontStyle.Bold);
            this.lbl_QtdeFilmes.ForeColor = Color.White;
            this.Controls.Add(lbl_QtdeFilmes);

            lbl_ValorTotal = new Label();
            lbl_ValorTotal.Text = "Total da Locação: " + locacao.ValorTotal().ToString("C2");
            lbl_ValorTotal.Location = new Point(300, 295);
            lbl_ValorTotal.AutoSize = true;
            lbl_ValorTotal.Font = new Font(lbl_ValorTotal.Font, FontStyle.Bold);
            this.lbl_ValorTotal.ForeColor = Color.White;
            this.Controls.Add(lbl_ValorTotal);

            rtxt_Filmes = new RichTextBox();
            rtxt_Filmes.Text = "" + locacao.FilmesLocados();
            rtxt_Filmes.Location = new Point(20, 365);
            rtxt_Filmes.Size = new Size(540, 100);
            rtxt_Filmes.Font = new Font(rtxt_Filmes.Font, FontStyle.Bold);
            this.rtxt_Filmes.ForeColor = Color.Black;
            this.Controls.Add(rtxt_Filmes);

            // Detail (data customer) grouping box
            gb_DadosCliente = new GroupBox();
            gb_DadosCliente.Location = new Point(10, 80);
            gb_DadosCliente.Size = new Size(560, 120);
            gb_DadosCliente.Text = "DADOS CLIENTE";
            gb_DadosCliente.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_DadosCliente);

            // Detail (data rent) grouping box
            gb_DadosLocacao = new GroupBox();
            gb_DadosLocacao.Location = new Point(10, 210);
            gb_DadosLocacao.Size = new Size(560, 120);
            gb_DadosLocacao.Text = "DADOS LOCAÇÃO";
            gb_DadosLocacao.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_DadosLocacao);

            // Detail (data rented movies) grouping box
            gb_DadosFIlmes = new GroupBox();
            gb_DadosFIlmes.Location = new Point(10, 340);
            gb_DadosFIlmes.Size = new Size(560, 180);
            gb_DadosFIlmes.Text = "LISTA DE FILMES LOCADOS";
            gb_DadosFIlmes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_DadosFIlmes);

            // Buttons
            btn_SairDetalhe = new Button();
            btn_SairDetalhe.Text = "SAIR";
            btn_SairDetalhe.Location = new Point(215, 535);
            btn_SairDetalhe.Size = new Size(150, 40);
            this.btn_SairDetalhe.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_SairDetalhe.ForeColor = Color.Black;
            btn_SairDetalhe.Click += new EventHandler(this.btn_SairDetalheClick);
            this.Controls.Add(btn_SairDetalhe);
        }

        /// <summary>
        /// Event button to exit and back to rental "consult" window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SairDetalheClick(object sender, EventArgs e)
        {
            MessageBox.Show ("CONCLUÍDO!");
            this.Close();
            this.parent.Show();
        }
    }
}