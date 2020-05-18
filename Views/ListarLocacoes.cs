using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class ListaLocacao : Form 
    {
        PictureBox pb_Lista;
        ListView lv_ListaLocacoes;
        GroupBox gb_ListaLocacoes;
        Button btn_Confirmar;
        Button btn_Cancelar;

        // GUIDE FOR LOCATION n SIZE (X Y) 
        // Location (X = Horizontal - Y = Vertical)
        // Size     (X = Largura    - Y = Altura) 

        public ListaLocacao () 
        {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600, 640);

            // Image to Bloclbuster
            pb_Lista = new PictureBox();
            pb_Lista.Location = new Point (10, 10);    
            pb_Lista.Size = new Size(180 , 100);
            pb_Lista.ClientSize = new Size (560 , 60);
            pb_Lista.BackColor = Color.Black;
            pb_Lista.Load ("lista.jpg");
            pb_Lista.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Lista); 

            // ListView
            lv_ListaLocacoes = new ListView();
            lv_ListaLocacoes.Location = new Point(20, 100);
            lv_ListaLocacoes.Size = new Size(540, 400);
            // lv_ListaLocacoes.View = View.Details;
            ListViewItem cliente1 = new ListViewItem("005");
            ListViewItem locacao1 = new ListViewItem("05");
            locacao1.SubItems.Add("Joao Silva");
            locacao1.SubItems.Add("111.111.111-11");            
            locacao1.SubItems.Add("01/01/2020");
            locacao1.SubItems.Add("3");            
            locacao1.SubItems.Add("R$ 9.99");           
            locacao1.SubItems.Add("Crédito");            
            ListViewItem locacao2 = new ListViewItem("122");
            locacao2.SubItems.Add("Joao Andrade");
            locacao2.SubItems.Add("222.222.222-22");
            locacao2.SubItems.Add("02/02/2020");
            locacao2.SubItems.Add("2");
            locacao2.SubItems.Add("R$ 6.99");
            locacao2.SubItems.Add("Dinheiro");
            ListViewItem locacao3 = new ListViewItem("325");
            locacao3.SubItems.Add("Larissa Junqueira");
            locacao3.SubItems.Add("333.333.333-33");
            locacao3.SubItems.Add("03/03/2020");
            locacao3.SubItems.Add("5");
            locacao3.SubItems.Add("R$ 15.99");
            locacao3.SubItems.Add("Dinheiro");
            ListViewItem locacao4 = new ListViewItem("326");
            locacao4.SubItems.Add("Mara Leão");
            locacao4.SubItems.Add("444.444.444-44");
            locacao4.SubItems.Add("04/04/2020");
            locacao4.SubItems.Add("2");
            locacao4.SubItems.Add("R$ 5.99");
            locacao4.SubItems.Add("Débito");
            ListViewItem locacao5 = new ListViewItem("375");
            locacao5.SubItems.Add("Valeria Antonio");
            locacao5.SubItems.Add("555.555.555-55");
            locacao5.SubItems.Add("05/05/2020");
            locacao5.SubItems.Add("4");
            locacao5.SubItems.Add("R$ 12.99");
            locacao5.SubItems.Add("Cheque");
            lv_ListaLocacoes.Items.AddRange(new ListViewItem[]{locacao1, locacao2, locacao3, locacao4, locacao5});
            lv_ListaLocacoes.FullRowSelect = true;
            lv_ListaLocacoes.GridLines = true;
            lv_ListaLocacoes.AllowColumnReorder = true;
            lv_ListaLocacoes.Sorting = SortOrder.Ascending;
            lv_ListaLocacoes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Nome", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Data", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Qtde", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Total", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Pagto", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaLocacoes);

            // Movie grouping box
            gb_ListaLocacoes = new GroupBox();
            gb_ListaLocacoes.Location = new Point(10, 80);
            gb_ListaLocacoes.Size = new Size(560, 430);
            gb_ListaLocacoes.Text= "LISTA DE LOCAÇÕES";
            gb_ListaLocacoes.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_ListaLocacoes); 

            // Descision Buttons
            btn_Confirmar = new Button ();
            btn_Confirmar.Text = "CONFIRMAR";
            btn_Confirmar.Location = new Point (125, 530);
            btn_Confirmar.Size = new Size (150, 40);  
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Confirmar.ForeColor = Color.Black;          
            btn_Confirmar.Click += new EventHandler (this.btn_ConfirmarClick);
            this.Controls.Add (btn_Confirmar);

            btn_Cancelar = new Button ();
            btn_Cancelar.Text = "CANCELAR";
            btn_Cancelar.Location = new Point (305, 530);
            btn_Cancelar.Size = new Size (150, 40);  
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Cancelar.ForeColor = Color.Black;          
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add (btn_Cancelar);
        }

        private void btn_ConfirmarClick (object sender, EventArgs e) 
        {
            MessageBox.Show (
                $"IdCliente.:> {lv_ListaLocacoes.Text}\n",
                "Cliente",
                MessageBoxButtons.OK
            );
        }

        private void btn_CancelarClick (object sender, EventArgs e) 
        {
           MessageBox.Show("Cancelado!!");
            this.Close();
            TelaInicial telaInicial = new TelaInicial();
            telaInicial.Show();
        }
    }
}