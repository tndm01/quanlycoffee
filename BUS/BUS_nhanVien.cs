using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_nhanVien
    {
        DAO_nhanVien nvDAO = new DAO_nhanVien();
        public DataTable getDataTable()
        {
            return nvDAO.GetDataTable();
        }

        public bool addData(DTO_nhanVien nvDTO)
        {
            return nvDAO.AddData(nvDTO);
        }

        public bool upData(DTO_nhanVien nvDTO)
        {
            return nvDAO.UpData(nvDTO);
        }

        public bool deleteData(string maNV)
        {
            return nvDAO.DeleteData(maNV);
        }
    }
}
