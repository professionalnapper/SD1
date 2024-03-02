using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WhiskersAndWags
{
    public partial class UpdateInventory : UserControl
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow = 0;
        public UpdateInventory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // update
            if (indexRow < 0)
            {
                return;
            }

            try
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    // Update Credentials table
                    string inventoryQuery = "UPDATE Inventory SET MedicineName = @medName, Price = @Price, Stocks = @Stock WHERE ID = @id";
                    using (OleDbCommand cmd = new OleDbCommand(inventoryQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Product", InvProd.Text);
                        cmd.Parameters.AddWithValue("@Price", InvPrice.Text);
                        cmd.Parameters.AddWithValue("@Stock", InvStock.Text);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(InvId.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                // Update DataGridView
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                row.Cells[1].Value = InvProd.Text;
                row.Cells[2].Value = InvPrice.Text;
                row.Cells[3].Value = InvStock.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void UpdateInventory_Load(object sender, EventArgs e)
        {
            InvId.Enabled = false;
            InvProd.Enabled = false;
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT Inventory.ID, Inventory.MedicineName, Inventory.Price, Inventory.Stocks FROM Inventory;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Inventory");
            dataGridView1.DataSource = ds.Tables["Inventory"];
            myConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Reload the data in the DataGridView
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT Inventory.ID, Inventory.MedicineName, Inventory.Price, Inventory.Stocks FROM Inventory;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Inventory");
            dataGridView1.DataSource = ds.Tables["Inventory"];
            myConn.Close();

            // Clear the textboxes
            InvId.Text = string.Empty;
            InvProd.Text = string.Empty;
            InvPrice.Text = string.Empty;
            InvStock.Text = string.Empty;
        }


        /*private void button2_Click(object sender, EventArgs e)
        {
            //reload
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT Inventory.ID, Inventory.MedicineName, Inventory.Price, Inventory.Stocks FROM Inventory;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Inventory");
            dataGridView1.DataSource = ds.Tables["Inventory"];
            myConn.Close();
        }*/

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header click

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            InvId.Text = row.Cells["ID"].Value.ToString();
            InvProd.Text = row.Cells["MedicineName"].Value.ToString();
            InvPrice.Text = row.Cells["Price"].Value.ToString();
            InvStock.Text = row.Cells["Stocks"].Value.ToString();
            // set the DataGridView to read-only mode
            dataGridView1.ReadOnly = true;
            //dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InvProd_TextChanged(object sender, EventArgs e)
        {

        }

        private void InvId_TextChanged(object sender, EventArgs e)
        {
        }

        private void InvPrice_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //search
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");

            if (textBox1.Text != "")
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                OleDbDataAdapter adapt = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                DataView dv = new DataView();

                string command = "Select * From Inventory Where MedicineName like '%" + textBox1.Text + "%';";

                myConn.Open();
                adapt = new OleDbDataAdapter(command, myConn);
                adapt.Fill(ds);
                dv = new DataView(ds.Tables[0]);
                dataGridView1.DataSource = dv;
                myConn.Close();
            }
            else if (textBox1.Text == "")
            {
                dataGridView1.Refresh();
            }
        }
    }
}
