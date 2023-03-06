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
using sqlform2.Business;
using System.Net;
using System.Data.Common;

namespace sqlform2.Database
{
    public class ShipperDAL :Form
    {
        string sql = string.Empty;
        SqlConnection conn = new SqlConnection(Database.GetCOnnectionString);
        SqlCommand cmd;
        bool result;

        public bool Add(string companyName,string phone)
        {
            sql = "INSERT INTO Shippers VALUES('" + companyName + "' ,'" + phone+"')";
            cmd  = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                result=true;
                }
            }
            catch (Exception ex)
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
            return result;
        }
        public bool Update(int id, string companyName, string phone)
        {
            

            sql = "UPDATE  Shippers SET CompanyName =@name,Phone = @phone   WHERE ShipperID = " + id;
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@name", companyName);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    
                }
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    result = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public bool Delete(int id)
        {
            sql = "DELETE FROM Shippers WHERE ShipperID = " + id;
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    result = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public string GetCompanyNameById(int id)
        {
            sql =  "SELECT CompanyName FROM Shippers WHERE ShipperID = "+ id;
            string companyName = string.Empty;
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                companyName = cmd.ExecuteScalar().ToString() ;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return companyName;

        }
        //public List<Shipper> GetShippers()
        //{
        //    sql = "SELECT ShippersID,CompanyName  FROM Shippers   ";
        //    List<Shipper> _shippers = new List<Shipper>();


        //    cmd = new SqlCommand(sql, conn);
        //    try
        //    {
        //        if (conn.State != ConnectionState.Open)
        //        {
        //            conn.Open();
        //        }
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            _shippers.Add(new Shipper((int)dr["ShipperID"], dr[1].ToString(), dr[2].ToString()));
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        if (conn.State != ConnectionState.Closed)
        //        {
        //            conn.Close();
        //        }
        //    }

        }

    }
}
