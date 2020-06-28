using System;
using Models;
using Controllers;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public partial class CadastroLocacao : Form
    {
        public CadastroLocacao(Form parent)
        {
            InitializeComponent(parent);
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
        private void keypressed1(Object o, KeyPressEventArgs e)
        {
            lv_ListaClientes.Items.Clear();
            List<ClienteModels> listaCliente = (from cliente in ClienteController.GetClientes() where cliente.NomeCliente.Contains(rtxt_BuscaCliente.Text, StringComparison.OrdinalIgnoreCase) select cliente).ToList();
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
        /// Keypress event to find a movie
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void keypressed2(Object o, KeyPressEventArgs e)
        {
            lv_ListaFilmes.Items.Clear();
            List<FilmeModels> listaFilme = (from filme in FilmeController.GetFilmes() where filme.Titulo.Contains(rtxt_BuscaFilme.Text, StringComparison.OrdinalIgnoreCase) select filme).ToList();
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
        /// Event data button to enter information into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                if ((lv_ListaClientes.SelectedItems.Count > 0) && (lv_ListaFilmes.CheckedItems.Count > 0))
                {
                    string IdCliente = this.lv_ListaClientes.SelectedItems[0].Text;
                    ClienteModels cliente = ClienteController.GetCliente(Int32.Parse(IdCliente));
                    LocacaoModels locacao = LocacaoController.Add(cliente);

                    foreach (ListViewItem Filme in this.lv_ListaFilmes.CheckedItems)
                    {
                        FilmeModels filme = FilmeController.GetFilme(Int32.Parse(Filme.Text));
                        locacao.AdicionarFilme(filme);
                    }
                    MessageBox.Show("Locação Realizada!");
                    this.Close();
                    this.parent.Show();
                }
                else
                {
                    MessageBox.Show("Selecione o Cliente e Pelo Menos Um Filme!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Selecione o Cliente e Pelo Menos Um Filme!");
            }
        }

        /// <summary>
        /// Event button to cancel and back to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}