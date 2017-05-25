using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_khuVuc
    {
        DTO_khuVuc kvDTO = new DTO_khuVuc();
        SqlCommand cmd = new SqlCommand();
        SqlConnect con = new SqlConnect();

        public DataTable Getdatatable()
        {
            cmd.CommandText = "select * from KHUVUC";
            cmd.Connection = con.Connections;
            DataTable dt = new DataTable();
            try
            {
                con.OpenConn();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.CloseCoon();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        /// <summary>
        /// Hàm Thêm Dữ Liệu
        /// </summary>
        /// <param name="kvDTO"></param>
        /// <returns></returns>
        public bool Adddata(DTO_khuVuc kvDTO)
        {
            cmd.CommandText = "INSERT INTO KHUVUC(MAKV, TENKV)VALUES ('"+kvDTO.MaKV+"',N'"+kvDTO.TenKV+"')";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Hàm Sửa 
        /// </summary>
        /// <param name="kvDTO"></param>
        /// <returns></returns>
        public bool Updata(DTO_khuVuc kvDTO)
        {
            cmd.CommandText = "UPDATE KHUVUC SET TENKV =N'"+kvDTO.TenKV+"'where MAKV='"+kvDTO.MaKV+"'";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Hàm Xóa
        /// </summary>
        /// <param name="maKV"></param>
        /// <returns></returns>
        public bool Deletedata(string maKV)
        {
            cmd.CommandText = "DELETE from KHUVUC where MAKV ='"+maKV+"'";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
