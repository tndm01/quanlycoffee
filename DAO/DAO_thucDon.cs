using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_thucDon
    {
        SqlConnect con = new SqlConnect();
        SqlCommand cmd = new SqlCommand();


        /// <summary>
        /// Hàm lấy dữ liệu từ DataBase
        /// </summary>
        /// <returns></returns>
        public DataTable GetdataTable()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from THUCDON";
            cmd.Connection = con.Connections;
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
        /// <param name="tdDTO"></param>
        /// <returns></returns>
        public bool AddData(DTO_thucDon tdDTO)
        {
            cmd.CommandText = "INSERT INTO THUCDON(MAMON, TENMON, DVT, DONGIA, MALOAI, SLN, SLT)VALUES ('"+tdDTO.MaLoai+"',N'"+tdDTO.TenMon+"',N'"+tdDTO.Dvt+"','"+tdDTO.DonGia+"','"+tdDTO.MaLoai+"','"+tdDTO.Sln+"','"+tdDTO.Slt+"')";
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
        /// Hàm Sửa
        /// </summary>
        /// <param name="tdDTO"></param>
        /// <returns></returns>
        public bool UpData(DTO_thucDon tdDTO)
        {
            cmd.CommandText = "UPDATE THUCDON SET TENMON =N'"+tdDTO.TenMon+"', DVT =N'"+tdDTO.Dvt+"', DONGIA ='"+tdDTO.DonGia+"', MALOAI ='"+tdDTO.MaLoai+"', SLN ='"+tdDTO.Sln+"', SLT ='"+tdDTO.Slt+"'where MAMON = '"+tdDTO.MaMon+"'";
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
        /// <param name="maMon"></param>
        /// <returns></returns>
        public bool DeleteData(string maMon)
        {
            cmd.CommandText = "DELETE from THUCDON where MAMON = '"+maMon+"'";
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
        /// Câu lệnh lấy thông tin từ CSDL
        /// </summary>
        /// <param name="dieuKien"></param>
        /// <returns></returns>
        public DataTable LayThongTin(string dieuKien)
        {
            return con.getDataTable("select MALOAI from LOAIMON");
        }


        /// <summary>
        /// Câu lệnh lấy thông tin từ CSDL
        /// </summary>
        /// <param name="dieuKien"></param>
        /// <returns></returns>
        public DataTable LayDuLieu(string dieuKien)
        {
            return con.getDataTable("select TENMON, MAMON, DONGIA, DVT FROM THUCDON");
        }


        /// <summary>
        /// Lấy mã món trong table THUCDON
        /// </summary>
        /// <param name="dieuKien"></param>
        /// <returns></returns>
        public DataTable LayMaMon(string dieuKien)
        {
            return con.getDataTable("select MAMON from THUCDON");
        }


        /// <summary>
        /// Lấy mã bàn trong table PHIEU
        /// </summary>
        /// <param name="dieuKien"></param>
        /// <returns></returns>
        public DataTable LayMaBan(string dieuKien)
        {
            return con.getDataTable("select MABAN from BAN");
        }
    }
}
