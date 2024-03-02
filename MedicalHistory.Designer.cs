namespace WhiskersAndWags
{
    partial class MedicalHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicalHistory));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            button5 = new Button();
            dataGridView1 = new DataGridView();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label1 = new Label();
            textBox4 = new TextBox();
            label2 = new Label();
            textBox5 = new TextBox();
            label4 = new Label();
            textBox6 = new TextBox();
            label5 = new Label();
            textBox7 = new TextBox();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.UI_bg;
            pictureBox1.Location = new Point(-14, -17);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1077, 698);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.MEDICAL_HISTORY_TITLE;
            pictureBox2.Location = new Point(163, 20);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(490, 60);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.PeachPuff;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(50, 89);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(215, 27);
            textBox1.TabIndex = 30;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button5
            // 
            button5.BackColor = Color.PeachPuff;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(271, 89);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(34, 27);
            button5.TabIndex = 31;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Coral;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(50, 130);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(715, 174);
            dataGridView1.TabIndex = 32;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.PeachPuff;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(341, 331);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(424, 25);
            textBox2.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PeachPuff;
            label3.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(53, 331);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(35, 24);
            label3.TabIndex = 33;
            label3.Text = "ID:";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.PeachPuff;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(341, 413);
            textBox3.Margin = new Padding(2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(424, 25);
            textBox3.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PeachPuff;
            label1.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(53, 373);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(191, 24);
            label1.TabIndex = 35;
            label1.Text = "Date of Transaction:";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.PeachPuff;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(341, 495);
            textBox4.Margin = new Padding(2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(424, 25);
            textBox4.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PeachPuff;
            label2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(53, 415);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 24);
            label2.TabIndex = 37;
            label2.Text = "Time:";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.PeachPuff;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(341, 536);
            textBox5.Margin = new Padding(2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(424, 25);
            textBox5.TabIndex = 44;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.PeachPuff;
            label4.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(50, 541);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(165, 24);
            label4.TabIndex = 43;
            label4.Text = "Name of Product:";
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.PeachPuff;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox6.Location = new Point(341, 454);
            textBox6.Margin = new Padding(2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(424, 25);
            textBox6.TabIndex = 42;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.PeachPuff;
            label5.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(50, 499);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(255, 24);
            label5.TabIndex = 41;
            label5.Text = "Name of Diagnosis/Service:";
            // 
            // textBox7
            // 
            textBox7.BackColor = Color.PeachPuff;
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox7.Location = new Point(341, 372);
            textBox7.Margin = new Padding(2);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(424, 25);
            textBox7.TabIndex = 40;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.PeachPuff;
            label6.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(50, 457);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(175, 24);
            label6.TabIndex = 39;
            label6.Text = "Diagnosis/Service:";
            // 
            // button1
            // 
            button1.BackColor = Color.Coral;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(198, 577);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(172, 37);
            button1.TabIndex = 45;
            button1.Text = "Update Record";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Coral;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(396, 577);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(172, 37);
            button2.TabIndex = 46;
            button2.Text = "Reload";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.AntiqueWhite;
            button6.BackgroundImage = Properties.Resources.arrow_left;
            button6.BackgroundImageLayout = ImageLayout.Zoom;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(0, 3);
            button6.Name = "button6";
            button6.Size = new Size(50, 29);
            button6.TabIndex = 92;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // MedicalHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(label4);
            Controls.Add(textBox6);
            Controls.Add(label5);
            Controls.Add(textBox7);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(button5);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Margin = new Padding(2);
            Name = "MedicalHistory";
            Size = new Size(820, 651);
            Load += MedicalHistory_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private Button button5;
        private DataGridView dataGridView1;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label1;
        private TextBox textBox4;
        private Label label2;
        private TextBox textBox5;
        private Label label4;
        private TextBox textBox6;
        private Label label5;
        private TextBox textBox7;
        private Label label6;
        private Button button1;
        private Button button2;
        private Button button6;
    }
}
