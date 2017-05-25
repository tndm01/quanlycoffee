using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_ban
    {
        DAO_ban bDAO = new DAO_ban();

        public DataTable getDataTable()
        {
            return bDAO.GetDataTable();
        }

        public bool addData(DTO_ban bDTO)
        {
            return bDAO.AddData(bDTO);
        }

        public bool upData(DTO_ban bDTO)
        {
            return bDAO.Updata(bDTO);
        }

        public bool deleteData(string maBan)
        {
            return bDAO.DeleteData(maBan);
        }

        public DataTable LayThongTin(string dieukien)
        {
            return bDAO.LayThongTin(dieukien);
        }
    }
}
