using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_nhanVien
    {
        SqlConnect con = new SqlConnect();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select MANV,TENNV,DIACHI,STD,GIOITINH,NGAYSINH,LUONGCOBAN  from NHANVIEN";
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

        public bool AddData(DTO_nhanVien nvDTO)
        {
            cmd.CommandText = "INSERT INTO NHANVIEN(MANV, TENNV, DIACHI, STD, GIOITINH, NGAYSINH, LUONGCOBAN) VALUES('"+nvDTO.MaNV+"',N'"+nvDTO.TenNV+"',N'"+nvDTO.DiaChi+"','"+nvDTO.Sdt+"',N'"+nvDTO.GioiTinh+"','"+nvDTO.NgaySinh+"','"+nvDTO.LuongCoBan+"')";
            cmd.Connection = con.Connections;
            //cmd.CommandText = CommandType.Text;
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

        public bool UpData(DTO_nhanVien nvDTO)
        {
            cmd.CommandText = "UPDATE  NHANVIEN SET TENNV =N'"+nvDTO.TenNV+"', DIACHI =N'"+nvDTO.DiaChi+"', STD =N'"+nvDTO.Sdt+"', GIOITINH =N'"+nvDTO.GioiTinh+"', NGAYSINH ='"+nvDTO.NgaySinh+"', LUONGCOBAN ='"+nvDTO.LuongCoBan+"' where MANV ='"+nvDTO.MaNV+"'";
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

        public bool DeleteData(string maNV)
        {
            cmd.CommandText = "DELETE FROM NHANVIEN where MANV = '"+maNV+"'";
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
