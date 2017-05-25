using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;


namespace DAO
{
    public class DAO_chamCong
    {
        SqlConnect con = new SqlConnect();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetdataTable()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT STT,TENNV, NGAY, SOCA FROM NHANVIEN NV,CHAMCONG CC WHERE NV.MANV = CC.MANV";
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

        public bool AddData(DTO_chamCong ccDTO)
        {
            cmd.CommandText = "INSERT INTO CHAMCONG(MANV,NGAY)VALUES     (N'"+ccDTO.MaNV+"','"+ccDTO.NgayLam+"')";
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

        public bool Updata(DTO_chamCong ccDTO)
        {
            cmd.CommandText = "UPDATE    CHAMCONG SET SOCA ='"+ccDTO.SoCa+"'where STT = '"+ccDTO.Stt+"'";
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

        public bool Deletedata(string sTT)
        {
            cmd.CommandText = "DELETE from CHAMCONG where STT = '" + sTT + "'";
            cmd.Connection = con.Connections;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseCoon();
            }
            catch
            { }
            return true;
        }

        public DataTable LayThongTin(string dieuKien)
        {
            return con.getDataTable("select TENNV from NHANVIEN ");
        }

        public DataTable LaySTT(string dieuKien)
        {
            return con.getDataTable("select * from CHAMCONG ");
        }
    }
}
