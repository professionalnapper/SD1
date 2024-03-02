namespace WhiskersAndWags
{
    partial class DailyLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyLog));
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.UI_bg;
            pictureBox1.Location = new Point(-119, 2);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1077, 698);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Coral;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 143);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(802, 271);
            dataGridView1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PeachPuff;
            label2.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(54, 448);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 8;
            label2.Text = "Log Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PeachPuff;
            label3.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(53, 497);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 9;
            label3.Text = "Log Time:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.PeachPuff;
            label4.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(53, 546);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 10;
            label4.Text = "Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.PeachPuff;
            label5.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(53, 595);
            label5.Name = "label5";
            label5.Size = new Size(114, 20);
            label5.TabIndex = 11;
            label5.Text = "Action Taken:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.PeachPuff;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(173, 448);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(357, 21);
            textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.PeachPuff;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(173, 496);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(357, 21);
            textBox2.TabIndex = 13;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.PeachPuff;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(173, 544);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(335, 21);
            textBox3.TabIndex = 14;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.PeachPuff;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Log-In", "Log-Out" });
            comboBox1.Location = new Point(173, 592);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 15;
            // 
            // button1
            // 
            button1.BackColor = Color.PeachPuff;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(600, 463);
            button1.Name = "button1";
            button1.Size = new Size(143, 54);
            button1.TabIndex = 16;
            button1.Text = "Update Action";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.PeachPuff;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(600, 546);
            button2.Name = "button2";
            button2.Size = new Size(143, 54);
            button2.TabIndex = 17;
            button2.Text = "Reload";
            button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(146, 43);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(490, 60);
            pictureBox2.TabIndex = 94;
            pictureBox2.TabStop = false;
            // 
            // DailyLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Name = "DailyLog";
            Size = new Size(820, 651);
            Load += DailyLog_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox2;
    }
}
