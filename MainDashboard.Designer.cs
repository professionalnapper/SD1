namespace WhiskersAndWags
{
    partial class MainDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            panel1 = new Panel();
            date = new Label();
            time = new Label();
            button5 = new Button();
            SidePanel = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button11 = new Button();
            button10 = new Button();
            panel3 = new Panel();
            button9 = new Button();
            button6 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            home1 = new Home();
            clinicDashboard1 = new ClinicDashboard();
            activityLog1 = new ActivityLog();
            itemsServices1 = new ItemsServices();
            patients1 = new Patients();
            logs1 = new Logs();
            transactions1 = new Transactions();
            itemsServices2 = new ItemsServices();
            itemsServices3 = new ItemsServices();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PeachPuff;
            panel1.Controls.Add(date);
            panel1.Controls.Add(time);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(SidePanel);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(button10);
            panel1.Location = new Point(0, 1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 703);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // date
            // 
            date.AutoSize = true;
            date.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            date.Location = new Point(19, 668);
            date.Margin = new Padding(2, 0, 2, 0);
            date.Name = "date";
            date.Size = new Size(43, 18);
            date.TabIndex = 12;
            date.Text = "Date:";
            // 
            // time
            // 
            time.AutoSize = true;
            time.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            time.Location = new Point(19, 641);
            time.Margin = new Padding(2, 0, 2, 0);
            time.Name = "time";
            time.Size = new Size(49, 18);
            time.TabIndex = 11;
            time.Text = "Time: ";
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(12, 299);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(133, 50);
            button5.TabIndex = 6;
            button5.Text = "     Home";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // SidePanel
            // 
            SidePanel.BackColor = Color.FromArgb(255, 128, 0);
            SidePanel.Location = new Point(1, 245);
            SidePanel.Margin = new Padding(2);
            SidePanel.Name = "SidePanel";
            SidePanel.Size = new Size(9, 50);
            SidePanel.TabIndex = 4;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(14, 550);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(173, 50);
            button4.TabIndex = 3;
            button4.Text = "Sign Out";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(15, 492);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(221, 50);
            button3.TabIndex = 2;
            button3.Text = "  Items & Services";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(14, 429);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(204, 50);
            button2.TabIndex = 1;
            button2.Text = "Transactions";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Image = Properties.Resources.dashboard;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(12, 366);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(188, 50);
            button1.TabIndex = 0;
            button1.Text = "Daily Log";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button11
            // 
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button11.Image = (Image)resources.GetObject("button11.Image");
            button11.ImageAlign = ContentAlignment.MiddleLeft;
            button11.Location = new Point(-10, 203);
            button11.Margin = new Padding(2);
            button11.Name = "button11";
            button11.Size = new Size(240, 88);
            button11.TabIndex = 8;
            button11.TextAlign = ContentAlignment.MiddleRight;
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button10.Image = (Image)resources.GetObject("button10.Image");
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Location = new Point(-10, 0);
            button10.Margin = new Padding(2);
            button10.Name = "button10";
            button10.Size = new Size(228, 228);
            button10.TabIndex = 7;
            button10.TextAlign = ContentAlignment.MiddleRight;
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Coral;
            panel3.Controls.Add(button9);
            panel3.Controls.Add(button6);
            panel3.Location = new Point(226, 1);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(828, 63);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // button9
            // 
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(735, 6);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(38, 55);
            button9.TabIndex = 9;
            button9.TextAlign = ContentAlignment.MiddleRight;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button6.ForeColor = Color.Snow;
            button6.Image = Properties.Resources.exit;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(778, 6);
            button6.Margin = new Padding(2);
            button6.Name = "button6";
            button6.Size = new Size(33, 50);
            button6.TabIndex = 7;
            button6.TextAlign = ContentAlignment.MiddleRight;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.UI_bg;
            pictureBox1.Location = new Point(0, -2);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1047, 703);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // home1
            // 
            home1.Location = new Point(226, 62);
            home1.Margin = new Padding(2);
            home1.Name = "home1";
            home1.Size = new Size(1230, 977);
            home1.TabIndex = 4;
            // 
            // clinicDashboard1
            // 
            clinicDashboard1.Location = new Point(226, 62);
            clinicDashboard1.Margin = new Padding(2);
            clinicDashboard1.Name = "clinicDashboard1";
            clinicDashboard1.Size = new Size(1230, 977);
            clinicDashboard1.TabIndex = 5;
            // 
            // activityLog1
            // 
            activityLog1.Location = new Point(226, 62);
            activityLog1.Margin = new Padding(2, 2, 2, 2);
            activityLog1.Name = "activityLog1";
            activityLog1.Size = new Size(1230, 977);
            activityLog1.TabIndex = 6;
            // 
            // itemsServices1
            // 
            itemsServices1.Location = new Point(226, 62);
            itemsServices1.Margin = new Padding(2);
            itemsServices1.Name = "itemsServices1";
            itemsServices1.Size = new Size(1230, 977);
            itemsServices1.TabIndex = 7;
            // 
            // patients1
            // 
            patients1.BackColor = Color.PeachPuff;
            patients1.Location = new Point(226, 61);
            patients1.Margin = new Padding(2);
            patients1.Name = "patients1";
            patients1.Size = new Size(1025, 814);
            patients1.TabIndex = 10;
            // 
            // logs1
            // 
            logs1.BackColor = Color.Silver;
            logs1.Location = new Point(226, 61);
            logs1.Name = "logs1";
            logs1.Size = new Size(809, 648);
            logs1.TabIndex = 13;
            // 
            // transactions1
            // 
            transactions1.Location = new Point(226, 61);
            transactions1.Name = "transactions1";
            transactions1.Size = new Size(1025, 814);
            transactions1.TabIndex = 14;
            // 
            // itemsServices2
            // 
            itemsServices2.Location = new Point(226, 61);
            itemsServices2.Margin = new Padding(2);
            itemsServices2.Name = "itemsServices2";
            itemsServices2.Size = new Size(1025, 814);
            itemsServices2.TabIndex = 15;
            // 
            // itemsServices3
            // 
            itemsServices3.Location = new Point(226, 61);
            itemsServices3.Margin = new Padding(2);
            itemsServices3.Name = "itemsServices3";
            itemsServices3.Size = new Size(1025, 814);
            itemsServices3.TabIndex = 16;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Coral;
            ClientSize = new Size(1047, 703);
            Controls.Add(itemsServices3);
            Controls.Add(itemsServices2);
            Controls.Add(transactions1);
            Controls.Add(logs1);
            Controls.Add(itemsServices1);
            Controls.Add(activityLog1);
            Controls.Add(clinicDashboard1);
            Controls.Add(home1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(patients1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "MainDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainDashboard";
            Load += MainDashboard_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button button1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Panel SidePanel;
        private Panel panel3;
        private Button button5;
        private Button button6;
        private Button button9;
        private Button button11;
        private Button button10;
        private Label date;
        private Label time;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private Home home1;
        private ClinicDashboard clinicDashboard1;
        private ActivityLog activityLog1;
        private ItemsServices itemsServices1;
        private Patients patients1;
        private Logs logs1;
        private Transactions transactions1;
        private ItemsServices itemsServices2;
        private ItemsServices itemsServices3;
    }
}