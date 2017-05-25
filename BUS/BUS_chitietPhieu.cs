using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_chitietPhieu
    {
        DAO_chitietPhieu ctpDAO = new DAO_chitietPhieu();

        /// <summary>
        /// Gọi lại hàm lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        public DataTable getData()
        {
            return ctpDAO.GetData();
        }

        /// <summary>
        /// Gọi lại hàm thêm dữ liệu
        /// </summary>
        /// <param name="ctpDTO"></param>
        /// <returns></returns>
        public bool addData(DTO_chitietPhieu ctpDTO)
        {
            return ctpDAO.AddData(ctpDTO);
        }

        /// <summary>
        /// Gọi lại hàm sữa dữ liệu
        /// </summary>
        /// <param name="ctpDTO"></param>
        /// <returns></returns>
        public bool upDateData(DTO_chitietPhieu ctpDTO)
        {
            return ctpDAO.UpdateData(ctpDTO);
        }

        /// <summary>
        /// Gọi lại hàm xóa dữ liệu
        /// </summary>
        /// <param name="maCTP"></param>
        /// <returns></returns>
        public bool delete(string maCTP)
        {
            return ctpDAO.Delete(maCTP);
        }
    }
}
