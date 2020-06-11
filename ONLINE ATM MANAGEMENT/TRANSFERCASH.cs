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
    public partial class TRANSFERCASH : Form
    {
       // public static string s1;
        public TRANSFERCASH()
        {
            InitializeComponent();
        }

        private void TRANSFERCASH_Load(object sender, EventArgs e)
        {

        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=system;Password=Shubha_30;";
            OleDbConnection connection = new OleDbConnection(connetionString);
            connection.Open();
           string sql_search = "select count(*) from ACCOUNT1,CARD1 where ACC_CUST_ID=CARD_CUST_ID AND ACC_NO='" + tb1.Text + "'AND CARD_NO='" + tb3.Text + "'AND CVV='"+tb5.Text+"'";
           
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql_search, connection);
            //s1 = tb3.Text;
            DataTable dt = new DataTable();
            dataadapter.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
               // MessageBox.Show("Access Granted...");
                //int a = int.Parse(tb6.Text);
               string sql1 = "UPDATE ACCOUNT1 SET ACC_BALANCE=ACC_BALANCE-'"+tb6.Text+"' where acc_no='"+tb1.Text+"'";
                string sql2 = "UPDATE ACCOUNT1 SET ACC_BALANCE=ACC_BALANCE+'"  +int.Parse(tb6.Text) + "'where acc_no='"+tb2.Text+"'";
                MessageBox.Show("Successfully completed the transaction...");
                OleDbDataAdapter dataadapter2 = new OleDbDataAdapter(sql1, connection);
                OleDbDataAdapter dataadapter3 = new OleDbDataAdapter(sql2, connection);
                DataTable dt2 = new DataTable();
                dataadapter2.Fill(dt2);
                DataTable dt3 = new DataTable();
                dataadapter3.Fill(dt3);
                MessageBox.Show("Successfully completed the transaction...");
                int i,j;
                Random rand = new Random();
                i = rand.Next(20, 100);
                j = rand.Next(100, 200);
                DateTime now = DateTime.Now;
                string sql4 = "SELECT * FROM TRANSACTION1";
                //OleDbConnection connection1 = new OleDbConnection(connetionString);
                OleDbDataAdapter dataadapter1 = new OleDbDataAdapter(sql4, connection);
                DataSet ds;
                ds = new DataSet();
                dataadapter1.Fill(ds, "TRANSACTION1");
                string sql5 = "SELECT CARD_NO FROM CARD1,ACCOUNT1 WHERE CARD_CUST_ID=ACC_CUST_ID AND ACC_NO='" + tb2.Text + "'";
                OleDbDataAdapter dataadapter5 = new OleDbDataAdapter(sql5, connection);
                DataTable dt5 = new DataTable();
                dataadapter5.Fill(dt5);
                string s = "\0";
                s = dt5.Rows[0]["CARD_NO"].ToString();
                string sql6 = "Insert into TRANSACTION1 VALUES ('" + j + "', '" + now + "','" + "CREDIT" + "', '" + int.Parse(s) + "','" + tb6.Text + "' )";
                dataadapter1.InsertCommand = new OleDbCommand(sql6, connection);
                dataadapter1.InsertCommand.ExecuteNonQuery();
                string sql3 = "Insert into TRANSACTION1 VALUES ('" + i + "', '" + now + "','" + "DEBIT" + "', '" + tb3.Text + "','" + tb6.Text + "' )";
                dataadapter1.InsertCommand = new OleDbCommand(sql3, connection);
                dataadapter1.InsertCommand.ExecuteNonQuery();
               // MessageBox.Show("Row(s) Inserted !! ");
                dataadapter1.Fill(ds, "TRANSACTION1");
                connection.Close();
            }
            else
            {
                MessageBox.Show("Enter the correct CARD NO and CARD CVV..");
            }
            
            connection.Close();
           // new BANKEROPTIONS().Show();
           // this.Hide();

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Bt2_Click(object sender, EventArgs e)
        {
            new CUSTOMEROPTIONS().Show();
             this.Hide();
        }

        private void Tb5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
