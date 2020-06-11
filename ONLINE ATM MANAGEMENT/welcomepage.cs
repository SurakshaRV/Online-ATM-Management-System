using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class welcomepage : Form
    {
        public welcomepage()
        {
            InitializeComponent();
        }

        private void Bt2_Click(object sender, EventArgs e)
        {
            new CUSTOMER().Show();
            this.Hide();
        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            new BANKER().Show();
            this.Hide();
        }
    }
}
