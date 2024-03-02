namespace WhiskersAndWags
{
    partial class SalesReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesReport));
            label3 = new Label();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            button6 = new Button();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PeachPuff;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(505, 95);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 13;
            label3.Text = "To date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PeachPuff;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(57, 95);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 12;
            label2.Text = "From date:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarMonthBackground = Color.PeachPuff;
            dateTimePicker2.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker2.Location = new Point(505, 118);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 28);
            dateTimePicker2.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.PeachPuff;
            dateTimePicker1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Location = new Point(57, 118);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 28);
            dateTimePicker1.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.PeachPuff;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(23, 585);
            button1.Name = "button1";
            button1.Size = new Size(156, 39);
            button1.TabIndex = 9;
            button1.Text = "Search Date";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(23, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(775, 405);
            dataGridView1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.PeachPuff;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(587, 594);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 15;
            label4.Text = "Total Sales:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.PeachPuff;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(681, 594);
            label5.Name = "label5";
            label5.Size = new Size(17, 20);
            label5.TabIndex = 16;
            label5.Text = "?";
            // 
            // button6
            // 
            button6.BackColor = Color.AntiqueWhite;
            button6.BackgroundImage = Properties.Resources.arrow_left;
            button6.BackgroundImageLayout = ImageLayout.Zoom;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(23, 3);
            button6.Name = "button6";
            button6.Size = new Size(50, 29);
            button6.TabIndex = 93;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.UI_bg;
            pictureBox3.Location = new Point(-128, -24);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(1077, 698);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 97;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(145, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(490, 60);
            pictureBox1.TabIndex = 98;
            pictureBox1.TabStop = false;
            // 
            // SalesReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(button6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox3);
            Name = "SalesReport";
            Size = new Size(820, 651);
            Load += SalesReport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label5;
        private Button button6;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
    }
}
