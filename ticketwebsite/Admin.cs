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
    public partial class Admin : Form
    {
        private Register Register;

        MySqlConnection connection =
            new MySqlConnection
            ("datasource=localhost;port=3306;username=root;password=''");
        MySqlCommand command;
        MySqlDataReader mdr;
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginPage = new Form1();
            loginPage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register loginPage = new Register();
            loginPage.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter both Username and Password", "No Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''"))
                {
                    try
                    {
                        connection.Open();

                        // Use parameterized query to prevent SQL injection
                        string selectQuery = "SELECT * FROM buyticket.adminaccount WHERE Username = @Username AND Password = @Password";
                        MySqlCommand command = new MySqlCommand(selectQuery, connection);
                        command.Parameters.AddWithValue("@Username", textBox1.Text);
                        command.Parameters.AddWithValue("@Password", textBox2.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Admin Login Successful!");
                                // Code for connecting to the 'AdminAccount' database here
                                this.Hide();
                                menu_of_admin mainPage = new menu_of_admin();
                                mainPage.ShowDialog();
                            }
                            else
                            {
                                // Close the first DataReader before executing the second query
                                reader.Close();

                                // Check user accounts
                                string selectUserQuery = "SELECT * FROM buyticket.registeraccount WHERE Username = @Username AND Password = @Password";
                                MySqlCommand userCommand = new MySqlCommand(selectUserQuery, connection);
                                userCommand.Parameters.AddWithValue("@Username", textBox1.Text);
                                userCommand.Parameters.AddWithValue("@Password", textBox2.Text);

                                using (MySqlDataReader userReader = userCommand.ExecuteReader())
                                {
                                    if (userReader.Read())
                                    {
                                        MessageBox.Show("User Login Successful!");
                                        this.Hide();
                                        menu_of_admin mainPage = new menu_of_admin();
                                        mainPage.ShowDialog();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Incorrect Login Information! Try again.");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                textBox1.Clear();
                textBox2.Clear();
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginPage = new Form1();
            loginPage.ShowDialog();
        }
    }
}
