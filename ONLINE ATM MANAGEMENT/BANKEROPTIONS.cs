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
    public partial class BANKEROPTIONS : Form
    {
        public BANKEROPTIONS()
        {
            InitializeComponent();
        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=system;Password=Shubha_30;";
            // string sql = "SELECT * FROM TRANSACTION1 ";
            string s2 = BANKER.s;
           string sql2="SELECT T_ID,T_TIME,T_TYPE,T_CARD_NO,T_AMT FROM TRANSACTION1,CARD1,BANK1 WHERE T_CARD_NO=CARD_NO AND CARD_BANK_NAME=BANK_NAME AND BANK_ID='"+s2+"'";
            OleDbConnection connection = new OleDbConnection(connetionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql2, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "TRANSACTION1");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TRANSACTION1";
        }

        private void Bt2_Click(object sender, EventArgs e)
        {
            new BANKER().Show();
            this.Hide();
        }
    }
}
