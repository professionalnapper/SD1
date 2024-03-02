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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection.Metadata;
using AForge.Video;
using AForge.Video.DirectShow;


namespace WhiskersAndWags
{
    public partial class Patients : UserControl
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        public Patients()
        {
            InitializeComponent();
            //updateRecord1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        // Event handler for the "Update Record" button click
        private void button3_Click(object sender, EventArgs e)
        {
            // Update record in the "PatientInfo" table
            string query = "UPDATE PatientInfo SET PetName = @Pn, Birthdate = @Bd, Gender = @gn, Breed = @br, IDnumber = @idn, Weight = @wt, Color = @cl, PetOwner = @Po, Address = @add, PhoneNumber = @Phn, TelephoneNumber = @Tln, Email = @em WHERE ID = @id";
            cmd = new OleDbCommand(query, myConn);
            cmd.Parameters.AddWithValue("@Pn", textBox1.Text);
            cmd.Parameters.AddWithValue("@Bd", textBox2.Text);
            cmd.Parameters.AddWithValue("@gn", textBox3.Text);
            cmd.Parameters.AddWithValue("@br", textBox4.Text);
            cmd.Parameters.AddWithValue("@idn", Convert.ToInt32(textBox5.Text));
            cmd.Parameters.AddWithValue("@wt", textBox6.Text);
            cmd.Parameters.AddWithValue("@cl", textBox7.Text);
            cmd.Parameters.AddWithValue("@Po", textBox8.Text);
            cmd.Parameters.AddWithValue("@add", textBox10.Text);
            //cmd.Parameters.AddWithValue("@Phn", Convert.ToInt32(textBox15.Text));
            cmd.Parameters.AddWithValue("@Phn", textBox15.Text);
            cmd.Parameters.AddWithValue("@Tln", Convert.ToInt32(textBox16.Text));
            cmd.Parameters.AddWithValue("@em", textBox17.Text);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value)); // Assuming the "ID" column is present in the DataGridView


            myConn.Open();
            int rowsUpdated = cmd.ExecuteNonQuery();
            myConn.Close();

