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

namespace WhiskersAndWags
{
    public partial class Transactions : UserControl
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        private string connectionString1 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student\Downloads\(1) WhiskersAndWags\WandW (1).accdb";
        public Transactions()
        {
            InitializeComponent();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
            da = new OleDbDataAdapter("SELECT Transactions.ID, Transactions.InvoiceNo, Transactions.DateOfTransaction, Transactions.TimeOfTransaction, Transactions.ProductOrService, Transactions.Quantity, Transactions.Price, Transactions.Total\r\nFROM Transactions;\r\n", myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Transactions");
            dataGridView1.DataSource = ds.Tables["Transactions"];
            myConn.Close();
            dataGridView1.Columns["TimeOfTransaction"].DefaultCellStyle.Format = "h:mm:ss tt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dateTimePicker1.Value.Date;
                DateTime endDate = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

                string query = "SELECT InvoiceNo, DateofTransaction, TimeOfTransaction, ProductOrService, Quantity, Price, Total " +
                        "FROM Transactions " +
                        "WHERE DateofTransaction >= @StartDate AND DateofTransaction <= @EndDate";

                using (OleDbConnection connection = new OleDbConnection(connectionString1))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the filtered data to dataGridView1
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
