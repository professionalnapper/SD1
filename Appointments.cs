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
    public partial class Appointments : UserControl
    {
        private OleDbConnection myConn;
        private OleDbDataAdapter da;
        private DataSet ds;
        public Appointments()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Set up the database connection
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                myConn = new OleDbConnection(connectionString);

                // Create an OleDbDataAdapter to fetch the data from the linked table
                string query = "SELECT * FROM AppointmentSched;";
                da = new OleDbDataAdapter(query, myConn);

                // Create a DataSet and fill it with the data from the linked table
                ds = new DataSet();
                myConn.Open();
                da.Fill(ds, "AppointmentSched");

                // Set DataGridView's DataSource to the DataTable containing the linked table's data
                dataGridView1.DataSource = ds.Tables["AppointmentSched"];

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }




        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Appointments_Load_1(object sender, EventArgs e)
        {
            // Set up the database connection
            /*string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);

            // Create an OleDbDataAdapter to fetch the data from the "AppointmentSched" table
            string query = "SELECT AppointmentSched.ID, AppointmentSched.Timestamp, AppointmentSched.PetOwnersName, AppointmentSched.ContactNumber, AppointmentSched.OwnerAddress, AppointmentSched.PetName, AppointmentSched.PetBreed, AppointmentSched.DateOfBirth, AppointmentSched.AppointmentDate, AppointmentSched.ServicesToAvail, AppointmentSched.PetType, AppointmentSched.OwnerEmail FROM AppointmentSched;";
            da = new OleDbDataAdapter(query, myConn);

            // Create a DataSet and fill it with the data from the "AppointmentSched" table
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "AppointmentSched");

            // Set DataGridView's DataSource to the DataTable containing the "AppointmentSched" table's data
            dataGridView1.DataSource = ds.Tables["AppointmentSched"];

            myConn.Close();*/
        }
    }
}
