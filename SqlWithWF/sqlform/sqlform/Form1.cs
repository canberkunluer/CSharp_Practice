using System.Data;
using System.Data.SqlClient;

namespace sqlform
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        public Form1()
        {
            InitializeComponent();

            btnCloseConn.Click += btnCloseConn_Click;
            btnOpenConn.Click += BtnOpenConn_Click;
           // var _str = "Server=.;Database=AdventureWorks;Uid=;Pwd=;
            var _str = "Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=SSPI";
            conn.ConnectionString= _str;    
        }
        private void BtnOpenConn_Click(object? sender, EventArgs e)
        {
            try
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                    label1.Text = "Open!";
                }
                else
                {
                    label1.Text = "Not Open!";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCloseConn_Click(object? sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    label1.Text = "Close!";
                }
                else
                {
                    label1.Text = "Not CLose!";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}