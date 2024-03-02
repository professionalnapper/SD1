using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WhiskersAndWags
{
    public class CeLearningTextbox:Control
    {
        private int radius = 15;
        public TextBox textbox = new TextBox();
        private GraphicsPath shape;
        private GraphicsPath innerRect;
        private Color br;

        public CeLearningTextbox()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            this.textbox.Parent = this;
            base.Controls.Add(this.textbox);
            this.textbox.BorderStyle = BorderStyle.None;
            textbox.Font = this.Font;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Black;
            this.br = Color.White;
            textbox.BackColor = this.br;
            this.Text = null;
            this.Font = new Font("Century Gothic", 12f);
            base.Size = new Size(0x87, 0x21);
            this.DoubleBuffered = true;
            //textbox.KeyDown += new KeyEventHandler(textbox_KeyDown);
            //textbox.TextChanged += new EventHandler(textbox_TextChanged);
            textbox.MouseDoubleClick += new MouseEventHandler(textbox_MouseDoubleClick);
        }
        private void textbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                textbox.SelectAll();
            }
        }
    }
}
