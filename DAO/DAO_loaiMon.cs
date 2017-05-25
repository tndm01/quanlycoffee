using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_loaiMon
    {
        SqlConnect con = new SqlConnect();
        SqlCommand cmd = new SqlCommand();
        DTO_loaiMon lmDTO = new DTO_loaiMon();

        public DataTable GetdataTable()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from LOAIMON";
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

        public bool AdddataTable(DTO_loaiMon lmDTO)
        {
            cmd.CommandText = "INSERT INTO LOAIMON(MALOAI, TENLOAI) VALUES ('"+lmDTO.MaLoai+"',N'"+lmDTO.TenLoai+"')";
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

        public bool UpdataTable(DTO_loaiMon lmDTO)
        {
            cmd.CommandText = "UPDATE LOAIMON SET TENLOAI =N'"+lmDTO.TenLoai+"'where MALOAI = '"+lmDTO.MaLoai+"'";
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

        public bool DeletedataTable(string maLoai)
        {
            cmd.CommandText = "DELETE from LOAIMON where MALOAI = '"+maLoai+"'";
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
