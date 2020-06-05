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
    public class ConsultaFilme : Form
    {
        Library.PictureBox pb_Consulta;
        Library.Label lbl_ConsultaFilme;
        Library.ToolTip tt_ConsultaFilme;
        Library.RichTextBox rtxt_ConsultaFilme;
        Library.ListView lv_ListaFilmes;
        Library.GroupBox gb_ListaFilme;
        Library.Button btn_ListaConsulta;
        Library.Button btn_ListaSair;
        Form parent;

        // Consult registered movies
        public ConsultaFilme(Form parent)
        {
            // Window parameters
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 620);
            this.parent = parent;

            // PictureBox
            this.pb_Consulta = new Library.PictureBox();
            this.pb_Consulta.Load("./Views/assets/consulta.jpg");
            this.Controls.Add(pb_Consulta);

            // Label
            this.lbl_ConsultaFilme = new Library.Label();
            this.lbl_ConsultaFilme.Text = "Buscar Filme :";
            this.lbl_ConsultaFilme.Location = new Point(30, 80);
            this.Controls.Add(lbl_ConsultaFilme);

            // Fill orientation tip
            this.tt_ConsultaFilme = new Library.ToolTip();

            // RichTextBox (Edited text - Keypress mode to filter a movie in ListView)
            this.rtxt_ConsultaFilme = new Library.RichTextBox();
            this.rtxt_ConsultaFilme.Location = new Point(150, 80);
            this.Controls.Add(rtxt_ConsultaFilme);
            this.tt_ConsultaFilme.SetToolTip(rtxt_ConsultaFilme, "Digite o título ou selecione abaixo");
            this.rtxt_ConsultaFilme.KeyPress += new KeyPressEventHandler(keypressed);

            // ListView - Movie
            this.lv_ListaFilmes = new Library.ListView();
            this.lv_ListaFilmes.Location = new Point(20, 130);
            this.lv_ListaFilmes.Size = new Size(440, 350);
            List<FilmeModels> listaFilme = (from filme in FilmeController.GetFilmes() where filme.Titulo.Contains(rtxt_ConsultaFilme.Text) select filme).ToList();
            ListViewItem filmes = new ListViewItem();
            foreach (FilmeModels filme in FilmeController.GetFilmes())
            {
                ListViewItem lv_ListaFilme = new ListViewItem(filme.IdFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.Titulo);
                lv_ListaFilme.SubItems.Add(filme.DataLancamento);
                lv_ListaFilme.SubItems.Add(filme.ValorLocacaoFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.EstoqueFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.Sinopse);
                lv_ListaFilmes.Items.Add(lv_ListaFilme);
            }
            this.lv_ListaFilmes.MultiSelect = false;
            this.lv_ListaFilmes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Título", -2, HorizontalAlignment.Left);
            this.lv_ListaFilmes.Columns.Add("Data Lançamento", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Preço", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Estoque", -2, HorizontalAlignment.Center);
            this.lv_ListaFilmes.Columns.Add("Sinopse", -2, HorizontalAlignment.Left);
            this.Controls.Add(lv_ListaFilmes);

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            // ListView grouping box
            this.gb_ListaFilme = new Library.GroupBox();
            this.gb_ListaFilme.Location = new Point(10, 110);
            this.gb_ListaFilme.Size = new Size(460, 380);
            this.gb_ListaFilme.Text = "LISTA DE FILMES";
            this.Controls.Add(gb_ListaFilme);

            // Buttons
            this.btn_ListaConsulta = new Library.Button();
            this.btn_ListaConsulta.Location = new Point(80, 510);
            this.btn_ListaConsulta.Text = "CONSULTA";
            this.btn_ListaConsulta.Click += new EventHandler(this.btn_ListaConsultaClick);
            this.Controls.Add(btn_ListaConsulta);

            this.btn_ListaSair = new Library.Button();
            this.btn_ListaSair.Location = new Point(260, 510);
            this.btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.Click += new EventHandler(this.btn_ListaSairClick);
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
        /// Keypress event to find a movie
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void keypressed(Object o, KeyPressEventArgs e)
        {
            lv_ListaFilmes.Items.Clear();
            List<FilmeModels> listaFilme = (from filme in FilmeController.GetFilmes() where filme.Titulo.Contains(rtxt_ConsultaFilme.Text, StringComparison.OrdinalIgnoreCase) select filme).ToList();
            ListViewItem filmes = new ListViewItem();
            foreach (FilmeModels filme in listaFilme)
            {
                ListViewItem lv_ListaFilme = new ListViewItem(filme.IdFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.Titulo);
                lv_ListaFilme.SubItems.Add(filme.DataLancamento);
                lv_ListaFilme.SubItems.Add(filme.Sinopse);
                lv_ListaFilme.SubItems.Add(filme.ValorLocacaoFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.EstoqueFilme.ToString());
                lv_ListaFilmes.Items.Add(lv_ListaFilme);
            }
            this.Refresh();
            Application.DoEvents();
        }

        /// <summary>
        /// Event button to consult a selected movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ListaConsultaClick(object sender, EventArgs e)
        {
            try
            {
                string IdFilme = this.lv_ListaFilmes.SelectedItems[0].Text;
                FilmeModels filme = FilmeController.GetFilme(Int32.Parse(IdFilme));
                FilmeDetalhe btn_ListaConsultaClick = new FilmeDetalhe(this, filme);
                btn_ListaConsultaClick.Show();
            }
            catch
            {
                MessageBox.Show("SELECIONE UM FILME!");
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