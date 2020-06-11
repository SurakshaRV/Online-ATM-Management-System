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
    public partial class CUSTOMER : Form
    {
        public static string s;
        public CUSTOMER()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=system;Password=Shubha_30;";
            OleDbConnection connection = new OleDbConnection(connetionString);
            connection.Open();

            string sql_search = "select count(*) from CUSTOMER1 where CUST_ID='" + tb1.Text + "'AND CUST_PASS='" + tb2.Text + "'";
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql_search, connection);

            DataTable dt = new DataTable();
            dataadapter.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Access Granted...");
                s = tb1.Text;
                new CUSTOMEROPTIONS().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter the correct Bank_id and Bank_password..");
            }
            connection.Close();
        }

        private void Bt2_Click(object sender, EventArgs e)
        {
            new welcomepage().Show();
            this.Hide();
        }
    }
}
