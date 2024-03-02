namespace WhiskersAndWags
{
    partial class UpdateInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateInventory));
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label4 = new Label();
            InvId = new TextBox();
            InvPrice = new TextBox();
            InvStock = new TextBox();
            button1 = new Button();
            button2 = new Button();
            InvProd = new TextBox();
            label5 = new Label();
            button4 = new Button();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.Coral;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(788, 257);
            dataGridView1.TabIndex = 51;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PeachPuff;
            label2.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(74, 426);
            label2.Name = "label2";
            label2.Size = new Size(26, 18);
            label2.TabIndex = 52;
            label2.Text = "ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.PeachPuff;
            label4.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(74, 591);
            label4.Name = "label4";
            label4.Size = new Size(65, 18);
            label4.TabIndex = 54;
            label4.Text = "Stock/s:";
            // 
            // InvId
            // 
            InvId.BackColor = Color.PeachPuff;
            InvId.BorderStyle = BorderStyle.None;
            InvId.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InvId.Location = new Point(168, 426);
            InvId.Name = "InvId";
            InvId.Size = new Size(267, 19);
            InvId.TabIndex = 55;
            InvId.TextChanged += InvId_TextChanged;
            // 
            // InvPrice
            // 
            InvPrice.BackColor = Color.PeachPuff;
            InvPrice.BorderStyle = BorderStyle.None;
            InvPrice.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InvPrice.Location = new Point(168, 536);
            InvPrice.Name = "InvPrice";
            InvPrice.Size = new Size(267, 19);
            InvPrice.TabIndex = 56;
            InvPrice.TextChanged += InvPrice_TextChanged;
            // 
            // InvStock
            // 
            InvStock.BackColor = Color.PeachPuff;
            InvStock.BorderStyle = BorderStyle.None;
            InvStock.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InvStock.Location = new Point(168, 591);
            InvStock.Name = "InvStock";
            InvStock.Size = new Size(267, 19);
            InvStock.TabIndex = 57;
            // 
            // button1
            // 
            button1.BackColor = Color.PeachPuff;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(539, 447);
            button1.Name = "button1";
            button1.Size = new Size(94, 49);
            button1.TabIndex = 58;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.PeachPuff;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(539, 520);
            button2.Name = "button2";
            button2.Size = new Size(94, 59);
            button2.TabIndex = 59;
            button2.Text = "Reload";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // InvProd
            // 
            InvProd.BackColor = Color.PeachPuff;
            InvProd.BorderStyle = BorderStyle.None;
            InvProd.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InvProd.Location = new Point(168, 481);
            InvProd.Name = "InvProd";
            InvProd.Size = new Size(267, 19);
            InvProd.TabIndex = 61;
            InvProd.TextChanged += InvProd_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.PeachPuff;
            label5.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(74, 536);
            label5.Name = "label5";
            label5.Size = new Size(47, 18);
            label5.TabIndex = 60;
            label5.Text = "Price:";
            // 
            // button4
            // 
            button4.BackColor = Color.AntiqueWhite;
            button4.BackgroundImage = Properties.Resources.arrow_left;
            button4.BackgroundImageLayout = ImageLayout.Zoom;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(3, 3);
            button4.Name = "button4";
            button4.Size = new Size(50, 29);
            button4.TabIndex = 91;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PeachPuff;
            label3.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(74, 481);
            label3.Name = "label3";
            label3.Size = new Size(67, 18);
            label3.TabIndex = 92;
            label3.Text = "Product:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(152, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(490, 60);
            pictureBox2.TabIndex = 93;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.UI_bg;
            pictureBox1.Location = new Point(-128, -24);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1077, 698);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 94;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.PeachPuff;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(16, 99);
            textBox1.Margin = new Padding(2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search Medicine/Service";
            textBox1.Size = new Size(215, 27);
            textBox1.TabIndex = 95;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // UpdateInventory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(InvProd);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(InvStock);
            Controls.Add(InvPrice);
            Controls.Add(InvId);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Name = "UpdateInventory";
            Size = new Size(820, 651);
            Load += UpdateInventory_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Label label2;
        private Label label4;
        private TextBox InvId;
        private TextBox InvPrice;
        private TextBox InvStock;
        private Button button1;
        private Button button2;
        private TextBox InvProd;
        private Label label5;
        private Button button4;
        private Label label3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private TextBox textBox1;
    }
}
