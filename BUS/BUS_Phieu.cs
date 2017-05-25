using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class BUS_Phieu
    {
        DAO_Phieu pDAO = new DAO_Phieu();

        /// <summary>
        /// Gọi lại hàm lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        public DataTable getData()
        {
            return pDAO.GetData();
        }

        /// <summary>
        /// Gọi lại hàm thêm dữ liệu
        /// </summary>
        /// <param name="pDTO"></param>
        /// <returns></returns>
        public bool addData(DTO_Phieu pDTO)
        {
            return pDAO.AddData(pDTO);
        }

        /// <summary>
        /// Gọi lại hàm sữa dữ liệu
        /// </summary>
        /// <param name="pDTO"></param>
        /// <returns></returns>
        public bool updateData(DTO_Phieu pDTO)
        {
            return pDAO.UpdateData(pDTO);
        }

        /// <summary>
        /// Gọi lại hàm xóa dữ liệu
        /// </summary>
        /// <param name="maPhieu"></param>
        /// <returns></returns>
        public bool deleteData(string maPhieu)
        {
            return pDAO.DeleteData(maPhieu);
        }
    }
}
