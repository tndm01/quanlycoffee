using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class SqlConnect
    {
        #region Availible
        private SqlConnection Conn;

        public SqlConnection Connections
        {
            get
            {
                return Conn;
            }
        }
        private SqlCommand _cmd;

        public SqlCommand Cmd
        {
            get { return _cmd; }
            set { _cmd = value; }
        }
        #endregion

        #region Contructor()
        public SqlConnect()
        {
            string strconn = @"Data Source=THANHNHAN-PC\THANHNHAN;Initial Catalog=QL_CAFE;Integrated Security=True";
            Conn = new SqlConnection(strconn);
        }
        #endregion

        #region
        public bool OpenConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region
        public bool CloseCoon()
        {
            try 
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void ThucThiCauLenh(string strSql)
        {
            try
            {
                OpenConn();
                SqlCommand cmd = new SqlCommand(strSql, Conn);
                cmd.ExecuteNonQuery();
                CloseCoon();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getDataTable(string strSql)
        {
            try
            {
                OpenConn();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(strSql,Conn);
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
