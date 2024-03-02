using Microsoft.VisualBasic.Logging;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WhiskersAndWags
{
    public partial class Staff : UserControl
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        private int selectedStaffID;


        public Staff()
        {
            InitializeComponent();
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            //reload
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT StaffInfo.ID, StaffInfo.FirstName, StaffInfo.LastName, StaffInfo.StaffPosition, StaffInfo.StaffStatus FROM StaffInfo;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "StaffInfo");
            dataGridView1.DataSource = ds.Tables["StaffInfo"];
            myConn.Close();

            if (textBox4.Text == "Active")
            {
                pictureBox2.Visible = true;
                pictureBox2.BringToFront();
            }
            else if (textBox4.Text == "Inactive")
            {
                pictureBox4.Visible = true;
                pictureBox4.BringToFront();
            }

            // Hide both PictureBoxes initially
            pictureBox2.Visible = false;
            pictureBox4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear the TextBoxes
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            // Hide both PictureBoxes
            pictureBox2.Visible = false;
            pictureBox4.Visible = false;

            // Reload the DataGridView
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT StaffInfo.ID, StaffInfo.FirstName, StaffInfo.LastName, StaffInfo.StaffPosition, StaffInfo.StaffStatus FROM StaffInfo;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "StaffInfo");
            dataGridView1.DataSource = ds.Tables["StaffInfo"];
            myConn.Close();
        }

        /*private void button3_Click(object sender, EventArgs e)
        {
            //reload
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT StaffInfo.ID, StaffInfo.FirstName, StaffInfo.LastName, StaffInfo.StaffPosition, StaffInfo.StaffStatus FROM StaffInfo;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "StaffInfo");
            dataGridView1.DataSource = ds.Tables["StaffInfo"];
            myConn.Close();

            if (textBox4.Text == "Active")
            {
                pictureBox2.Visible = true;
                pictureBox2.BringToFront();
            }
            else if (textBox4.Text == "Inactive")
            {
                pictureBox4.Visible = true;
                pictureBox4.BringToFront();
            }
        }*/

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add record
            string FirstName = textBox3.Text;
            string LastName = textBox1.Text;
            string StaffPosition = textBox2.Text;
            string StaffStatus = textBox4.Text;

            // validate username and password
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student\Downloads\(1) WhiskersAndWags\WandW (1).accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            string newquery = "INSERT INTO StaffInfo ([FirstName], [LastName], [StaffPosition], [StaffStatus]) VALUES (@FirstName, @LastName, @StaffPosition, @StaffStatus)";
            OleDbCommand cmd = new OleDbCommand(newquery, connection);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@StaffPosition", StaffPosition);
            cmd.Parameters.AddWithValue("@StaffStatus", StaffStatus);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the staff record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                int selectedStaffID = Convert.ToInt32(selectedRow.Cells[0].Value);

                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student\Downloads\(1) WhiskersAndWags\WandW (1).accdb";
                using (OleDbConnection myConn = new OleDbConnection(connectionString))
                {
                    string query = "UPDATE StaffInfo SET FirstName=?, LastName=?, StaffPosition=?, StaffStatus=? WHERE ID=?";
                    OleDbCommand cmd = new OleDbCommand(query, myConn);
                    cmd.Parameters.AddWithValue("@p1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@p2", textBox1.Text);
                    cmd.Parameters.AddWithValue("@p3", textBox2.Text);
                    cmd.Parameters.AddWithValue("@p4", textBox4.Text);
                    cmd.Parameters.AddWithValue("@p5", selectedStaffID);

                    try
                    {
                        myConn.Open();
                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Staff Record has been updated successfully.", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record has been updated.", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while updating the staff record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a staff record from the grid to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        /*private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();

                // Store the selected staff ID in the private variable
                selectedStaffID = Convert.ToInt32(row.Cells[0].Value);

                // Check if the click occurred on a valid cell (not on the header or empty area)
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Get the value of the clicked cell in the "StaffStatus" column
                    object cellValue = dataGridView1.Rows[e.RowIndex].Cells["StaffStatus"].Value;

                    // Check if the cell value is not null and equals "Active" (case-insensitive)
                    if (cellValue != null && cellValue.ToString().Equals("Active", StringComparison.OrdinalIgnoreCase))
                    {
                        // Display pictureBox2 on the form
                        pictureBox2.Visible = true;
                        pictureBox2.BringToFront(); 
                    }

                    else if (((cellValue != null && cellValue.ToString().Equals("Inactive", StringComparison.OrdinalIgnoreCase))))
                    {
                        // Hide pictureBox2 on the form
                        pictureBox4.Visible = true;
                        pictureBox4.BringToFront();
                    }
                }
            }
        }*/



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();

                // Store the selected staff ID in the private variable
                selectedStaffID = Convert.ToInt32(row.Cells[0].Value);

                // Check the value in TextBox4 and display the corresponding PictureBox
                if (textBox4.Text.Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    // Display pictureBox2 on the form and hide pictureBox4
                    pictureBox2.Visible = true;
                    pictureBox2.BringToFront();
                    pictureBox4.Visible = false;
                }
                else if (textBox4.Text.Equals("Inactive", StringComparison.OrdinalIgnoreCase))
                {
                    // Display pictureBox4 on the form and hide pictureBox2
                    pictureBox4.Visible = true;
                    pictureBox4.BringToFront();
                    pictureBox2.Visible = false;
                }
                else
                {
                    // Hide both PictureBoxes if the value is neither "Active" nor "Inactive"
                    pictureBox2.Visible = false;
                    pictureBox4.Visible = false;
                }
            }
        }




    }

}

