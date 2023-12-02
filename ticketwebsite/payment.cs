using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ticketwebsite
{
    public partial class payment : Form
    {
        MySqlConnection events = new MySqlConnection
       ("datasource=localhost;port=3306;username=root;password=''");
        public payment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Image";
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Display the selected image in the PictureBox
                        pictureBox1.Image = new System.Drawing.Bitmap(openFileDialog.FileName);

                        // Assuming you want to store the image as a byte array
                        byte[] imageBytes;
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Adjust the image format accordingly
                            imageBytes = ms.ToArray();
                        }

                        // Store the image location
                        var imagelocation = openFileDialog.FileName;

                        // Use the imageBytes as needed
                        // ...

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if all required information is filled out
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox2.Text) || pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }

            // Create a connection to the database
            using (MySqlConnection paymentConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password='';database=buyticket"))
            {
                try
                {
                    paymentConnection.Open();

                    // Prepare the SQL query
                    string iquery = "INSERT INTO payment (`GcashNumber`, `Conformation`, `EventID`, `TicketImage`) " +
                                    "VALUES (@GcashNumber, @Conformation, @EventID, @TicketImage)";

                    // Create a command with parameters
                    using (MySqlCommand commandDatabase = new MySqlCommand(iquery, paymentConnection))
                    {
                        commandDatabase.Parameters.AddWithValue("@GcashNumber", textBox2.Text);
                        commandDatabase.Parameters.AddWithValue("@Conformation", true); // Assuming confirmation is true when the button is clicked
                        commandDatabase.Parameters.AddWithValue("@EventID", textBox3.Text);

                        // Convert the image to a byte array
                        byte[] imageBytes;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, ImageFormat.Jpeg); // Adjust the image format accordingly
                            imageBytes = ms.ToArray();
                        }
                        commandDatabase.Parameters.AddWithValue("@TicketImage", imageBytes);

                        // Execute the query
                        int rowsAffected = commandDatabase.ExecuteNonQuery();

                        // Check if data was inserted successfully
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert data.", "Error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                }
            }

        }

        private void payment_Load(object sender, EventArgs e)
        {

        }

    }
}



