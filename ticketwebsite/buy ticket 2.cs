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
    public partial class buy_ticket_2 : Form
    {
        public buy_ticket_2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            buy_ticket loginPage = new buy_ticket();
            loginPage.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginPage = new Form1();
            loginPage.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Parokya_ni_edgar loginPage = new Parokya_ni_edgar();
            loginPage.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Parokya_ni_edgar loginPage = new Parokya_ni_edgar();
            loginPage.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Parokya_ni_edgar loginPage = new Parokya_ni_edgar();
            loginPage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Parokya_ni_edgar loginPage = new Parokya_ni_edgar();
            loginPage.ShowDialog();
        }

        private void buy_ticket_2_Load(object sender, EventArgs e)
        {

        }
    }
}
