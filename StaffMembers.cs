using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WhiskersAndWags
{
    public partial class StaffMembers : UserControl
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        public StaffMembers()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Add record
            string StaffLastName = textBox1.Text;
            string StaffFirstName = textBox3.Text;
            string Position = textBox2.Text;
            string Status = textBox4.Text;

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student\Downloads\(1) WhiskersAndWags\WandW (1).accdb";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "INSERT INTO StaffMembers ([StaffLastName], [StaffFirstName], [Position], [Status]) VALUES (@StaffLastName, @StaffFirstName, @Position, @Status)";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StaffLastName", StaffLastName);
                        command.Parameters.AddWithValue("@StaffFirstName", StaffFirstName);
                        command.Parameters.AddWithValue("@Position", Position);
                        command.Parameters.AddWithValue("@Status", Status);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                MessageBox.Show("Record successfully added!", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data: " + ex.ToString());
            }
        }


        /*private void button1_Click(object sender, EventArgs e)
        {
            //add record
            string StaffLastName = textBox1.Text;
            string StaffFirstName = textBox3.Text;
            string Position = textBox2.Text;
            string Status = textBox4.Text;

            // validate username and password
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student\Downloads\(1) WhiskersAndWags\WandW (1).accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            myConn = new OleDbConnection(connectionString);

            string newquery = "INSERT INTO StaffMembers ([StaffLastName], [StaffFirstName], [Position], [Status]) values (@StaffLastName, @StaffFirstName, @Position, @Status)";
            cmd = new OleDbCommand(newquery, connection);
            cmd.Parameters.AddWithValue("@StaffLastName", StaffLastName);
            cmd.Parameters.AddWithValue("@StaffFirstName", StaffFirstName);
            cmd.Parameters.AddWithValue("@Position", Position);
            cmd.Parameters.AddWithValue("@Status", Status);
            myConn.Open();
            connection.Open();

            cmd.ExecuteNonQuery();

            //myConn.Close();
        }*/

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            textBox2.Text = row.Cells[0].Value.ToString();
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void StaffMembers_Load(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student\Downloads\(1) WhiskersAndWags\WandW (1).accdb";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT StaffMembers.ID, StaffMembers.StaffLastName, StaffMembers.StaffFirstName, StaffMembers.Position, StaffMembers.Status FROM StaffMembers";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        ds = new DataSet();
                        adapter.Fill(ds, "StaffMembers");
                        dataGridView1.DataSource = ds.Tables["StaffMembers"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.ToString());
            }
        }

        /*private void StaffMembers_Load(object sender, EventArgs e)
        {
            //load data
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
            da = new OleDbDataAdapter("SELECT StaffMembers.ID, StaffMembers.StaffLastName, StaffMembers.StaffFirstName, StaffMembers.Position, StaffMembers.Status\r\nFROM StaffMembers;\r\n", myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "StaffMembers");
            dataGridView1.DataSource = ds.Tables["StaffMembers"];
            myConn.Close();
        }*/


        private void button3_Click(object sender, EventArgs e)
        {
            //load data
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
            da = new OleDbDataAdapter("SELECT StaffMembers.ID, StaffMembers.StaffLastName, StaffMembers.StaffFirstName, StaffMembers.Position, StaffMembers.Status\r\nFROM StaffMembers;\r\n", myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "StaffMembers");
            dataGridView1.DataSource = ds.Tables["StaffMembers"];
            myConn.Close();
        }
    }
}
