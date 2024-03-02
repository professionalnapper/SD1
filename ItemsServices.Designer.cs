namespace WhiskersAndWags
{
    partial class ItemsServices
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
            button1 = new Button();
            textBox1 = new TextBox();
            pictureBox2 = new PictureBox();
            updatePurchase1 = new UpdatePurchase();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.UI_bg;
            pictureBox1.Location = new Point(2, 0);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1077, 698);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.PeachPuff;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 132);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(756, 412);
            dataGridView1.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.PeachPuff;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(326, 570);
            button1.Name = "button1";
            button1.Size = new Size(171, 51);
            button1.TabIndex = 6;
            button1.Text = "Proceed to Purchase";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.PeachPuff;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(32, 96);
            textBox1.Margin = new Padding(2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search Medicine/Service";
            textBox1.Size = new Size(215, 27);
            textBox1.TabIndex = 32;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._4;
            pictureBox2.Location = new Point(167, 21);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(490, 60);
            pictureBox2.TabIndex = 92;
            pictureBox2.TabStop = false;
            // 
            // updatePurchase1
            // 
            updatePurchase1.Location = new Point(3, 0);
            updatePurchase1.Name = "updatePurchase1";
            updatePurchase1.Size = new Size(1025, 814);
            updatePurchase1.TabIndex = 93;
            // 
            // ItemsServices
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(updatePurchase1);
            Controls.Add(pictureBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Margin = new Padding(2);
            Name = "ItemsServices";
            Size = new Size(820, 651);
            Load += ItemsServices_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Button button1;
        private TextBox textBox1;
        private PictureBox pictureBox2;
        private UpdatePurchase updatePurchase1;
    }
}
