using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public class Button : System.Windows.Forms.Button
    {

        public Button()
        {            
            this.Size = new Size(150, 50);
            this.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.ForeColor = Color.Black;
        }
    }
}