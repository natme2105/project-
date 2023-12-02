namespace ticketwebsite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin mainPage = new Admin();
            mainPage.ShowDialog();
        }

     
  private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            buy_ticket loginPage = new buy_ticket();
            loginPage.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Contact loginPage = new Contact();
            loginPage.ShowDialog();
        }
    }
}