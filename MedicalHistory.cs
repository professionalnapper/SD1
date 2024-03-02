using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WhiskersAndWags
{
    public partial class MedicalHistory : UserControl
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        public string Date;
        public string Time;
        public MedicalHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add record
            Date = DateTime.Now.ToString("M/d/yyyy");
            Time = DateTime.Now.ToString("hh:mm:ss tt");
            string dateOfTransaction = Date;
            string timeOfTransaction = Time;
            string DiagnosisOrPurchase = textBox6.Text;
            string NameOfService = textBox4.Text;
            string NameOfProduct = textBox5.Text;

            string tableName = textBox1.Text;
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            string newquery = $"INSERT INTO [{tableName}] (DateOfTransaction, TimeOfTransaction, DiagnosisOrPurchase, NameOfService, NameOfProduct) " +
            "VALUES (@DateOfTransaction, @TimeOfTransaction, @DiagnosisOrPurchase, @NameOfService, @NameOfProduct)";
            cmd = new OleDbCommand(newquery, connection);
            cmd.Parameters.AddWithValue("@DateOfTransaction", dateOfTransaction);
            cmd.Parameters.AddWithValue("@TimeOfTransaction", timeOfTransaction);
            cmd.Parameters.AddWithValue("@DiagnosisOrPurchase", DiagnosisOrPurchase);
            cmd.Parameters.AddWithValue("@NameOfService", NameOfService);
            cmd.Parameters.AddWithValue("@NameOfProduct", NameOfProduct);

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

            textBox7.Text = dateOfTransaction;
            textBox3.Text = timeOfTransaction;
            dataGridView1.Columns["TimeOfTransaction"].DefaultCellStyle.Format = "HH:mm:ss";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear textboxes
            textBox2.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;

            // Reload data in the DataGridView
            string tableName = textBox1.Text;

            if (!string.IsNullOrEmpty(tableName))
            {
                myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
                da = new OleDbDataAdapter($"SELECT * FROM [{tableName}]", myConn);
                ds = new DataSet();
                myConn.Open();
                da.Fill(ds, tableName);
                dataGridView1.DataSource = ds.Tables[tableName];
                // dataGridView1.Columns["Rating"].Visible = false;
                myConn.Close();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            string tableName = textBox1.Text;

            if (!string.IsNullOrEmpty(tableName))
            {
                try
                {
                    myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
                    da = new OleDbDataAdapter($"SELECT * FROM [{tableName}]", myConn);
                    ds = new DataSet();
                    myConn.Open();
                    da.Fill(ds, tableName);
                    dataGridView1.DataSource = ds.Tables[tableName];
                    //dataGridView1.Columns["Rating"].Visible = false;
                    myConn.Close();
                }
                catch (OleDbException ex)
                {
                    // This block will execute if there is an OleDbException (e.g., table not found)
                    MessageBox.Show("The specified pet name does not exist in the database.", "Pet Name Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // You can add more specific handling for the exception if needed.
                    dataGridView1.DataSource = new DataTable(); // Set empty DataTable as DataSource
                }
                catch (Exception ex)
                {
                    // This block will catch any other unexpected exceptions that may occur
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // You can log the error or handle it differently based on your requirements.
                    dataGridView1.DataSource = new DataTable(); // Set empty DataTable as DataSource
                }
            }
            else
            {
                MessageBox.Show("Please enter pet's name.", "Pet Name Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView1.DataSource = new DataTable(); // Set empty DataTable as DataSource
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox7.Text = ParseDateFromDateTime(row.Cells[1].Value);
                textBox3.Text = ParseTimeFromDateTime(row.Cells[2].Value);
                textBox6.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
            }
        }

        private string ParseDateFromDateTime(object dateTimeValue)
        {
            if (dateTimeValue != null && dateTimeValue != DBNull.Value && DateTime.TryParse(dateTimeValue.ToString(), out DateTime parsedDateTime))
            {
                return parsedDateTime.ToString("M/d/yyyy");
            }
            return string.Empty; // Return an empty string if parsing fails or the value is null/DBNULL.
        }

        private string ParseTimeFromDateTime(object dateTimeValue)
        {
            if (dateTimeValue != null && dateTimeValue != DBNull.Value && DateTime.TryParse(dateTimeValue.ToString(), out DateTime parsedDateTime))
            {
                return parsedDateTime.ToString("hh:mm tt");
            }
            return string.Empty; // Return an empty string if parsing fails or the value is null/DBNULL.
        }

        private void MedicalHistory_Load_1(object sender, EventArgs e)
        {
            //reload
            string tableName = textBox1.Text;
            textBox2.Enabled = false;
            textBox7.Enabled = false;
            textBox3.Enabled = false;

            if (!string.IsNullOrEmpty(tableName))

            {
                myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
                da = new OleDbDataAdapter($"SELECT * FROM [{tableName}]", myConn);
                ds = new DataSet();
                myConn.Open();
                da.Fill(ds, tableName);
                dataGridView1.DataSource = ds.Tables[tableName];
                // dataGridView1.Columns["Rating"].Visible = false;
                
                myConn.Close();
            }
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "TimeOfTransaction")
            {
                if (e.Value != null && e.Value != DBNull.Value && DateTime.TryParse(e.Value.ToString(), out DateTime parsedDateTime))
                {
                    e.Value = parsedDateTime.ToString("hh:mm tt");
                    e.FormattingApplied = true;
                }
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

