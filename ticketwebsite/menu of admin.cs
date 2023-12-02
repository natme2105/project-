using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticketwebsite
{
    public partial class menu_of_admin : Form
    {
        private MySqlConnection connection;
        private string connectionString = "datasource=localhost;port=3306;username=root;password=''"; // Replace with your actual connection string
        public menu_of_admin()
        {
            InitializeComponent();

        }

        private void InitializeDatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginPage = new Form1();
            loginPage.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void menu_of_admin_Load(object sender, EventArgs e)
        {

            LoadData();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''"))
                {
                    connection.Open();

                    string query = "SELECT * FROM buyticket.events";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Assuming dataGridView1 is the name of your DataGridView control
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''"))
                {
                    connection.Open();

                    string query = "SELECT * FROM buyticket.events";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Assuming dataGridView1 is the name of your DataGridView control
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Assuming you have textboxes or controls for user input
            string eventNameToUpdate = textBox3.Text; // Replace with your actual textbox name
            string ticketTypeToUpdate = textBox4.Text; // Replace with your actual textbox name
            int eventIDToUpdate = Convert.ToInt32(textBox1.Text); // Replace with your actual textbox name

            try
            {
                using (MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password='';database=buyticket"))
                {
                    connection.Open();

                    // Assuming 'EventID' is the primary key
                    string updateQuery = "UPDATE Events SET EventName = @EventName, TicketType = @TicketType WHERE EventID = @EventID";
                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@EventName", eventNameToUpdate);
                    command.Parameters.AddWithValue("@TicketType", ticketTypeToUpdate);
                    command.Parameters.AddWithValue("@EventID", eventIDToUpdate);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No matching record found. Data not updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Assuming you have a textbox or control for user input
            int eventIDToDelete = Convert.ToInt32(textBox1.Text); // Replace with your actual textbox name

            try
            {
                using (MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password='';database=buyticket"))
                {
                    connection.Open();

                    // Assuming 'EventID' is the primary key
                    string deleteQuery = "DELETE FROM Events WHERE EventID = @EventID";
                    MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@EventID", eventIDToDelete);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No matching record found. Data not deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
