using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_ban
    {
        SqlConnect con = new SqlConnect();
        SqlCommand cmd = new SqlCommand();
        DTO_ban bDTO = new DTO_ban();

        public DataTable GetDataTable()
        {
            cmd.CommandText = "select * from BAN";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.CloseCoon();
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Hàm Thêm
        /// </summary>
        /// <param name="bDTO"></param>
        /// <returns></returns>
        public bool AddData(DTO_ban bDTO)
        {
            cmd.CommandText = "INSERT INTO BAN(MABAN, TENBAN, SONGUOI, MAKV)VALUES ('"+bDTO.MaBan+"',N'"+bDTO.TenBan+"','"+bDTO.SoNguoi+"','"+bDTO.MaKV+"')";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseCoon();
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
        /// <param name="bDTO"></param>
        /// <returns></returns>
        public bool Updata(DTO_ban bDTO)
        {
            cmd.CommandText = "UPDATE BAN SET TENBAN =N'"+bDTO.TenBan+"', SONGUOI ='"+bDTO.SoNguoi+"', MAKV ='"+bDTO.MaKV+"' where MABAN = '"+bDTO.MaBan+"'";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseCoon();
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
        /// <param name="maBan"></param>
        /// <returns></returns>
        public bool DeleteData(string maBan)
        {
            cmd.CommandText = "DELETE from BAN where MABAN = '"+maBan+"'";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseCoon();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayThongTin(string dieuKien)
        {
            return con.getDataTable("select TENKV from KHUVUC");
        }
    }
}
