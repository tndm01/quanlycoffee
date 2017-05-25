using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_chamCong
    {
        DAO_chamCong ccDAO = new DAO_chamCong();

        public DataTable getdataTable()
        {
            return (ccDAO.GetdataTable());
        }

        public bool addData(DTO_chamCong ccDTO)
        {
            return (ccDAO.AddData(ccDTO));
        }

        public bool upData(DTO_chamCong ccDTO)
        {
            return (ccDAO.Updata(ccDTO));
        }

        public bool deleteData(string sTT)
        {
            return (ccDAO.Deletedata(sTT));
        }

        public DataTable layThongTin(string dieuKien)
        {
            return (ccDAO.LayThongTin(dieuKien));
        }

        public DataTable laySTT(string dieuKien)
        {
            return (ccDAO.LaySTT(dieuKien));
        }
    }
}
