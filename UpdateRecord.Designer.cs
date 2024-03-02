namespace WhiskersAndWags
{
    partial class UpdateRecord
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
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            updatePurchase1 = new UpdatePurchase();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.UI_bg;
            pictureBox1.Location = new Point(-128, -24);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1077, 698);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 47;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Coral;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 87);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(748, 285);
            dataGridView1.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PeachPuff;
            label1.Font = new Font("Roboto", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(274, 35);
            label1.Name = "label1";
            label1.Size = new Size(271, 34);
            label1.TabIndex = 49;
            label1.Text = "MEDICAL HISTORY";
            // 
            // button1
            // 
            button1.BackColor = Color.PeachPuff;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(78, 489);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(202, 35);
            button1.TabIndex = 50;
            button1.Text = "Add Diagnosis";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.PeachPuff;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(78, 400);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(202, 35);
            button2.TabIndex = 51;
            button2.Text = "Update Purchase";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.diagnosis;
            pictureBox2.Location = new Point(392, 400);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(396, 209);
            pictureBox2.TabIndex = 52;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.PeachPuff;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Roboto", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(78, 577);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Add diagnosis here";
            textBox1.Size = new Size(202, 22);
            textBox1.TabIndex = 53;
            // 
            // updatePurchase1
            // 
            updatePurchase1.Location = new Point(0, 0);
            updatePurchase1.Name = "updatePurchase1";
            updatePurchase1.Size = new Size(1025, 814);
            updatePurchase1.TabIndex = 54;
            // 
            // UpdateRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(updatePurchase1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Name = "UpdateRecord";
            Size = new Size(820, 651);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private UpdatePurchase updatePurchase1;
    }
}
