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
    public class ConsultaLocacao : Form 
    {
        PictureBox pb_Consulta;
        Label lbl_NomeLocacao;
        Label lbl_NomeFilme;
        RichTextBox rtxt_NomeLocacao;
        RichTextBox rtxt_NomeFilme;
        ListView lv_ListaLocacoes;
        GroupBox gb_ConsultaLocacao;
        GroupBox gb_ListaLocacoes;
        Button btn_ListaConsulta;
        Button btn_Cancelar; 
        Form parent;

            // GUIDE FOR LOCATION n SIZE (X Y) 
            // Location (X = Horizontal - Y = Vertical)
            // Size     (X = Largura    - Y = Altura)

        public ConsultaLocacao (Form parent) {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 500);
            this.parent = parent;

            // Image to Bloclbuster
            pb_Consulta = new PictureBox();
            pb_Consulta.Location = new Point (10, 10);    
            pb_Consulta.Size = new Size(480 , 100);
            pb_Consulta.ClientSize = new Size (460 , 60);
            pb_Consulta.BackColor = Color.Black;
            pb_Consulta.Load ("./Views/assets/locacao.jpg");
            pb_Consulta.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Consulta);

            lbl_NomeLocacao = new Label ();
            lbl_NomeLocacao.Text = "Nome do Locacao :";
            lbl_NomeLocacao.Location = new Point (20, 100);
            lbl_NomeLocacao.AutoSize = true;            
            this.Controls.Add (lbl_NomeLocacao);

            lbl_NomeFilme = new Label ();
            lbl_NomeFilme.Text = "Nome do Filme :";
            lbl_NomeFilme.Location = new Point (20, 140);
            lbl_NomeFilme.AutoSize = true;            
            this.Controls.Add (lbl_NomeFilme);

            rtxt_NomeLocacao = new RichTextBox ();
            rtxt_NomeLocacao.SelectionFont  = new Font("Tahoma", 10, FontStyle.Bold);  
            rtxt_NomeLocacao.SelectionColor = System.Drawing.Color.Black;
            rtxt_NomeLocacao.Location = new Point (150, 100);
            rtxt_NomeLocacao.Size = new Size (300, 20);
            this.Controls.Add (rtxt_NomeLocacao);
            rtxt_NomeLocacao.KeyPress += new KeyPressEventHandler(keypressed1);

            rtxt_NomeFilme = new RichTextBox ();
            rtxt_NomeFilme.SelectionFont  = new Font("Tahoma", 10, FontStyle.Bold);  
            rtxt_NomeFilme.SelectionColor = System.Drawing.Color.Black;
            rtxt_NomeFilme.Location = new Point (150, 140);
            rtxt_NomeFilme.Size = new Size (300, 20);
            this.Controls.Add (rtxt_NomeFilme);
            rtxt_NomeFilme.KeyPress += new KeyPressEventHandler(keypressed2);

            // ListView
            lv_ListaLocacoes = new ListView();
            lv_ListaLocacoes.Location = new Point(30, 210);
            lv_ListaLocacoes.Size = new Size(420, 140);
            lv_ListaLocacoes.View = View.Details;
            //List<LocacaoModels> listaLocacao = (from locacao in LocacaoController.GetLocacoes() where locacao.NomeLocacao.Contains(rtxt_ConsultaLocacao.Text) select Locacao).ToList();
            ListViewItem locacoes = new ListViewItem();
            foreach (LocacaoModels locacao in LocacaoController.GetLocacoes())
            {
                ListViewItem lv_ListaLocacao = new ListViewItem(locacao.IdLocacao.ToString());
                // lv_ListaLocacao.SubItems.Add(locacao.IdLocacao);
                // lv_ListaLocacao.SubItems.Add(locacao.IdLocacao);
                lv_ListaLocacoes.Items.Add(lv_ListaLocacao);
            }
            lv_ListaLocacoes.FullRowSelect = true;
            lv_ListaLocacoes.GridLines = true;
            lv_ListaLocacoes.AllowColumnReorder = true;
            lv_ListaLocacoes.Sorting = SortOrder.Ascending;
            lv_ListaLocacoes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Locatário", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Qtde Filmes", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Total", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Pagto", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaLocacoes);

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            // Customer grouping box
            gb_ConsultaLocacao = new GroupBox();    
            gb_ConsultaLocacao.Location = new Point(10, 80);        
            gb_ConsultaLocacao.Size = new Size(460, 100);            
            gb_ConsultaLocacao.Text= "BUSCAR LOCAÇÃO";
            gb_ConsultaLocacao.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ConsultaLocacao);
            
            gb_ListaLocacoes = new GroupBox();    
            gb_ListaLocacoes.Location = new Point(10, 190);        
            gb_ListaLocacoes.Size = new Size(460, 170);            
            gb_ListaLocacoes.Text= "LISTA DE FILMES";
            gb_ListaLocacoes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaLocacoes);

            btn_ListaConsulta = new Button ();
            btn_ListaConsulta.Location = new Point (80, 390);
            btn_ListaConsulta.Size = new Size (150, 40);            
            btn_ListaConsulta.Text = "CONSULTA";
            this.btn_ListaConsulta.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_ListaConsulta.ForeColor = Color.Black; 
            btn_ListaConsulta.Click += new EventHandler (this.btn_ListaConsultaClick);
            this.Controls.Add(btn_ListaConsulta);

            btn_Cancelar = new Button ();
            btn_Cancelar.Location = new Point (260, 390);
            btn_Cancelar.Size = new Size (150, 40);           
            btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Cancelar.ForeColor = Color.Black;
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
        }

        public void RefreshForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.RefreshForm));
            }
            Application.DoEvents();
        }

        private void keypressed1(Object o, KeyPressEventArgs e)
        {
            // lv_ListaLocacaos.Items.Clear();
            // List<LocacaoModels> listaLocacao = (from Locacao in LocacaoController.GetLocacaos() where Locacao.NomeLocacao.Contains(rtxt_BuscaLocacao.Text, StringComparison.OrdinalIgnoreCase) select Locacao).ToList();
            // ListViewItem Locacaos = new ListViewItem();
            // foreach (LocacaoModels Locacao in listaLocacao)
            // {
            //     ListViewItem lv_ListaLocacao = new ListViewItem(Locacao.IdLocacao.ToString());
            //     lv_ListaLocacao.SubItems.Add(Locacao.NomeLocacao);
            //     lv_ListaLocacao.SubItems.Add(Locacao.DataNascimento);
            //     lv_ListaLocacao.SubItems.Add(Locacao.CpfLocacao);
            //     lv_ListaLocacao.SubItems.Add(Locacao.DiasDevolucao.ToString());
            //     lv_ListaLocacaos.Items.Add(lv_ListaLocacao);
            // }
            // this.Refresh();
            // Application.DoEvents();
        }

        private void keypressed2(Object o, KeyPressEventArgs e)
        {
            // lv_ListaFilmes.Items.Clear();
            // List<FilmeModels> listaFilme = (from filme in FilmeController.GetFilmes() where filme.Titulo.Contains(rtxt_BuscaFilme.Text, StringComparison.OrdinalIgnoreCase) select filme).ToList();
            // ListViewItem filmes = new ListViewItem();
            // foreach (FilmeModels filme in listaFilme)
            // {
            //     ListViewItem lv_ListaFilme = new ListViewItem(filme.IdFilme.ToString());
            //     lv_ListaFilme.SubItems.Add(filme.Titulo);
            //     lv_ListaFilme.SubItems.Add(filme.DataLancamento);
            //     lv_ListaFilme.SubItems.Add(filme.Sinopse);
            //     lv_ListaFilme.SubItems.Add(filme.ValorLocacaoFilme.ToString());
            //     lv_ListaFilme.SubItems.Add(filme.EstoqueFilme.ToString());
            //     lv_ListaFilmes.Items.Add(lv_ListaFilme);
            // }
            // this.Refresh();
            // Application.DoEvents();
        }

        private void btn_ListaConsultaClick (object sender, EventArgs e) 
        {
            string IdLocacao = this.lv_ListaLocacoes.SelectedItems[0].Text;
            LocacaoModels locacao = LocacaoController.GetLocacao(Int32.Parse(IdLocacao));
            LocacaoDetalhe btn_ListaConsultaClick = new LocacaoDetalhe(this, locacao);
            btn_ListaConsultaClick.Show();
        }

        private void btn_CancelarClick (object sender, EventArgs e) 
        {
            MessageBox.Show("CONCLUÍDO!");
            this.Close();
            this.parent.Show();  
        }
    }
}