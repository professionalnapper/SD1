using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Diagnostics;
using static System.Windows.Forms.DataFormats;

namespace WhiskersAndWags
{
    public partial class UpdatePurchase : UserControl
    {
        public string Date;

        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;

        public UpdatePurchase()
        {
            InitializeComponent();
        }
        string name;
        double price;
        double tot;
        Bitmap bitmap;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //remove item

            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {
                double removedTotal = Convert.ToDouble(selectedRow.Cells[3].Value);
                dataGridView1.Rows.Remove(selectedRow);

                int removedQty = Convert.ToInt32(selectedRow.Cells[2].Value);
                string medicineName = selectedRow.Cells[0].Value.ToString();

                // Add the removed quantity back to the stock in the 'Inventory' table
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks + @Quantity WHERE MedicineName = @medicineName";

                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Quantity", removedQty);
                        command.Parameters.AddWithValue("@medicineName", medicineName);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Stock updated successfully!");
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating stock: " + ex.Message);
                        }
                    }
                }

                double currentTotal = Convert.ToDouble(textBox58.Text);
                double newTotal = currentTotal - removedTotal;
                textBox58.Text = newTotal.ToString();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "V - Nutratech LC-Vit Plus Pet Multivitamins";

                int quantityToSubtract = int.Parse(textBox1.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox2.Checked = false;
                textBox1.Text = "";
            }
            else if (checkBox4.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "V - Virbac Nutriplus Gel";

                int quantityToSubtract = int.Parse(textBox2.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox4.Checked = false;
                textBox2.Text = "";
            }
            else if (checkBox6.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "V - Nutri-Vet Puppy-vite Chewables";

                int quantityToSubtract = int.Parse(textBox4.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox6.Checked = false;
                textBox4.Text = "";
            }
            else if (checkBox5.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "V - Papi MVP";

                int quantityToSubtract = int.Parse(textBox3.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox5.Checked = false;
                textBox3.Text = "";
            }
            else if (checkBox10.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "V - Canicee";

                int quantityToSubtract = int.Parse(textBox8.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox10.Checked = false;
                textBox8.Text = "";
            }
            else if (checkBox8.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AB - LC-Dox Doxycycline";

                int quantityToSubtract = int.Parse(textBox6.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox8.Checked = false;
                textBox6.Text = "";
            }
            else if (checkBox9.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AB - Motillex";

                int quantityToSubtract = int.Parse(textBox7.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox9.Checked = false;
                textBox7.Text = "";
            }
            else if (checkBox7.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AB - Emerflox Antibiotic";

                int quantityToSubtract = int.Parse(textBox5.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox7.Checked = false;
                textBox5.Text = "";
            }
            else if (checkBox14.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AM  - Ivermectin (IVM)";

                int quantityToSubtract = int.Parse(textBox13.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox14.Checked = false;
                textBox13.Text = "";
            }
            else if (checkBox12.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AM - Abamectin";

                int quantityToSubtract = int.Parse(textBox10.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox12.Checked = false;
                textBox10.Text = "";
            }
            else if (checkBox13.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AM - Doramectin";

                int quantityToSubtract = int.Parse(textBox14.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox13.Checked = false;
                textBox14.Text = "";
            }
            else if (checkBox11.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AM - Eprinomectin";

                int quantityToSubtract = int.Parse(textBox12.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox11.Checked = false;
                textBox12.Text = "";
            }
            else if (checkBox18.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AP - Flip Tick";

                int quantityToSubtract = int.Parse(textBox11.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox18.Checked = false;
                textBox11.Text = "";
            }
            else if (checkBox16.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AP - Flea Spot on";

                int quantityToSubtract = int.Parse(textBox9.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox16.Checked = false;
                textBox9.Text = "";
            }
            else if (checkBox17.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AP - Helminticide-L";

                int quantityToSubtract = int.Parse(textBox16.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox17.Checked = false;
                textBox16.Text = "";
            }
            else if (checkBox15.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "HP - Monthly chewable pills";

                int quantityToSubtract = int.Parse(textBox20.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox15.Checked = false;
                textBox20.Text = "";
            }
            else if (checkBox22.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "HP - Topical “spot on”";

                int quantityToSubtract = int.Parse(textBox17.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox22.Checked = false;
                textBox17.Text = "";
            }
            else if (checkBox20.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "HP - Injectable medication";

                int quantityToSubtract = int.Parse(textBox21.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox20.Checked = false;
                textBox21.Text = "";
            }
            else if (checkBox21.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "VC - Rabisin";

                int quantityToSubtract = int.Parse(textBox19.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox21.Checked = false;
                textBox19.Text = "";
            }
            else if (checkBox19.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "VC - Rabavert";

                int quantityToSubtract = int.Parse(textBox18.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox19.Checked = false;
                textBox18.Text = "";
            }
            else if (checkBox28.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "VC - Nobivac Canine 1-DAPPv";

                int quantityToSubtract = int.Parse(textBox15.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox28.Checked = false;
                textBox15.Text = "";
            }
            else if (checkBox24.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "VC - Nobivac Feline 1-HCP+FeLV";

                int quantityToSubtract = int.Parse(textBox23.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox24.Checked = false;
                textBox23.Text = "";
            }
            else if (checkBox27.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "VC - Nobivac Canine DHPPI";

                int quantityToSubtract = int.Parse(textBox27.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox27.Checked = false;
                textBox27.Text = "";
            }
            else if (checkBox25.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "VC - Nobivac Feline 1-HCP";

                int quantityToSubtract = int.Parse(textBox24.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox25.Checked = false;
                textBox24.Text = "";
            }
            else if (checkBox26.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AG - Local anaesthetics";

                int quantityToSubtract = int.Parse(textBox28.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox26.Checked = false;
                textBox28.Text = "";
            }
            else if (checkBox23.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AG - Ketamine";

                int quantityToSubtract = int.Parse(textBox26.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox23.Checked = false;
                textBox26.Text = "";
            }
            else if (checkBox3.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AG - Opioids (morphine or fentanyl)";

                int quantityToSubtract = int.Parse(textBox25.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox3.Checked = false;
                textBox25.Text = "";
            }
            else if (checkBox32.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "AG  - Alpha-2 agonists (xylazine)";

                int quantityToSubtract = int.Parse(textBox22.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox32.Checked = false;
                textBox22.Text = "";
            }
            else if (checkBox30.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "A - Cetirizine (Zyrtec, Reactine)";

                int quantityToSubtract = int.Parse(textBox30.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox30.Checked = false;
                textBox30.Text = "";
            }
            else if (checkBox31.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "EYE  - Ophthalmic Antibiotics";

                int quantityToSubtract = int.Parse(textBox34.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox31.Checked = false;
                textBox34.Text = "";
            }
            else if (checkBox29.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "EYE - Antifungal Eye Drops";

                int quantityToSubtract = int.Parse(textBox31.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox29.Checked = false;
                textBox31.Text = "";
            }
            else if (checkBox33.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "EYE  - Anti-Inflammatory Eye Drops";

                int quantityToSubtract = int.Parse(textBox35.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox33.Checked = false;
                textBox35.Text = "";
            }
            else if (checkBox37.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "EAR - Ear Cleansers";

                int quantityToSubtract = int.Parse(textBox33.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox37.Checked = false;
                textBox33.Text = "";
            }
            else if (checkBox35.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "EAR - Ear Mite Medications";

                int quantityToSubtract = int.Parse(textBox32.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox35.Checked = false;
                textBox32.Text = "";
            }
            else if (checkBox36.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "EAR - Antifungal Ear Drops";

                int quantityToSubtract = int.Parse(textBox29.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox36.Checked = false;
                textBox29.Text = "";
            }
            else if (checkBox34.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "EAR - Anti-Inflammatory Ear Drops";

                int quantityToSubtract = int.Parse(textBox38.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox34.Checked = false;
                textBox38.Text = "";
            }
            else if (checkBox38.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "DM - Antifungal Creams";

                int quantityToSubtract = int.Parse(textBox37.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox38.Checked = false;
                textBox37.Text = "";
            }
            else if (checkBox42.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "DM - Antiseborrheic Shampoos";

                int quantityToSubtract = int.Parse(textBox36.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox42.Checked = false;
                textBox36.Text = "";
            }
            else if (checkBox40.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "DM - Topical Antibiotics";

                int quantityToSubtract = int.Parse(textBox46.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox40.Checked = false;
                textBox46.Text = "";
            }
            else if (checkBox41.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "DM - Allergen-Specific Immunotherapy";

                int quantityToSubtract = int.Parse(textBox43.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox41.Checked = false;
                textBox43.Text = "";
            }
            else if (checkBox39.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "Chew toys (Bones, Ropes, Cloth, Plastic, Rubber)";

                int quantityToSubtract = int.Parse(textBox47.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox39.Checked = false;
                textBox47.Text = "";
            }
            else if (checkBox43.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "Plushies";

                int quantityToSubtract = int.Parse(textBox45.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox43.Checked = false;
                textBox45.Text = "";
            }
            else if (checkBox47.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "Puzzle Toys";

                int quantityToSubtract = int.Parse(textBox44.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox47.Checked = false;
                textBox44.Text = "";
            }
            else if (checkBox45.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "Balls";

                int quantityToSubtract = int.Parse(textBox40.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox45.Checked = false;
                textBox40.Text = "";
            }
            else if (checkBox46.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "Lasers";

                int quantityToSubtract = int.Parse(textBox42.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox46.Checked = false;
                textBox42.Text = "";
            }
            else if (checkBox44.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "Scratch Posts";

                int quantityToSubtract = int.Parse(textBox41.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox44.Checked = false;
                textBox41.Text = "";
            }
            else if (checkBox48.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "Catnip";

                int quantityToSubtract = int.Parse(textBox39.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox48.Checked = false;
                textBox39.Text = "";
            }
            else if (checkBox52.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "myCat wet and dry cat food";

                int quantityToSubtract = int.Parse(textBox55.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox52.Checked = false;
                textBox55.Text = "";
            }
            else if (checkBox50.Checked)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";
                string medicineName = "Whiskas wet and dry cat food";

                int quantityToSubtract = int.Parse(textBox52.Text);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Check if there are enough stocks available
                    string checkStockQuery = $"SELECT Stocks, Price FROM {inventoryTableName} WHERE MedicineName = @MedName";

                    using (OleDbCommand checkStockCommand = new OleDbCommand(checkStockQuery, connection))
                    {
                        checkStockCommand.Parameters.AddWithValue("@MedName", medicineName);

                        try
                        {
                            connection.Open();
                            OleDbDataReader reader = checkStockCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                int currentStock = Convert.ToInt32(reader["Stocks"]);
                                double price = Convert.ToDouble(reader["Price"]);

                                if (currentStock >= quantityToSubtract)
                                {
                                    // Subtract the quantity from the stock in the 'Inventory' table
                                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks - @Quantity WHERE MedicineName = @MedName";

                                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantity", quantityToSubtract);
                                        command.Parameters.AddWithValue("@MedName", medicineName);

                                        try
                                        {
                                            int rowsAffected = command.ExecuteNonQuery();
                                            if (rowsAffected > 0)
                                            {
                                                double total = quantityToSubtract * price;
                                                dataGridView1.Rows.Add(medicineName, price, quantityToSubtract, total);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error updating stock: " + ex.Message);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stocks available for product '{medicineName}'.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking stock: " + ex.Message);
                        }
                    }
                }

                checkBox50.Checked = false;
                textBox52.Text = "";
            }
            double sum = 0;

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[row].Cells[3].Value);
            }
            textBox58.Text = sum.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //check out
            this.Hide();
            Invoice invoiceForm = new Invoice();
            invoiceForm.SetLabelText(textBox58.Text);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataGridViewRow newRow = (DataGridViewRow)row.Clone();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        newRow.Cells[i].Value = row.Cells[i].Value;
                    }
                    invoiceForm.DataGridView1.Rows.Add(newRow);
                }
            }

            this.Hide(); //implement
            invoiceForm.Show();

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            string tableName = "Transactions";

            // Create the insert query with DateOfTransaction and TimeOfTransaction
            string query = $"INSERT INTO {tableName} (InvoiceNo, ProductOrService, Quantity, Price, Total, DateOfTransaction, TimeOfTransaction) " +
                "VALUES (@InvoiceNo, @ProdServ, @Quantity, @Price, @Total, @DateOfTransaction, @TimeOfTransaction)";

            Date = DateTime.Now.ToString("M/d/yyyy");
            // Retrieve DateOfTransaction and TimeOfTransaction from the 'Invoice' form
            string dateOfTransaction = Date;
            string timeOfTransaction = DateTime.Now.ToLongTimeString();

            // Create the connection and command
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Iterate over the rows in the dataGridView1
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Check if the row is not the new row
                        if (!row.IsNewRow)
                        {
                            // Get the values from the row
                            string productOrService = row.Cells[0].Value.ToString();
                            double price = Convert.ToDouble(row.Cells[1].Value);
                            int quantity = Convert.ToInt32(row.Cells[2].Value);
                            double total = Convert.ToDouble(row.Cells[3].Value);
                            string invoiceNo = invoiceForm.GetInvoiceNo();

                            // Set the parameter values
                            command.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                            command.Parameters.AddWithValue("@ProdServ", productOrService);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Price", price);
                            command.Parameters.AddWithValue("@Total", total);
                            command.Parameters.AddWithValue("@DateOfTransaction", dateOfTransaction);
                            command.Parameters.AddWithValue("@TimeOfTransaction", timeOfTransaction);

                            // Execute the insert command
                            command.ExecuteNonQuery();

                            // Clear the parameter values for the next iteration
                            command.Parameters.Clear();
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting data: " + ex.Message);
                }
            }

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = true;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = true;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = true;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = true;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = true;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = true;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = true;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = true;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = true;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = true;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox18_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = true;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = true;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = true;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = true;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = true;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = true;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = true;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = true;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = true;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = true;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = true;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = true;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = true;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = true;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = true;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = true;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = true;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = true;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = true;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = true;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = true;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = true;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = true;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = true;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = true;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = true;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = true;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = true;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = true;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = true;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = true;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = true;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = true;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = true;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = true;
            textBox55.Enabled = false;
            textBox52.Enabled = false;
        }

        private void checkBox52_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = true;
            textBox52.Enabled = false;
        }

        private void checkBox50_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            textBox13.Enabled = false;
            textBox10.Enabled = false;
            textBox14.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox9.Enabled = false;
            textBox16.Enabled = false;
            textBox20.Enabled = false;
            textBox17.Enabled = false;
            textBox21.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox15.Enabled = false;
            textBox23.Enabled = false;
            textBox27.Enabled = false;
            textBox24.Enabled = false;
            textBox28.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox22.Enabled = false;
            textBox30.Enabled = false;
            textBox34.Enabled = false;
            textBox31.Enabled = false;
            textBox35.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox29.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox46.Enabled = false;
            textBox43.Enabled = false;
            textBox47.Enabled = false;
            textBox45.Enabled = false;
            textBox44.Enabled = false;
            textBox40.Enabled = false;
            textBox42.Enabled = false;
            textBox41.Enabled = false;
            textBox39.Enabled = false;
            textBox55.Enabled = false;
            textBox52.Enabled = true;
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            //remove item

            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {
                double removedTotal = Convert.ToDouble(selectedRow.Cells[3].Value);
                dataGridView1.Rows.Remove(selectedRow);

                int removedQty = Convert.ToInt32(selectedRow.Cells[2].Value);
                string medicineName = selectedRow.Cells[0].Value.ToString();

                // Add the removed quantity back to the stock in the 'Inventory' table
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
                string inventoryTableName = "Inventory";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string updateQuery = $"UPDATE {inventoryTableName} SET Stocks = Stocks + @Quantity WHERE MedicineName = @medicineName";

                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Quantity", removedQty);
                        command.Parameters.AddWithValue("@medicineName", medicineName);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Stock updated successfully!");
                            }
                            else
                            {
                                MessageBox.Show($"No matching record found in the Inventory table for product '{medicineName}'.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating stock: " + ex.Message);
                        }
                    }
                }

                double currentTotal = Convert.ToDouble(textBox58.Text);
                double newTotal = currentTotal - removedTotal;
                textBox58.Text = newTotal.ToString();
            }
        }*/
    }
}