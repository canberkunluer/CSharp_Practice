using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using ToDosAPI.Models;

namespace ToDosAPI.Database
{
    public class ToDoListDAL
    {
        string sql = string.Empty;
        SqlConnection conn = new SqlConnection(Database.GetCOnnectionString);
        SqlCommand cmd;
        bool result;
        List<ToDoList> sqllist = new List<ToDoList>();

        public List<ToDoList> GetSql()
        {
            sql = "SELECT * FROM ToDoList ";
            List<ToDoList> _sqltodolist = new List<ToDoList>();
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _sqltodolist.Add(new ToDoList((int)dr["id"], dr[1].ToString(), Convert.ToBoolean(dr[2])));
            }
            conn.Close();
            return _sqltodolist;

        }
        public List<ToDoList> GetSql(int id)
        {
            sql = "SELECT * FROM ToDoList WHERE  id = " + id;
            List<ToDoList> _sqltodolist = new List<ToDoList>();
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _sqltodolist.Add(new ToDoList((int)dr["id"], dr[1].ToString(), Convert.ToBoolean(dr[2])));
            }
            conn.Close();
            sqllist = _sqltodolist;
            return _sqltodolist;
        }
        public void Add( int id,string todo, bool status)
        { 
            sql = "INSERT INTO ToDoList(id,todo, status) values(@id,@todo, @status)";
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@todo", todo);
                    cmd.Parameters.AddWithValue("@status", status);
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
        }
        public bool Update(int id, string todo, bool status)
        {
            sql = "UPDATE  ToDoList SET todo =@todo,status = @status   WHERE id = " + id;
            cmd = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@todo", todo);
                    cmd.Parameters.AddWithValue("@status", status);

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
            sql = "DELETE FROM ToDoList WHERE id = " + id;
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





    }


    }

