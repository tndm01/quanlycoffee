using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_loaiMon
    {
        DAO_loaiMon lmDAO = new DAO_loaiMon();

        public DataTable getdataTable()
        {
            return (lmDAO.GetdataTable());
        }

        public bool adddataTable(DTO_loaiMon lmDTO)
        {
            return (lmDAO.AdddataTable(lmDTO));
        }

        public bool upData(DTO_loaiMon lmDTO)
        {
            return (lmDAO.UpdataTable(lmDTO));
        }

        public bool deleteData(string maLoai)
        {
            return (lmDAO.DeletedataTable(maLoai));
        }
    }
}
