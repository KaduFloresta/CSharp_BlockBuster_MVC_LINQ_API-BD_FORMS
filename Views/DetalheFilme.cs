using System;
using Models;
using System.Drawing;
using System.Windows.Forms;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public class FilmeDetalhe : Form
    {
        Library.PictureBox pb_Detalhe;
        Library.Label lbl_IdFilme;
        Library.Label lbl_Titulo;
        Library.Label lbl_DataLancamento;
        Library.Label lbl_Sinopse;
        RichTextBox rtxt_Sinopse;
        Library.Label lbl_ValorFilme;
        Library.Label lbl_QtdeFilme;
        Library.GroupBox gb_FilmeDetalhe;
        Library.Button btn_SairDetalhe;
        Form parent;

        int idFilme;
        FilmeModels FilmeX;

        // Detailed movie window
        public FilmeDetalhe(Form parent, FilmeModels filme)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 565);
            this.idFilme = filme.IdFilme;
            this.FilmeX = filme;
            this.parent = parent;

            // PictureBox
            this.pb_Detalhe = new Library.PictureBox();
            this.pb_Detalhe.Load("./Views/assets/filme.jpg");
            this.Controls.Add(pb_Detalhe);

            // Label + Database Informations
            this.lbl_IdFilme = new Library.Label();
            this.lbl_IdFilme.Text = "ID do Filme: " + filme.IdFilme;
            this.lbl_IdFilme.Location = new Point(20, 110);
            this.Controls.Add(lbl_IdFilme);

            this.lbl_Titulo = new Library.Label();
            this.lbl_Titulo.Text = "Título: " + filme.Titulo;
            this.lbl_Titulo.Location = new Point(20, 150);
            this.Controls.Add(lbl_Titulo);

            this.lbl_DataLancamento = new Library.Label();
            this.lbl_DataLancamento.Text = "Data de Lançamento: " + filme.DataLancamento.ToString();
            this.lbl_DataLancamento.Location = new Point(20, 190);
            this.Controls.Add(lbl_DataLancamento);

            this.lbl_Sinopse = new Library.Label();
            this.lbl_Sinopse.Text = "Sinopse: ";
            this.lbl_Sinopse.Location = new Point(20, 230);
            this.Controls.Add(lbl_Sinopse);

            this.rtxt_Sinopse = new Library.RichTextBox();
            this.rtxt_Sinopse.Text = "" + filme.Sinopse;
            this.rtxt_Sinopse.Location = new Point(20, 250);
            this.rtxt_Sinopse.Size = new Size(440, 80);
            this.rtxt_Sinopse.ReadOnly = true;
            this.Controls.Add(rtxt_Sinopse);

            this.lbl_ValorFilme = new Library.Label();
            this.lbl_ValorFilme.Text = "Preço Aluguel: " + filme.ValorLocacaoFilme.ToString();
            this.lbl_ValorFilme.Location = new Point(20, 360);
            this.Controls.Add(lbl_ValorFilme);

            this.lbl_QtdeFilme = new Library.Label();
            this.lbl_QtdeFilme.Text = "Quantidade Estoque: " + filme.EstoqueFilme.ToString();
            this.lbl_QtdeFilme.Location = new Point(20, 400);
            this.Controls.Add(lbl_QtdeFilme);

            // Detail movie grouping box
            this.gb_FilmeDetalhe = new Library.GroupBox();
            this.gb_FilmeDetalhe.Location = new Point(10, 80);
            this.gb_FilmeDetalhe.Size = new Size(460, 360);
            this.gb_FilmeDetalhe.Text = "CONSULTA FILMES";
            this.Controls.Add(gb_FilmeDetalhe);

            // Buttons
            this.btn_SairDetalhe = new Library.Button();
            this.btn_SairDetalhe.Text = "SAIR";
            this.btn_SairDetalhe.Location = new Point(160, 460);
            this.btn_SairDetalhe.Click += new EventHandler(this.btn_SairDetalheClick);
            this.Controls.Add(btn_SairDetalhe);
        }

        /// <summary>
        /// Event button to exit and back to movie "consult" window
        /// </summary
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