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
        PictureBox pb_Consulta;
        Label lbl_ConsultaFilme;
        ToolTip tt_ConsultaFilme;
        RichTextBox rtxt_ConsultaFilme;
        ListView lv_ListaFilmes;
        GroupBox gb_ListaFilme;
        Button btn_ListaConsulta;
        Button btn_ListaSair;
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
            pb_Consulta = new PictureBox();
            pb_Consulta.Location = new Point(10, 10);
            pb_Consulta.Size = new Size(480, 100);
            pb_Consulta.ClientSize = new Size(460, 60);
            pb_Consulta.BackColor = Color.Black;
            pb_Consulta.Load("./Views/assets/consulta.jpg");
            pb_Consulta.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Consulta);

            // Label
            lbl_ConsultaFilme = new Label();
            lbl_ConsultaFilme.Text = "Buscar Filme :";
            lbl_ConsultaFilme.Location = new Point(30, 80);
            lbl_ConsultaFilme.AutoSize = true;
            this.Controls.Add(lbl_ConsultaFilme);

            // Fill orientation tip
            tt_ConsultaFilme = new ToolTip();
            tt_ConsultaFilme.AutoPopDelay = 5000;
            tt_ConsultaFilme.InitialDelay = 1000;
            tt_ConsultaFilme.ReshowDelay = 500;
            tt_ConsultaFilme.ShowAlways = true;

            // RichTextBox (Edited text - Keypress mode to filter a movie in ListView)
            rtxt_ConsultaFilme = new RichTextBox();
            rtxt_ConsultaFilme.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);
            rtxt_ConsultaFilme.SelectionColor = System.Drawing.Color.Black;
            rtxt_ConsultaFilme.Location = new Point(150, 80);
            rtxt_ConsultaFilme.Size = new Size(300, 20);
            this.Controls.Add(rtxt_ConsultaFilme);
            tt_ConsultaFilme.SetToolTip(rtxt_ConsultaFilme, "Digite o título ou selecione abaixo");
            rtxt_ConsultaFilme.KeyPress += new KeyPressEventHandler(keypressed);

            // ListView - Movie
            lv_ListaFilmes = new ListView();
            lv_ListaFilmes.Location = new Point(20, 130);
            lv_ListaFilmes.Size = new Size(440, 350);
            lv_ListaFilmes.View = Details;
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
            lv_ListaFilmes.FullRowSelect = true;
            lv_ListaFilmes.GridLines = true;
            lv_ListaFilmes.AllowColumnReorder = true;
            lv_ListaFilmes.Sorting = SortOrder.None;
            lv_ListaFilmes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Título", -2, HorizontalAlignment.Left);
            lv_ListaFilmes.Columns.Add("Data Lançamento", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Preço", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Estoque", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Sinopse", -2, HorizontalAlignment.Left);
            this.Controls.Add(lv_ListaFilmes);

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            // ListView grouping box
            gb_ListaFilme = new GroupBox();
            gb_ListaFilme.Location = new Point(10, 110);
            gb_ListaFilme.Size = new Size(460, 380);
            gb_ListaFilme.Text = "LISTA DE FILMES";
            gb_ListaFilme.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaFilme);

            // Buttons
            btn_ListaConsulta = new Button();
            btn_ListaConsulta.Location = new Point(80, 510);
            btn_ListaConsulta.Size = new Size(150, 50);
            btn_ListaConsulta.Text = "CONSULTA";
            this.btn_ListaConsulta.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaConsulta.ForeColor = Color.Black;
            btn_ListaConsulta.Click += new EventHandler(this.btn_ListaConsultaClick);
            this.Controls.Add(btn_ListaConsulta);

            btn_ListaSair = new Button();
            btn_ListaSair.Location = new Point(260, 510);
            btn_ListaSair.Size = new Size(150, 50);
            btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaSair.ForeColor = Color.Black;
            btn_ListaSair.Click += new EventHandler(this.btn_ListaSairClick);
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