            if (rowsUpdated > 0)
            {
                MessageBox.Show("Patient Record has been updated successfully.", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No record has been updated.", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Check if any required fields are empty
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                //string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text) ||
                string.IsNullOrWhiteSpace(textBox15.Text) ||
                string.IsNullOrWhiteSpace(textBox16.Text) ||
                string.IsNullOrWhiteSpace(textBox17.Text))
            {
                MessageBox.Show("Please fill in all the required details.", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate a random ID number for textbox5
            Random random = new Random();
            int randomID = random.Next(100000, 999999); // Generate a random 6-digit ID
            textBox5.Text = randomID.ToString();

            //add record
            string PetName = textBox1.Text;
            string Birthdate = textBox2.Text;
            string Gender = textBox3.Text;
            string Breed = textBox4.Text;
            int IDnumber = Convert.ToInt32(textBox5.Text);
            int Weight = Convert.ToInt32(textBox6.Text);
            string Color = textBox7.Text;
            string PetOwner = textBox8.Text;
            string Address = textBox10.Text;
            //long PhoneNumber = Convert.ToInt64(textBox15.Text);
            string PhoneNumber = textBox15.Text;
            int TelephoneNumber = Convert.ToInt32(textBox16.Text);
            string Email = textBox17.Text;

            // validate username and password
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student\Downloads\(1) WhiskersAndWags\WandW (1).accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            myConn = new OleDbConnection(connectionString);

            string newquery = "INSERT INTO PatientInfo ([PetName], [Birthdate], [Gender], [Breed], [IDnumber], [Weight], [Color], [PetOwner], [Address], [PhoneNumber], [TelephoneNumber], [Email]) values(@PetName, @Birthdate, @Gender, @Breed, @IDnumber, @Weight, @Color, @PetOwner, @Address, @PhoneNumber, @TelephoneNumber, @Email)";
            cmd = new OleDbCommand(newquery, connection);
            cmd.Parameters.AddWithValue("@PetName", PetName);
            cmd.Parameters.AddWithValue("@Birthdate", Birthdate);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Breed", Breed);
            cmd.Parameters.AddWithValue("@IDnumber", IDnumber);
            cmd.Parameters.AddWithValue("@Weight", Weight);
            cmd.Parameters.AddWithValue("@Color", Color);
            cmd.Parameters.AddWithValue("@PetOwner", PetOwner);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@TelephoneNumber", TelephoneNumber);
            cmd.Parameters.AddWithValue("@Email", Email);
            //myConn.Open();
            connection.Open();

            cmd.ExecuteNonQuery();

            //myConn.Close();

            // Create the new table for the user

            string createTableSQL = "CREATE TABLE " + PetName + " (ID COUNTER PRIMARY KEY, DateOfTransaction DATE, TimeOfTransaction TIME, DiagnosisOrPurchase VARCHAR(255), NameOfService VARCHAR(255), NameOfProduct VARCHAR(255))";
            OleDbCommand createTableCommand = new OleDbCommand(createTableSQL, connection);
            createTableCommand.ExecuteNonQuery();

            // Insert the user's data into the new table

            string insertDataSQL = "INSERT INTO " + PetName + " (DateOfTransaction, TimeOfTransaction, DiagnosisOrPurchase, NameOfService, NameOfProduct) " + "VALUES (@DateOfTransaction, @TimeOfTransaction, @DiagnosisOrPurchase, @NameOfService, @NameOfProduct)";
            OleDbCommand insertDataCommand = new OleDbCommand(insertDataSQL, connection);
            MessageBox.Show("Record successfully added!", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Reload data
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
            da = new OleDbDataAdapter("SELECT PatientInfo.ID, PatientInfo.PetName, PatientInfo.Birthdate, PatientInfo.Gender, PatientInfo.Breed, PatientInfo.IDnumber, PatientInfo.Weight, PatientInfo.Color, PatientInfo.PetOwner, PatientInfo.Address, PatientInfo.PhoneNumber, PatientInfo.TelephoneNumber, PatientInfo.Email\r\nFROM PatientInfo;\r\n", myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "PatientInfo");
            dataGridView1.DataSource = ds.Tables["PatientInfo"];
            myConn.Close();

            // Clear textboxes
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox15.Text = string.Empty;
            textBox16.Text = string.Empty;
            textBox17.Text = string.Empty;
        }

        /*private void button5_Click(object sender, EventArgs e)
        {
            //load data
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
            da = new OleDbDataAdapter("SELECT PatientInfo.ID, PatientInfo.PetName, PatientInfo.Birthdate, PatientInfo.Gender, PatientInfo.Breed, PatientInfo.IDnumber, PatientInfo.Weight, PatientInfo.Color, PatientInfo.PetOwner, PatientInfo.Address, PatientInfo.PhoneNumber, PatientInfo.TelephoneNumber, PatientInfo.Email\r\nFROM PatientInfo;\r\n", myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "PatientInfo");
            dataGridView1.DataSource = ds.Tables["PatientInfo"];
            myConn.Close();
        }*/

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Patients_Load(object sender, EventArgs e)
        {
            //load data
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb");
            da = new OleDbDataAdapter("SELECT PatientInfo.ID, PatientInfo.PetName, PatientInfo.Birthdate, PatientInfo.Gender, PatientInfo.Breed, PatientInfo.IDnumber, PatientInfo.Weight, PatientInfo.Color, PatientInfo.PetOwner, PatientInfo.Address, PatientInfo.PhoneNumber, PatientInfo.TelephoneNumber, PatientInfo.Email\r\nFROM PatientInfo;\r\n", myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "PatientInfo");
            dataGridView1.DataSource = ds.Tables["PatientInfo"];
            myConn.Close();
            textBox5.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            textBox2.Text = row.Cells[0].Value.ToString();
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                textBox10.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                textBox15.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                textBox16.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                textBox17.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

