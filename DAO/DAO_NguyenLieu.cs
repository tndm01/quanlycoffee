using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_NguyenLieu
    {
        SqlConnect con = new SqlConnect();
        SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// Hàm lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        public DataTable GetdataTable()
        {
            cmd.CommandText = "select MANL,TENNL,SOLUONG,DVT,NGAYNHAP from NGUYENLIEU";
            cmd.Connection = con.Connections;
            DataTable dt = new DataTable();
            try
            {
                con.OpenConn();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.CloseCoon();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        /// <summary>
        /// Hàm Thêm
        /// </summary>
        /// <param name="nlDTO"></param>
        /// <returns></returns>
        public bool AddData(DTO_NguyenLieu nlDTO)
        {
            cmd.CommandText = "INSERT INTO NGUYENLIEU ( MANL, TENNL, SOLUONG, DVT,NGAYNHAP) VALUES ('"+nlDTO.MaNL+"',N'"+nlDTO.TenNL+"','"+nlDTO.SoLuong+"','"+nlDTO.Dvt+"','"+nlDTO.NgayNhap+"')";
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
        /// Hàm sửa
        /// </summary>
        /// <param name="nlDTO"></param>
        /// <returns></returns>
        public bool Updata(DTO_NguyenLieu nlDTO)
        {
            cmd.CommandText = "UPDATE NGUYENLIEU SET TENNL = N'"+nlDTO.TenNL+"', SOLUONG ='"+nlDTO.SoLuong+"', DVT ='"+nlDTO.Dvt+"',NGAYNHAP = '"+nlDTO.NgayNhap+"' where MANL = '"+nlDTO.MaNL+"'";
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
        /// Hàm Xóa
        /// </summary>
        /// <param name="stt"></param>
        /// <returns></returns>
        public bool DeleteData(string stt)
        {
            cmd.CommandText = "DELETE from NGUYENLIEU where MANL = '"+stt+"'";
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
    }
}
