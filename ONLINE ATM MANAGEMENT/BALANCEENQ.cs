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
    public partial class BALANCEENQ : Form
    {
        public BALANCEENQ()
        {
            InitializeComponent();
            // tb1.Text = "hello" + System.Environment.NewLine + "world";
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=system;Password=Shubha_30;";
            string s2 = CUSTOMER.s;       
            string sql = "SELECT CUST_ID,FNAME,LNAME,CUST_ADDRESS,CUST_PHONE FROM CUSTOMER1 WHERE CUST_ID='"+s2+"'";
            string sql2 = "SELECT * FROM ACCOUNT1 WHERE ACC_CUST_ID='" + s2 + "'";
            OleDbConnection connection = new OleDbConnection(connetionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
            OleDbDataAdapter dataadapter2 = new OleDbDataAdapter(sql2, connection);
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            connection.Open();
            DataTable dt = new DataTable();
            dataadapter.Fill(dt);
            string s = dt.Rows[0]["CUST_ID"].ToString();
            string s1 = dt.Rows[0]["FNAME"].ToString();
            string s5 = dt.Rows[0]["LNAME"].ToString();
            string s3 = dt.Rows[0]["CUST_ADDRESS"].ToString();
            string s4 = dt.Rows[0]["CUST_PHONE"].ToString();
            tb1.Text = "Customer ID : "+ s+System.Environment.NewLine + "First Name : "+s1+ System.Environment.NewLine+"Last Name : "+s5+ System.Environment.NewLine+"Address : "+s3+ System.Environment.NewLine+"Phone No : "+s4;
            DataTable dt2 = new DataTable();
            dataadapter2.Fill(dt2);
            string s6 = dt2.Rows[0]["ACC_NO"].ToString();
            string s7 = dt2.Rows[0]["ACC_TYPE"].ToString();
            string s8 = dt2.Rows[0]["ACC_BALANCE"].ToString();
            tb2.Text = "Account No : " + s6 + System.Environment.NewLine + "Account Type : " + s7 + System.Environment.NewLine + "Balance : Rs " + s8 ;
            dataadapter.Fill(ds, "CUSTOMER1");
            dataadapter2.Fill(ds2, "ACCOUNT1");
            connection.Close();
            /*dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "CUSTOMER1";
            dataGridView2.DataSource = ds2;
            dataGridView2.DataMember = "ACCOUNT1";*/
        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            new CUSTOMEROPTIONS().Show();
            this.Hide();
        }
    }
}
