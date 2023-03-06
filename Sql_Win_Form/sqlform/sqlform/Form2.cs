using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace sqlform
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NWConnStr"].ConnectionString);
        public Form2()
        {
            InitializeComponent();
            btnClear.Click += BtnClear_Click;
            btnProcedure.Click += BtnProcedure_Click;
            btnReader.Click += BtnReader_Click;
            btnReport.Click += BtnReport_Click;
            btnScalar.Click += BtnScalar_Click;
        }
            void VerileriOku(int deger)
        {
            string sql = "SELECT ProductID, ProductName FROM Products WHERE ProductID <=7;";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder builder = new StringBuilder();
                while (reader.Read())
                {
                    builder.Append("**********");
                    builder.Append(Environment.NewLine);
                    builder.Append("Ürün NO :");
                    builder.Append(reader[0]);
                    builder.Append(Environment.NewLine);
                    builder.Append("Ürün Ad :");
                    builder.Append(reader[1]);
                    builder.Append(Environment.NewLine);
                }
                conn.Close();
                txtResult.Text = builder.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }
            void ExecuteReaderNextResult()
        {
            string sql = "SELECT ProductID, ProductName FROM Products WHERE ProductID <= 5;SELECT CustomerID, CompanyName FROM Customers WHERE CustomerID LIKE 'A%'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                bool bResult = false;
                StringBuilder builder = new StringBuilder();
                do
                {

                    while (dr.Read())
                    {
                        builder.Append("**********");
                        builder.Append(Environment.NewLine);
                        builder.Append("Ürün NO :");
                        builder.Append(dr[0]);
                        builder.Append(Environment.NewLine);
                        builder.Append("Ürün Ad :");
                        builder.Append(dr[1]);
                        builder.Append(Environment.NewLine);
                    }
                    bResult = dr.NextResult();
                } while (bResult);
                txtResult.Text = builder.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
            void ExecuteScalar()
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT COUNT(ProductID) FROM Products;";
                    conn.Open();
                    string s = cmd.ExecuteScalar().ToString();
                    txtResult.Text = s + " " + "kayıt bulundu";
                    conn.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

           void  StoredProcedure()
             {
            try
            {
             SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pr_UrunleriGetir";
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder builder = new StringBuilder();
                while (reader.Read())
                {
                    builder.Append("*********");
                    builder.Append(Environment.NewLine);
                    builder.Append("Ürün ID");
                    builder.Append(reader.GetInt32(0));
                    builder.Append("Ürün Ad");
                    builder.Append(reader.GetString(1));
                    builder.Append(Environment.NewLine);
                }
                reader.Close();
                conn.Close();
                txtResult.Text = builder.ToString();
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

             }
        void ExecuteStoredProcedure(string name,decimal costRate,
            decimal availabiliy,DateTime modifiedDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.CommandText = "pr_AddLocation";

                SqlParameter pName = new SqlParameter();
                pName.ParameterName ="Name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.NVarChar;

                SqlParameter pCostrate = new SqlParameter();
                pCostrate.ParameterName = "CostRate";
                pCostrate.Value = name;
                pCostrate.SqlDbType = SqlDbType.Decimal;

                SqlParameter pAvailability = new SqlParameter();
                pAvailability.ParameterName = "Availability";
                pAvailability.Value = name;
                pAvailability.SqlDbType = SqlDbType.Decimal;

                SqlParameter pModifiedDate = new SqlParameter();
                pModifiedDate.ParameterName = "ModifiedDate";
                pModifiedDate.Value = name;
                pModifiedDate.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(pName);
                cmd.Parameters.Add(pCostrate);
                cmd.Parameters.Add(pAvailability);
                cmd.Parameters.Add(pModifiedDate);
                cmd.Connection.Open();
                int x = cmd.ExecuteNonQuery();
                txtResult.Text = x.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
            private void BtnScalar_Click(object? sender, EventArgs e)
            {
                ExecuteScalar();
            }
            private void BtnReport_Click(object? sender, EventArgs e)
            {

            }
            private void BtnReader_Click(object? sender, EventArgs e)
            {
            StoredProcedure();
                //ExecuteReaderNextResult();
            }
            private void BtnProcedure_Click(object? sender, EventArgs e)
            {
            ExecuteStoredProcedure("Beşiktaş",11.3M,33.2M,DateTime.Now);
            }
            private void BtnClear_Click(object? sender, EventArgs e)
            {

            }
        }
    }

