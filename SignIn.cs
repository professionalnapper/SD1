using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Data.OleDb;

namespace WhiskersAndWags
{
    public partial class SignIn : Form
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;

        public SignIn()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]

        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            //sign up
            string username = textBox1.Text;
            string password = textBox2.Text;
            string name = textBox4.Text;
            string email = textBox3.Text;
            string position = textBox5.Text;

            // validate username and password
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student\Downloads\(1) WhiskersAndWags\WandW (1).accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            MessageBox.Show("Congratulations! Your account has been successfully created. Please proceed to the Log-in Form.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form1 log = new Form1();
            log.Show();

            try
            {
                connection.Open();

                // Check if the username already exists
                string query = "SELECT COUNT(*) FROM Admin WHERE Username = @Username";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Username Already Exists! Please try with another one.", "Sign-Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string newquery = "INSERT INTO Admin ([Username], [Password], [NameUser], [Email], [Position]) VALUES (@Username, @Password, @NameUser, @Email, @Position)";
                cmd = new OleDbCommand(newquery, connection);
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                cmd.Parameters.AddWithValue("@NameUser", textBox4.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@Position", textBox5.Text);

                cmd.ExecuteNonQuery();

                /* // Create the new table for the user

                 string createTableSQL = "CREATE TABLE " + username + " (UserID AUTOINCREMENT PRIMARY KEY, Username VARCHAR(255), NameUser VARCHAR(255), Password VARCHAR(255), Email VARCHAR(255), Position VARCHAR(255))";
                 OleDbCommand createTableCommand = new OleDbCommand(createTableSQL, connection);
                 createTableCommand.ExecuteNonQuery();

                 // Insert the user's data into the new table

                 string insertDataSQL = "INSERT INTO " + username + " (Username, Password, NameUser, Email, Position) " + "VALUES (@Username, @Password, @NameUser, @Email, @Position)";
                 OleDbCommand insertDataCommand = new OleDbCommand(insertDataSQL, connection);
                 MessageBox.Show("Congratulations! Your account has been successfully created. Please proceed to the Log-in Form.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 this.Hide();
                 Form1 log = new Form1();
                 log.Show();*/
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, display an error message, etc.
                MessageBox.Show("Error creating account: " + ex.Message, "Sign-Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}