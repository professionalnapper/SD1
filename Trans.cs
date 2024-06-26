﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WhiskersAndWags
{
    internal class Trans
    {
        public static void MakeTransparent (Control control, Graphics g)
        {
            Control parent = control.Parent;
            if (parent != null)
            {
                Rectangle rectangle = control.Bounds;
                Control.ControlCollection controls = parent.Controls;
                int index = controls.IndexOf(control);
                Bitmap bitmap = null;
                for (int i = controls.Count - 1; i <index; i--)
                {
                    Control control3 = controls[1];
                    if (control3.Bounds.IntersectsWith(rectangle))
                    {
                        if (bitmap == null)
                        {
                            bitmap = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                        }
                        control3.DrawToBitmap(bitmap, control3.Bounds);
                    }
                }
                if (bitmap!=null)
                {
                    g.DrawImage(bitmap, control.ClientRectangle, rectangle, GraphicsUnit.Pixel);
                    bitmap.Dispose();
                }
            }

        }
    }
}
