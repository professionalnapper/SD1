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
    public partial class ItemsServices : UserControl
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        public ItemsServices()
        {
            InitializeComponent();
            updatePurchase1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void ItemsServices_Load(object sender, EventArgs e)
        {
            //load data
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
            da = new OleDbDataAdapter("SELECT Inventory.ID, Inventory.MedicineName, Inventory.Price\r\nFROM Inventory;\r\n", myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Inventory");
            dataGridView1.DataSource = ds.Tables["Inventory"];
            myConn.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            updatePurchase1.Visible = true;

        }

        private void updatePurchase1_Load(object sender, EventArgs e)
        {

        }
    }
}

