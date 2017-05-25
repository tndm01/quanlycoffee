using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_thucDon
    {
        DAO_thucDon tdDAO = new DAO_thucDon();

        /// <summary>
        /// Gọi lại hàm lấy dữ liều từ Database
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable()
        {
            return (tdDAO.GetdataTable());
        }


        /// <summary>
        /// Gọi lại hàm thêm
        /// </summary>
        /// <param name="tdDTO"></param>
        /// <returns></returns>
        public bool addData(DTO_thucDon tdDTO)
        {
            return (tdDAO.AddData(tdDTO));
        }


        /// <summary>
        /// Gọi lại hàm sửa
        /// </summary>
        /// <param name="tdDTO"></param>
        /// <returns></returns>
        public bool upData(DTO_thucDon tdDTO)
        {
            return (tdDAO.UpData(tdDTO));
        }


        /// <summary>
        /// Gọi lại hàm xóa
        /// </summary>
        /// <param name="maMon"></param>
        /// <returns></returns>
        public bool deleteData(string maMon)
        {
            return (tdDAO.DeleteData(maMon));
        }

        /// <summary>
        /// Gọi hàm lấy thông tin từ Database
        /// </summary>
        /// <param name="dieuKien"></param>
        /// <returns></returns>
        public DataTable laythongTin(string dieuKien)
        {
            return (tdDAO.LayThongTin(dieuKien));
        }

        /// <summary>
        /// Gọi lại hàm lấy dữ liệu từ Database
        /// </summary>
        /// <param name="dieuKien"></param>
        /// <returns></returns>
        public DataTable layDuLieu(string dieuKien)
        {
            return (tdDAO.LayDuLieu(dieuKien));
        }

        /// <summary>
        /// Gọi lại hàm lấy mã món từ DataBase
        /// </summary>
        /// <param name="dieuKien"></param>
        /// <returns></returns>
        public DataTable layMaMon(string dieuKien)
        {
            return (tdDAO.LayMaMon(dieuKien));
        }

        /// <summary>
        /// Gọi lại hàm lấy mã phiếu từ Database
        /// </summary>
        /// <param name="dieuKien"></param>
        /// <returns></returns>
        public DataTable layMaBan(string dieuKien)
        {
            return (tdDAO.LayMaBan(dieuKien));
        }
    }
}
