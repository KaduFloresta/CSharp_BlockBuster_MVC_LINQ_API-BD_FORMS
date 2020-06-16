using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public enum ButtonType
    {
        Sair,
        Update,
        Delete
    }
    public class ButtonDetail : System.Windows.Forms.Button
    {
        public ButtonDetail(ButtonType type)
        {
            switch (type)
            {
                case ButtonType.Sair:
                this.MouseEnter += new EventHandler(this.btn_SairDetalheEnter);
                this.MouseLeave += new EventHandler(this.btn_SairDetalheLeave);
                    break; 
                case ButtonType.Update:
                this.MouseEnter += new EventHandler(this.btn_UpdateDetalheEnter);
                this.MouseLeave += new EventHandler(this.btn_UpdateDetalheLeave);
                    break;                
                case ButtonType.Delete:
                this.MouseEnter += new EventHandler(this.btn_DeleteDetalheEnter);  
                this.MouseLeave += new EventHandler(this.btn_DeleteDetalheLeave);
                    break;
                default:
                break;
            }              
        }
        
        // Mouse event to change color of button
        // Event Enter
        private void btn_SairDetalheEnter(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#13bf28");
        }
        private void btn_SairDetalheLeave(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#5de96e");
        }
        // Event Leave
        private void btn_UpdateDetalheEnter(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#ddd728");
        }
        private void btn_UpdateDetalheLeave(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#efeb7f");
        }
        private void btn_DeleteDetalheEnter(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#e7331a");
        }
        private void btn_DeleteDetalheLeave(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#e98274");
        }
    }
}