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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ticketwebsite
{
    public partial class Parokya_ni_edgar : Form
    {
        MySqlConnection events= new MySqlConnection
       ("datasource=localhost;port=3306;username=root;password=''");
        public Parokya_ni_edgar()
        {
            InitializeComponent();
        }

        private void Parokya_ni_edgar_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            buy_ticket loginPage = new buy_ticket();
            loginPage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(checkedListBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }

            try
            {
                using (MySqlConnection events = new MySqlConnection("datasource=localhost;port=3306;username=root;password='';database=buyticket"))
                {
                    events.Open();

                    string iquery = "INSERT INTO events (TicketPurchased, EventName, TicketType) " +
                                    "VALUES (@TicketPurchased, @EventName, @TicketType)";

                    using (MySqlCommand commandDatabase = new MySqlCommand(iquery, events))
                    {
                        // Assuming ParokyaniEdgarEventID is an integer, replace 'YourEventIDValue' with the actual event ID value.
                        // Also, replace 'YourConnectionString' with the actual connection string.

                        commandDatabase.Parameters.AddWithValue("@TicketPurchased", textBox1.Text);
                        commandDatabase.Parameters.AddWithValue("@EventName", textBox2.Text);  // Use the actual source for EventName
                        commandDatabase.Parameters.AddWithValue("@TicketType", checkedListBox1.Text);

                        int rowsAffected = commandDatabase.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
            finally
            {
                // No need to explicitly close the connection; using statement takes care of it.
            }

            this.Hide();
            payment parokya = new payment();
            parokya.ShowDialog();
        }

            private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

