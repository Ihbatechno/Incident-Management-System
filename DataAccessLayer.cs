using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace IMS
{
    public class DataAccessLayer
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        DataSet ds = null;
        SqlDataAdapter da = null;
        public DataAccessLayer()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["websiteConnectionString"].ConnectionString);
        }
        public DataSet ExecuteDataSet(string sqlCommandText,CommandType ct)
        {
            da = new SqlDataAdapter(sqlCommandText, cn);
            da.SelectCommand.CommandType = ct;
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet ExecuteDataSet(string sqlCommandText, CommandType ct, SqlParameter p)
        {
            da = new SqlDataAdapter(sqlCommandText, cn);
            da.SelectCommand.CommandType = ct;
            da.SelectCommand.Parameters.Add(p);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int ExecuteNonQuery(string sqlCommandText,CommandType ct,SqlParameter p)
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmd = new SqlCommand(sqlCommandText, cn);
            cmd.CommandType = ct;
            cmd.Parameters.Add(p);
            int rowAffected = cmd.ExecuteNonQuery();
            cn.Close();
            return rowAffected;
        }
        public int ExecuteNonQuery(string sqlCommandText,CommandType ct,SqlParameter[] p)
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmd = new SqlCommand(sqlCommandText, cn);
            cmd.CommandType = ct;
            cmd.Parameters.AddRange(p);
            int rowAffected = cmd.ExecuteNonQuery();
            cn.Close();
            return rowAffected;
        }
    }
}