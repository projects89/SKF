using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SKF
{
    public class Connect
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlTransaction tran;
        DataSet ds = new DataSet();

        public void Insert(string sqlstmt)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                tran = con.BeginTransaction();
                cmd = new MySqlCommand(sqlstmt, con, tran);
                cmd.ExecuteNonQuery();
                tran.Commit();

                con.Close();
            }
            catch (MySqlException Sqlex)
            {
                tran.Rollback();
                throw Sqlex;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }
        public void Update(string sqlstmt)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                tran = con.BeginTransaction();
                cmd = new MySqlCommand(sqlstmt, con, tran);
                cmd.ExecuteNonQuery();
                tran.Commit();

                con.Close();
            }
            catch (MySqlException Sqlex)
            {
                tran.Rollback();
                throw Sqlex;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }
        public void Delete(string sqlstmt)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                tran = con.BeginTransaction();
                cmd = new MySqlCommand(sqlstmt, con, tran);
                cmd.ExecuteNonQuery();
                tran.Commit();

                con.Close();
            }
            catch (MySqlException Sqlex)
            {
                tran.Rollback();
                throw Sqlex;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }
        public DataSet Select(string sqlstmt)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                da = new MySqlDataAdapter(sqlstmt, con);
                ds = new DataSet();
                da.Fill(ds);

                con.Close();
            }
            catch (MySqlException Sqlex)
            {
                throw Sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public string ChangeFormat(string str)
        {
            string[] strDt = str.Split('/');
            string s1 = "", s2 = "", s3 = "";
            string result = "";

            s1 = strDt[0];
            s2 = strDt[1];
            s3 = strDt[2];

            result = s2 + "/" + s1 + "/" + s3;
            return result;
        }
    }

}