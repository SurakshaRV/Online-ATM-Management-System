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
    public partial class BANKER : Form
    {
        public static string s;
        public BANKER()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=system;Password=Shubha_30;";
            string sql = "SELECT * FROM BANK1";
            OleDbConnection connection = new OleDbConnection(connetionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
            DataSet ds;
            ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "BANK1");

            string sql1 = "Insert into BANK1 VALUES ('" + tb1.Text + "', '" + tb2.Text + "','" + tb3.Text + "', '" + tb4.Text + "','" + tb5.Text + "' )";
            dataadapter.InsertCommand = new OleDbCommand(sql1, connection);
            dataadapter.InsertCommand.ExecuteNonQuery();
            //MessageBox.Show("Row(s) Inserted !! ");
            dataadapter.Fill(ds, "BANK1");
            /* dataGridView1.DataSource = ds;
             dataGridView1.DataMember = "stude_info";
             dataGridView1.Refresh();*/
            connection.Close();
            new BANKEROPTIONS().Show();
            this.Hide();
        }

        private void Bt2_Click(object sender, EventArgs e)
        {
            new welcomepage().Show();
            this.Hide();
        }

        private void Bt3_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=system;Password=Shubha_30;";
            OleDbConnection connection = new OleDbConnection(connetionString);
            connection.Open();

            string sql_search = "select count(*) from BANK1 where BANK_ID='" + tb6.Text + "'AND BANK_PASS='" + tb7.Text + "'";
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql_search, connection);
            
            DataTable dt = new DataTable();
            dataadapter.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Access Granted...");
                s = tb6.Text;
                new BANKEROPTIONS().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter the correct Bank_id and Bank_password..");
            }

            connection.Close();
            

        }

        private void Bt4_Click(object sender, EventArgs e)
        {
            new welcomepage().Show();
            this.Hide();
        }

        private void Tb3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
