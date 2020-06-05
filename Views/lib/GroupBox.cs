using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public class GroupBox : System.Windows.Forms.GroupBox
    {
        public GroupBox()
        {
            this.ForeColor = ColorTranslator.FromHtml("#dfb841");            
            this.Size = new Size(230, 150); 
        }
    }
}