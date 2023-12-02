using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ticketwebsite
{
    public partial class Register : Form
    {
        MySqlConnection registerAccount = new MySqlConnection
       ("datasource=localhost;port=3306;username=root;password=''");

        public Register()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin loginPage = new Admin();
            loginPage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)
               || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }
            else
            {
                registerAccount.Open();

                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM buyticket.registeraccount WHERE Username = @UserName", registerAccount),
                cmd2 = new MySqlCommand("SELECT * FROM buyticket.registeraccount WHERE Email = @UserEmail", registerAccount);


                cmd1.Parameters.AddWithValue("@UserName", textBox2.Text);

                bool userExists = false;

                using (var dr1 = cmd1.ExecuteReader())
                    if (userExists = dr1.HasRows) MessageBox.Show("Username is already been used, please use different username");


                if (!(userExists))
                {

                    string iquery = "INSERT INTO buyticket.registeraccount(`ID`,`username`,`Email`,`password`) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text +  "')";
                    MySqlCommand commandDatabase = new MySqlCommand(iquery, registerAccount);
                    commandDatabase.CommandTimeout = 60;

                    try
                    {
                        // Reaching the datasets from the SQL Database
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Account Successfully Created!");

                }
                // Remove the inout values from the texboxes
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
               
                //Terminate SQL Connecion
                //registerAccount.Close();
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
