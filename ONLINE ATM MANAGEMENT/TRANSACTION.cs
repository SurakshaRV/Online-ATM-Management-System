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
    public partial class TRANSACTION : Form
    {
        public TRANSACTION()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=system;Password=Shubha_30;";
            string sql = "SELECT * FROM TRANSACTION1 WHERE T_CARD_NO='" + tb1.Text + "'";
            string sql2="SELECT SUM(T_AMT) FROM TRANSACTION1 WHERE T_TYPE='CREDIT' AND T_CARD_NO='"+tb1.Text + "'";
            string sql3 = "SELECT SUM(T_AMT) FROM TRANSACTION1 WHERE T_TYPE='DEBIT' AND T_CARD_NO='" + tb1.Text + "'";
            OleDbConnection connection = new OleDbConnection(connetionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
            OleDbDataAdapter dataadapter2 = new OleDbDataAdapter(sql2, connection);
            OleDbDataAdapter dataadapter3 = new OleDbDataAdapter(sql3, connection);
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "TRANSACTION1");
                 dataadapter2.Fill(ds2, "TRANSACTION1");
            dataadapter3.Fill(ds3, "TRANSACTION1");
            DataTable dt5 = new DataTable();
            dataadapter2.Fill(dt5);
            string s = "\0";
            s = dt5.Rows[0][0].ToString();
            DataTable dt6 = new DataTable();
            dataadapter3.Fill(dt6);
            string s1 = "\0";
            s1 = dt6.Rows[0][0].ToString();
            tb2.Text = "Total amount credited : Rs "+s+ System.Environment.NewLine+"Total amount debited : Rs "+s1;
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TRANSACTION1";
        }

        private void Bt2_Click(object sender, EventArgs e)
        {
            new CUSTOMEROPTIONS().Show();
            this.Hide();
        }
    }
}
