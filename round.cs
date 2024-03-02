using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WhiskersAndWags
{
    public class RoundTextBox : TextBox
    {
        private const int WM_PAINT = 0xF;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                using (Graphics graphics = CreateGraphics())
                {
                    using (Pen pen = new Pen(BorderColor, BorderWidth))
                    {
                        Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                        int borderRadius = 10; // Adjust the roundness of the corners here

                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        graphics.DrawArc(pen, rect.Left, rect.Top, borderRadius, borderRadius, 180, 90);
                        graphics.DrawArc(pen, rect.Right - borderRadius, rect.Top, borderRadius, borderRadius, 270, 90);
                        graphics.DrawArc(pen, rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
                        graphics.DrawArc(pen, rect.Left, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);

                        graphics.DrawLine(pen, rect.Left + borderRadius / 2, rect.Top, rect.Right - borderRadius / 2, rect.Top);
                        graphics.DrawLine(pen, rect.Right, rect.Top + borderRadius / 2, rect.Right, rect.Bottom - borderRadius / 2);
                        graphics.DrawLine(pen, rect.Right - borderRadius / 2, rect.Bottom, rect.Left + borderRadius / 2, rect.Bottom);
                        graphics.DrawLine(pen, rect.Left, rect.Bottom - borderRadius / 2, rect.Left, rect.Top + borderRadius / 2);
                    }
                }
            }
        }

        // Properties for border color and width (you can modify these as needed)
        public Color BorderColor { get; set; } = Color.Black;
        public float BorderWidth { get; set; } = 2;
    }
}
