namespace WhiskersAndWags
{
    partial class Invoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoice));
            button2 = new Button();
            button3 = new Button();
            panel5 = new Panel();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            ProductOrService = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            roundButton1 = new RoundButton();
            roundButton2 = new RoundButton();
            toolTip1 = new ToolTip(components);
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Coral;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(804, -4);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(38, 38);
            button2.TabIndex = 9;
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Coral;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.Snow;
            button3.Image = Properties.Resources.exit;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(842, -3);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(34, 36);
            button3.TabIndex = 7;
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Coral;
            panel5.Location = new Point(-142, -17);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(1167, 52);
            panel5.TabIndex = 23;
            panel5.MouseDown += panel5_MouseDown;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(2, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(885, 780);
            panel1.TabIndex = 24;
            panel1.Paint += panel1_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProductOrService, Price, Quantity, Total });
            dataGridView1.Location = new Point(53, 396);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(787, 242);
            dataGridView1.TabIndex = 4;
            // 
            // ProductOrService
            // 
            ProductOrService.HeaderText = "ProductOrService";
            ProductOrService.MinimumWidth = 6;
            ProductOrService.Name = "ProductOrService";
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            // 
            // Total
            // 
            Total.HeaderText = "Total";
            Total.MinimumWidth = 6;
            Total.Name = "Total";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.PeachPuff;
            textBox2.Location = new Point(734, 720);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(87, 27);
            textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.PeachPuff;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(715, 687);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(106, 20);
            textBox1.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(771, 658);
            label7.Name = "label7";
            label7.Size = new Size(16, 20);
            label7.TabIndex = 8;
            label7.Text = "?";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.SaddleBrown;
            label6.Location = new Point(663, 725);
            label6.Name = "label6";
            label6.Size = new Size(66, 18);
            label6.TabIndex = 7;
            label6.Text = "Change";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonHighlight;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.SaddleBrown;
            label5.Location = new Point(663, 689);
            label5.Name = "label5";
            label5.Size = new Size(51, 18);
            label5.TabIndex = 6;
            label5.Text = "Cash:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.SaddleBrown;
            label4.Location = new Point(663, 660);
            label4.Name = "label4";
            label4.Size = new Size(108, 18);
            label4.TabIndex = 5;
            label4.Text = "Amount Due:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.SaddleBrown;
            label3.Location = new Point(82, 342);
            label3.Name = "label3";
            label3.Size = new Size(49, 18);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.SaddleBrown;
            label2.Location = new Point(82, 267);
            label2.Name = "label2";
            label2.Size = new Size(49, 18);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.SaddleBrown;
            label1.Location = new Point(82, 195);
            label1.Name = "label1";
            label1.Size = new Size(49, 18);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.invoicelayout;
            pictureBox1.Location = new Point(-401, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1635, 1182);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // roundButton1
            // 
            roundButton1.BackColor = Color.BurlyWood;
            roundButton1.FlatAppearance.BorderSize = 0;
            roundButton1.FlatStyle = FlatStyle.Flat;
            roundButton1.ForeColor = Color.White;
            roundButton1.Location = new Point(589, 834);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(117, 31);
            roundButton1.TabIndex = 11;
            roundButton1.Text = "Pay";
            roundButton1.UseVisualStyleBackColor = false;
            roundButton1.Click += roundButton1_Click;
            // 
            // roundButton2
            // 
            roundButton2.BackColor = Color.BurlyWood;
            roundButton2.FlatAppearance.BorderSize = 0;
            roundButton2.FlatStyle = FlatStyle.Flat;
            roundButton2.ForeColor = Color.White;
            roundButton2.Location = new Point(736, 834);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(117, 31);
            roundButton2.TabIndex = 25;
            roundButton2.Text = "Print Receipt";
            roundButton2.UseVisualStyleBackColor = false;
            roundButton2.Click += roundButton2_Click;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // Invoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(883, 868);
            Controls.Add(roundButton2);
            Controls.Add(roundButton1);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(panel5);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Invoice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Invoice";
            Load += Invoice_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private Button button3;
        private Panel panel5;
        private Panel panel1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label2;
        private Label label1;
        private RoundButton roundButton1;
        private RoundButton roundButton2;
        private DataGridViewTextBoxColumn ProductOrService;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Total;
        private ToolTip toolTip1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private PictureBox pictureBox1;
    }
}