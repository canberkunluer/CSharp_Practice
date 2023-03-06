using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using System.Configuration;
using System.Windows.Controls.Primitives;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.Sqlite;
using SolrNet.Commands.Cores;
using System.Runtime.CompilerServices;
namespace wpfloginwithdata
{
    public class ProductDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NWConnStr"].ConnectionString);
        SqlCommand cmd;
        bool result;

        public bool AddProducts(string productname, int supplierid, int categoryid, string quantityperunit, int unitprice, int unitsinstock, int unitsonorder, int reorderlevel, bool discontinued) //parametre olarak alması gerekiyor. /bu kod çöpmüş 
        {
            string sql = string.Empty;
            sql = "INSERT INTO Products(ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,Reorderlevel,Discontinued)" +
                " VALUES              (@productname,@supplierid,@categoryid,@quantityperunit,@unitprice,@unitsinstock,@unitsonorder,@reorderlevel,@discontinued)";
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    cmd.Parameters.AddWithValue("@productname", productname);
                    cmd.Parameters.AddWithValue("@supplierid", supplierid);
                    cmd.Parameters.AddWithValue("@categoryid", categoryid);
                    cmd.Parameters.AddWithValue("@quantityperunit", quantityperunit);
                    cmd.Parameters.AddWithValue("@unitprice", unitprice);
                    cmd.Parameters.AddWithValue("@unitsinstock", unitsinstock);
                    cmd.Parameters.AddWithValue("@unitsonorder", unitsonorder);
                    cmd.Parameters.AddWithValue("@reorderlevel", reorderlevel);
                    cmd.Parameters.AddWithValue("@discontinued", discontinued);
                }
                conn.Open();
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    result = true;
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
            return result;
        }
        public List<Product> GetProducts()
        {

            List<Product> _products = new List<Product>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products;", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product product = new Product();
                product.ProductID = (int)dr[0];
                product.ProductName = dr[1].ToString();
                product.SupplierID = (int)dr[2];
                product.CategoryID = Convert.ToInt32(dr[3]);
                product.QuantityPerUnit = dr[4].ToString(); ;
                product.UnitPrice = Convert.ToDecimal(dr[5]);
                product.UnitsInStock = Convert.ToInt16(dr[6]);
                product.UnitsOnOrder = Convert.ToInt16(dr[7]);
                product.ReorderLevel = Convert.ToInt16(dr[8]);
                product.Discontinued = dr.GetBoolean(9);




                _products.Add(product);
            }
            try
            {
                
               // datagrid.ItemsSource = dt.DefaultView;
                //dg.ItemsSource = dt.DefaultView;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return _products;
        }

public List<Categories> GetCategories()
        {
            List<Categories> _categories = new List<Categories>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Categories categories= new Categories();
                categories.CategoryID= Convert.ToInt32(dr[0]);
                categories.CategoryName = dr[1].ToString();
                categories.Description = dr[2].ToString();
                _categories.Add(categories);
            }
            try
            {
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return _categories;
        }
        public List<Supplier> GetSuppliers()
        {
            List<Supplier> _suppliers = new List<Supplier>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Supplier supplier = new Supplier();
                supplier.ShipperID = Convert.ToInt32(dr[0]);
                supplier.CompanyName = dr[1].ToString();
                supplier.Phone = dr[2].ToString();
                _suppliers.Add(supplier);
            }
            try
            {
              
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return _suppliers;
        }
        public bool AddCategory(string categoryname,string desc)
        {
            string sql = string.Empty;
            SqlCommand cmd;
            sql = "INSERT INTO Categories(CategoryName,Description) VALUES(@categoryname,@categorydesc)";
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@categoryname", categoryname);
                    cmd.Parameters.AddWithValue("@categorydesc", desc);
                }
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    result = true;
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
            return result;
        }
        public bool AddSupplier(string companyname,string contactname)
        {
            string sql = string.Empty;
            sql = "INSERT INTO Suppliers(CompanyName,ContactName) VALUES(@companyname,@contactname)";
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@companyname", companyname);
                    cmd.Parameters.AddWithValue("@contactname", contactname);
                }
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    result = true;
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
            return result;
        }
        public bool DeleteProducts(int id)
        {
            SqlCommand cmd;
            string sql = string.Empty;
            sql = "DELETE FROM Products WHERE ProductID = " + id;
            cmd = new SqlCommand(sql, conn);

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    result = true;
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
            return result;
        }
        public bool UpdateProducts(int id, string productname, int supplierid, int categoryid, string quantityperunit, int unitprice, int unitsinstock, int unitsonorder, int reorderlevel, bool discontinued)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NWConnStr"].ConnectionString);
            SqlCommand cmd;
            string sql = string.Empty;
            sql = "UPDATE Products SET ProductName =@productname,SupplierID=@supplierid,CategoryID = @categoryid,QuantityPerUnit = @quantityperunit," +
                "UnitPrice = @unitprice,UnitsInStock =@unitsinstock,UnitsOnOrder = @unitsonorder,Reorderlevel =@reorderlevel,Discontinued = @discontinued " +
                "WHERE ProductID = @productid";
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    cmd.Parameters.AddWithValue("@productid", id);
                    cmd.Parameters.AddWithValue("@productname", productname);
                    cmd.Parameters.AddWithValue("@supplierid", supplierid);
                    cmd.Parameters.AddWithValue("@categoryid", categoryid);
                    cmd.Parameters.AddWithValue("@quantityperunit", quantityperunit);
                    cmd.Parameters.AddWithValue("@unitprice", unitprice);
                    cmd.Parameters.AddWithValue("@unitsinstock", unitsinstock);
                    cmd.Parameters.AddWithValue("@unitsonorder", unitsonorder);
                    cmd.Parameters.AddWithValue("@reorderlevel", reorderlevel);
                    cmd.Parameters.AddWithValue("@discontinued", discontinued);
                }
                conn.Open();
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    result = true;
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
            return result;
        }




    }

}
