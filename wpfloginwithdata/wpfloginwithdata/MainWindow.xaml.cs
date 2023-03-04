using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfloginwithdata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductDAL pd = new ProductDAL();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NWConnStr"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;
        public MainWindow()
        {
            InitializeComponent();
            btnlogin.Click += Btnlogin_Click;
            btnsignup.Click += Btnsignup_Click;
           
        }
        private void Btnsignup_Click(object sender, RoutedEventArgs e)
        {
            string sql = string.Empty;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NWConnStr"].ConnectionString);
            SqlCommand cmd;
            sql = "INSERT INTO Employees(LastName,FirstName) VALUES(@lname,@fname)";
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@fname", txtsignupname.Text);
                    cmd.Parameters.AddWithValue("@lname", txtsignuplastname.Text);
                    MessageBox.Show("Başarıyla Yeni Kullanıcı Eklendi");
                }
                int sonuc = cmd.ExecuteNonQuery();
                
                if (sonuc > 0)
                {
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                { 
                    conn.Close();
                }
            }
        }
        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            string sorgu = "SELECT * FROM Employees where FirstName=@firstname AND LastName=@lastname";
            cmd = new SqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@firstname", txtfisrtname.Text);
            cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            { 
                Window1 obj= new Window1();
                this.Visibility = Visibility.Hidden;
                obj.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            conn.Close();
        }

       
    }
    

}
