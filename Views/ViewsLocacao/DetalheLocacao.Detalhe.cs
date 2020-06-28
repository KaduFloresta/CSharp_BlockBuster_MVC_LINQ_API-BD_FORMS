using System;
using Models;
using Library;
using Controllers;
using System.Drawing;
using System.Windows.Forms;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    partial class LocacaoDetalhe : Form
    {
        Library.PictureBox pb_Detalhe;
        Library.Label lbl_IdCliente;
        Library.Label lbl_NomeCliente;
        Library.Label lbl_DataNascimento;
        Library.Label lbl_CpfCliente;
        Library.Label lbl_IdLocacao;
        Library.Label lbl_DataLocacao;
        Library.Label lbl_DataDevolucao;
        Library.Label lbl_QtdeFilmes;
        Library.Label lbl_ValorTotal;
        Library.RichTextBox rtxt_Filmes;
        Library.GroupBox gb_DadosCliente;
        Library.GroupBox gb_DadosLocacao;
        Library.GroupBox gb_DadosFIlmes;
        Library.ButtonDetail btn_SairDetalhe;
        Library.ButtonDetail btn_DeleteLocacao;
        Form parent;

        int idLocacao;
        LocacaoModels locacaoX;

        // Detailed rental window
        public void InitializeComponent(Form parent, LocacaoModels locacao)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600, 615);
            this.idLocacao = locacao.IdLocacao;
            this.locacaoX = locacao;
            this.parent = parent;

            // PictureBox
            this.pb_Detalhe = new Library.PictureBox();
            this.pb_Detalhe.Load("./Views/assets/Locacao.jpg");
            this.Controls.Add(pb_Detalhe);

            ClienteModels cliente = ClienteController.GetCliente(locacao.IdCliente);

            // Label + Database Informations
            this.lbl_IdCliente = new Library.Label();
            this.lbl_IdCliente.Text = "ID do Cliente: " + locacao.IdCliente.ToString();
            this.lbl_IdCliente.Location = new Point(20, 105);
            this.Controls.Add(lbl_IdCliente);

            this.lbl_NomeCliente = new Library.Label();
            this.lbl_NomeCliente.Text = "Nome: " + cliente.NomeCliente;
            this.lbl_NomeCliente.Location = new Point(20, 135);
            this.Controls.Add(lbl_NomeCliente);

            this.lbl_DataNascimento = new Library.Label();
            this.lbl_DataNascimento.Text = "Data de Nascimento: " + cliente.DataNascimento;
            this.lbl_DataNascimento.Location = new Point(20, 165);
            this.Controls.Add(lbl_DataNascimento);

            this.lbl_CpfCliente = new Library.Label();
            this.lbl_CpfCliente.Text = "CPF: " + cliente.CpfCliente;
            this.lbl_CpfCliente.Location = new Point(300, 165);
            this.Controls.Add(lbl_CpfCliente);

            this.lbl_IdLocacao = new Library.Label();
            this.lbl_IdLocacao.Text = "ID da Locação: " + locacao.IdLocacao.ToString();
            this.lbl_IdLocacao.Location = new Point(20, 235);
            this.Controls.Add(lbl_IdLocacao);

            this.lbl_DataLocacao = new Library.Label();
            this.lbl_DataLocacao.Text = "Data da Locação: " + locacao.DataLocacao.ToString("dd/MM/yyyy");
            this.lbl_DataLocacao.Location = new Point(20, 265);
            this.Controls.Add(lbl_DataLocacao);

            this.lbl_DataDevolucao = new Library.Label();
            this.lbl_DataDevolucao.Text = "Data de Devolução: " + locacao.CalculoDataDevol().ToString("dd/MM/yyyy");
            this.lbl_DataDevolucao.Location = new Point(300, 265);
            this.Controls.Add(lbl_DataDevolucao);

            this.lbl_QtdeFilmes = new Library.Label();
            this.lbl_QtdeFilmes.Text = "Quantidade de Filmes: " + locacao.QtdeFilmes().ToString();
            this.lbl_QtdeFilmes.Location = new Point(20, 295);
            this.Controls.Add(lbl_QtdeFilmes);

            this.lbl_ValorTotal = new Library.Label();
            this.lbl_ValorTotal.Text = "Total da Locação: " + locacao.ValorTotal().ToString("C2");
            this.lbl_ValorTotal.Location = new Point(300, 295);
            this.Controls.Add(lbl_ValorTotal);

            this.rtxt_Filmes = new Library.RichTextBox();
            this.rtxt_Filmes.Text = "" + locacao.FilmesLocados();
            this.rtxt_Filmes.Location = new Point(20, 365);
            this.rtxt_Filmes.Size = new Size(540, 100);
            this.rtxt_Filmes.ReadOnly = true;
            this.Controls.Add(rtxt_Filmes);

            // Detail (data customer) grouping box
            this.gb_DadosCliente = new Library.GroupBox();
            this.gb_DadosCliente.Location = new Point(10, 80);
            this.gb_DadosCliente.Size = new Size(560, 120);
            this.gb_DadosCliente.Text = "DADOS CLIENTE";
            this.Controls.Add(gb_DadosCliente);

            // Detail (data rent) grouping box
            this.gb_DadosLocacao = new Library.GroupBox();
            this.gb_DadosLocacao.Location = new Point(10, 210);
            this.gb_DadosLocacao.Size = new Size(560, 120);
            this.gb_DadosLocacao.Text = "DADOS LOCAÇÃO";
            this.Controls.Add(gb_DadosLocacao);

            // Detail (data rented movies) grouping box
            this.gb_DadosFIlmes = new Library.GroupBox();
            this.gb_DadosFIlmes.Location = new Point(10, 340);
            this.gb_DadosFIlmes.Size = new Size(560, 145);
            this.gb_DadosFIlmes.Text = "LISTA DE FILMES LOCADOS";
            this.Controls.Add(gb_DadosFIlmes);

            // Delete Button
            this.btn_DeleteLocacao = new Library.ButtonDetail(ButtonType.Delete);
            this.btn_DeleteLocacao.Text = "DELETAR";
            this.btn_DeleteLocacao.Location = new Point(120, 505);
            this.btn_DeleteLocacao.BackColor = ColorTranslator.FromHtml("#e98274");
            this.btn_DeleteLocacao.Click += new EventHandler(this.btn_DeleteLocacaoClick);
            this.Controls.Add(btn_DeleteLocacao);

            // Exit Button
            this.btn_SairDetalhe = new Library.ButtonDetail(ButtonType.Sair);
            this.btn_SairDetalhe.Text = "SAIR";
            this.btn_SairDetalhe.Location = new Point(320, 505);
            this.btn_SairDetalhe.BackColor = ColorTranslator.FromHtml("#5de96e");
            this.btn_SairDetalhe.Click += new EventHandler(this.btn_SairDetalheClick);
            this.Controls.Add(btn_SairDetalhe);
        }
    }
}