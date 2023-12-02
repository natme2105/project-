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
    public partial class buy_ticket : Form
    {
        public buy_ticket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginPage = new Form1();
            loginPage.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            comformation_paymet loginPage = new comformation_paymet();
            loginPage.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Parokya_ni_edgar loginPage = new Parokya_ni_edgar();
            loginPage.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            buy_ticket_2 loginPage = new buy_ticket_2();
            loginPage.ShowDialog();
        }

        private void BUY_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Parokya_ni_edgar loginPage = new Parokya_ni_edgar();
            loginPage.ShowDialog();
        }

        private void button2_Click_2(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Parokya_ni_edgar loginPage = new Parokya_ni_edgar();
            loginPage.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Parokya_ni_edgar loginPage = new Parokya_ni_edgar();
            loginPage.ShowDialog();
        }
    }
}
