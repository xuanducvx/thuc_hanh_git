using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApiNetWay_v1.Adapter
{
    public class NWSQL
    {
       
        public static DataSet _GetDataSetQuery(string strQuery, string connectionString)
        {
           
            try
            {
                System.Data.SqlClient.SqlDataAdapter adt = new System.Data.SqlClient.SqlDataAdapter();
                System.Data.DataSet dts = new System.Data.DataSet();
                SqlConnection Conn = new SqlConnection(connectionString);
                
                Conn.Open();
                SqlCommand Comm = new System.Data.SqlClient.SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = "SET DATEFORMAT DMY;\r\n" + strQuery;
                Comm.Connection = Conn;
                adt.SelectCommand = Comm;
                adt.Fill(dts);
                adt.Dispose();
                Conn.Close();
                return dts;
            }
            catch
            {

            }
            return null;
        }

        //public bool _ExecuteQuery(string strQuery)
        //{
        //    try
        //    {
        //        SqlConnection Conn = new SqlConnection(_connectionString);
        //        SqlCommand Comm = new System.Data.SqlClient.SqlCommand();
        //        Conn.Open();
        //        Comm.Connection = Conn;

        //        Comm.CommandText = "SET DATEFORMAT DMY;\r\n" + strQuery;
        //        Comm.Connection = Conn;

        //        int result;
        //        result = Comm.ExecuteNonQuery();
        //        Conn.Close();
        //        return true;
        //    }
        //    catch { }
        //    return false;
        //}

        //public static SqlDataReader _DataReader(string sQuery, SqlConnection objConn)
        //{
        //    try
        //    {
        //        Int32 nTimeOut = 600;

        //        if (objConn.State != ConnectionState.Open)
        //            return null;
        //        SqlCommand cmd = new SqlCommand("SET DATEFORMAT DMY;\r\n" + sQuery, objConn);
        //        cmd.CommandTimeout = nTimeOut;
        //        return cmd.ExecuteReader();
        //    }
        //    catch
        //    {
        //        objConn.Close();
        //        return null;
        //    }
        //}

        public static void _Disconnect(SqlConnection objConn)
        {
            try
            {
                objConn.Close();
                objConn.Dispose();
            }
            catch
            {
            }
        }
    }
}
