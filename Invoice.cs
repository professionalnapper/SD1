using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhiskersAndWags
{
    public partial class Invoice : Form
    {
        public string Date, Time;
        PrintPreviewDialog prntprvw = new PrintPreviewDialog();
        PrintDocument pntdoc = new PrintDocument();

        public DataGridView DataGridView1
        {
            get { return dataGridView1; }
        }
        public Invoice()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("M/d/yyyy");
            Time = DateTime.Now.ToString("h:mm:ss :tt");
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]

        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            label1.Text = Date;
            label2.Text = Time;

            Random random = new Random();
            int randomNumber = random.Next(1, 10000); // Generate a random number between 1 and 100
            label3.Text = randomNumber.ToString();
            textBox2.Enabled = false;
        }
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = pnl;
            getprintarea(pnl);
            prntprvw.Document = pntdoc;
            pntdoc.PrintPage += new PrintPageEventHandler(pntdoc_printpage);
            pntdoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 885, 770);
            prntprvw.ClientSize = new Size(885, 770);
            prntprvw.StartPosition = FormStartPosition.CenterScreen;
            prntprvw.ShowDialog();

        }
        public void pntdoc_printpage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, 0, 0);
            //e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.X);
        }

        Bitmap memoryimg;
        public void getprintarea(Panel pnl)
        {

            memoryimg = new Bitmap(885, 770);
            using (Graphics graphics = Graphics.FromImage(memoryimg))
            {
                // Draw the panel and its controls on the memory bitmap
                pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));

                // Draw the labels and textboxes explicitly onto the memory bitmap
                label1.DrawToBitmap(memoryimg, label1.Bounds);
                label2.DrawToBitmap(memoryimg, label2.Bounds);
                label3.DrawToBitmap(memoryimg, label3.Bounds);
                label4.DrawToBitmap(memoryimg, label4.Bounds);
                label5.DrawToBitmap(memoryimg, label5.Bounds);
                label6.DrawToBitmap(memoryimg, label6.Bounds);
                label7.DrawToBitmap(memoryimg, label7.Bounds);
                textBox1.DrawToBitmap(memoryimg, textBox1.Bounds);
                textBox2.DrawToBitmap(memoryimg, textBox2.Bounds);
                dataGridView1.DrawToBitmap(memoryimg, dataGridView1.Bounds);
            }
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            Print(panel1);
        }
        public void SetLabelText(string text)
        {
            label7.Text = text;
        }
        private void roundButton1_Click(object sender, EventArgs e)
        {
            // pay
            string change;
            string cash, total;

            double cashValue, totalValue;
            double.TryParse(textBox1.Text, out cashValue);
            double.TryParse(label7.Text, out totalValue);

            cash = textBox1.Text;
            total = label7.Text;

            double result = cashValue - totalValue;
            change = result.ToString();

            textBox2.Text = change;
        }
        public string GetInvoiceNo()
        {
            return label3.Text;
        }
        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }
    }
}
