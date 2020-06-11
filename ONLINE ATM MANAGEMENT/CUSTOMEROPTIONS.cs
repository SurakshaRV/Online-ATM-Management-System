using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace project1
{
    public partial class CUSTOMEROPTIONS : Form
    {
        public CUSTOMEROPTIONS()
        {
            InitializeComponent();
        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            if (rb3.Checked==true)
            {
                new TRANSFERCASH().Show();
                this.Hide();
            }
            else if(rb1.Checked==true)
            {
                new BALANCEENQ().Show();
                this.Hide();
            }
            else if(rb4.Checked==true)
            {
                new TRANSACTION().Show();
                this.Hide();
            }
        }

        private void Bt2_Click(object sender, EventArgs e)
        {
            new CUSTOMER().Show();
            this.Hide();
        }
    }
}
