using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_khuVuc
    {
        DAO_khuVuc kvDAO = new DAO_khuVuc();

        public DataTable getdataTable()
        {
            return (kvDAO.Getdatatable());
        }

        public bool addData(DTO_khuVuc kvDTO)
        {
            return (kvDAO.Adddata(kvDTO));
        }

        public bool upData(DTO_khuVuc kvDTO)
        {
            return (kvDAO.Updata(kvDTO));
        }

        public bool deleteData(string maKV)
        {
            return (kvDAO.Deletedata(maKV));
        }
    }
}
