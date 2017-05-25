using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_chitietPhieu
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
            cmd.CommandText = "select * from CHITIETPHIEU";
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
        /// Hàm thêm dữ liệu
        /// </summary>
        /// <param name="ctpDTO"></param>
        /// <returns></returns>
        public bool AddData(DTO_chitietPhieu ctpDTO)
        {
            cmd.CommandText = "INSERT INTO CHITIETPHIEU(MAPHIEU, MAMON, GIAMGIA, SOLUONG, TIEN) VALUES ('"+ctpDTO.MaPhieu+"','"+ctpDTO.MaMon+"','"+0+"','"+0+"','"+0+"')";
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
        /// Hàm Sữa dữ liệu
        /// </summary>
        /// <param name="ctpDTO"></param>
        /// <returns></returns>
        public bool UpdateData(DTO_chitietPhieu ctpDTO)
        {
            cmd.CommandText = "UPDATE CHITIETPHIEU SET  MAMON ='"+ctpDTO.MaMon+"', GIAMGIA ='"+0+"', SOLUONG ='"+0+"', TIEN ='"+0+"'where MACTP = '"+ctpDTO.MaCTP+"'";
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
        /// <param name="MaCTP"></param>
        /// <returns></returns>
        public bool Delete(string MaCTP)
        {
            cmd.CommandText = "DELETE from CHITIETPHIEU where MACTP = '"+MaCTP+"'";
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
