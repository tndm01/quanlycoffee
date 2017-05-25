using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_Phieu
    {
        SqlConnect con = new SqlConnect();
        SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// Hàm lấy dữ liệu từ DB
        /// </summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from Phieu";
            cmd.Connection = con.Connections;
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
        /// <param name="pDTO"></param>
        /// <returns></returns>
        public bool AddData(DTO_Phieu pDTO)
        {
            cmd.CommandText = "INSERT INTO PHIEU (MABAN, TONGTIEN) VALUES ('"+pDTO.MaBan+"','"+0+"')";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseCoon();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Hàm sữa dữ liệu
        /// </summary>
        /// <param name="pDTO"></param>
        /// <returns></returns>
        public bool UpdateData(DTO_Phieu pDTO)
        {
            cmd.CommandText = "UPDATE PHIEU SET MABAN = '"+pDTO.MaBan+"', TONGTIEN ='"+pDTO.TongTien+"' where MAPHIEU = '"+pDTO.MaPhieu+"'";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseCoon();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Hàm xóa dữ liệu
        /// </summary>
        /// <param name="maPhieu"></param>
        /// <returns></returns>
        public bool DeleteData(string maPhieu)
        {
            cmd.CommandText = "DELETE FROM PHIEU where MAPHIEU = '"+maPhieu+"'";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseCoon();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
