using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_NguyenLieu
    {
        DAO_NguyenLieu nlDAO = new DAO_NguyenLieu();

        public DataTable getDataTable()
        {
            return (nlDAO.GetdataTable());
        }

        /// <summary>
        /// Gọi lại hàm thêm
        /// </summary>
        /// <param name="nlDTO"></param>
        /// <returns></returns>
        public bool addData(DTO_NguyenLieu nlDTO)
        {
            return (nlDAO.AddData(nlDTO));
        }

        /// <summary>
        /// Gọi lại hàm sửa
        /// </summary>
        /// <param name="nlDTO"></param>
        /// <returns></returns>
        public bool upData(DTO_NguyenLieu nlDTO)
        {
            return (nlDAO.Updata(nlDTO));
        }

        /// <summary>
        /// Gọi lại hàm xóa
        /// </summary>
        /// <param name="stt"></param>
        /// <returns></returns>
        public bool deleteData(string stt)
        {
            return (nlDAO.DeleteData(stt));
        }
    }
}
