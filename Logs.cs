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
    public partial class Logs : UserControl
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        public string Date;
        public string Time;
        public Logs()
        {
            InitializeComponent();
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            //reload
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT DailyLog.ID, DailyLog.LogDate, DailyLog.LogTime, DailyLog.StaffName, DailyLog.ActionTaken FROM DailyLog;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "DailyLog");
            dataGridView1.DataSource = ds.Tables["DailyLog"];
            myConn.Close();
            dataGridView1.Columns["LogTime"].DefaultCellStyle.Format = "hh:mm:ss tt";
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear TextBoxes and ComboBox
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.Text = string.Empty;

            // Reload the data in the DataGridView
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT DailyLog.ID, DailyLog.LogDate, DailyLog.LogTime, DailyLog.StaffName, DailyLog.ActionTaken FROM DailyLog;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "DailyLog");
            dataGridView1.DataSource = ds.Tables["DailyLog"];
            myConn.Close();

            // Format the time column to display only the time without the date
            dataGridView1.Columns["LogTime"].DefaultCellStyle.Format = "hh:mm tt";
        }


        /*private void button2_Click(object sender, EventArgs e)
        {
            // Clear TextBoxes and ComboBox
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.Text = string.Empty;

            // Reload the data in the DataGridView
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT DailyLog.ID, DailyLog.LogDate, DailyLog.LogTime, DailyLog.StaffName, DailyLog.ActionTaken FROM DailyLog;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "DailyLog");
            dataGridView1.DataSource = ds.Tables["DailyLog"];
            myConn.Close();

            // Format the time column to display only the time without the date
            dataGridView1.Columns["LogTime"].DefaultCellStyle.Format = "HH:mm:ss";
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            // Generate Date and Time automatically
            string LogDate = DateTime.Now.ToString("M/d/yyyy");
            string LogTime = DateTime.Now.ToString("hh:mm:ss tt");

            string StaffName = textBox3.Text;
            string ActionTaken = comboBox1.Text;

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            string newquery = $"INSERT INTO [DailyLog] (LogDate, LogTime, StaffName, ActionTaken) " +
                              "VALUES (@LogDate, @LogTime, @StaffName, @ActionTaken)";
            cmd = new OleDbCommand(newquery, connection);
            cmd.Parameters.AddWithValue("@LogDate", LogDate);
            cmd.Parameters.AddWithValue("@LogTime", LogTime);
            cmd.Parameters.AddWithValue("@StaffName", StaffName);
            cmd.Parameters.AddWithValue("@ActionTaken", ActionTaken);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully added!", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Reload the data from the database into the DataGridView
            button2_Click(sender, e);

            // Update the textboxes with the generated date and time components
            textBox1.Text = LogDate;
            textBox2.Text = LogTime;

            // Format the time column to display only the time without the date
            dataGridView1.Columns["LogTime"].DefaultCellStyle.Format = "hh:mm tt";
        }


        /*private void button1_Click(object sender, EventArgs e)
        {
            // Generate Date and Time automatically
            string LogDate = DateTime.Now.ToString("M/d/yyyy");
            string LogTime = DateTime.Now.ToString("hh:mm:ss tt");

            string StaffName = textBox3.Text;
            string ActionTaken = comboBox1.Text;

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            string newquery = $"INSERT INTO [DailyLog] (LogDate, LogTime, StaffName, ActionTaken) " +
                              "VALUES (@LogDate, @LogTime, @StaffName, @ActionTaken)";
            cmd = new OleDbCommand(newquery, connection);
            cmd.Parameters.AddWithValue("@LogDate", LogDate);
            cmd.Parameters.AddWithValue("@LogTime", LogTime);
            cmd.Parameters.AddWithValue("@StaffName", StaffName);
            cmd.Parameters.AddWithValue("@ActionTaken", ActionTaken);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully added!", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Reload the data from the database into the DataGridView
            button2_Click(sender, e);

            // Update the textboxes with the generated date and time components
            textBox1.Text = LogDate;
            textBox2.Text = LogTime;

            dataGridView1.Columns["LogTime"].DefaultCellStyle.Format = "HH:mm:ss";
        }*/


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                textBox1.Text = Convert.ToDateTime(row.Cells["LogDate"].Value).ToString("M/d/yyyy");
                textBox2.Text = Convert.ToDateTime(row.Cells["LogTime"].Value).ToString("hh:mm:ss tt");

                textBox3.Text = row.Cells["StaffName"].Value.ToString();
                comboBox1.Text = row.Cells["ActionTaken"].Value.ToString();
            }
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT DailyLog.ID, DailyLog.LogDate, DailyLog.LogTime, DailyLog.StaffName, DailyLog.ActionTaken FROM DailyLog;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "DailyLog");
            dataGridView1.DataSource = ds.Tables["DailyLog"];
            myConn.Close();

            // Format the time column to display only the time without the date
            dataGridView1.Columns["LogTime"].DefaultCellStyle.Format = "hh:mm tt";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        /*private void Logs_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT DailyLog.ID, DailyLog.LogDate, DailyLog.LogTime, DailyLog.StaffName, DailyLog.ActionTaken FROM DailyLog;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "DailyLog");
            dataGridView1.DataSource = ds.Tables["DailyLog"];
            myConn.Close();
        }*/
    }
}
