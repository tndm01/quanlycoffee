using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class DTO_NguyenLieu
    {

        private string maNL;

        public string MaNL
        {
            get { return maNL; }
            set { maNL = value; }
        }

        private string tenNL;

        public string TenNL
        {
            get { return tenNL; }
            set { tenNL = value; }
        }

        private string soLuong;

        public string SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        private string dvt;

        public string Dvt
        {
            get { return dvt; }
            set { dvt = value; }
        }

        private string ngayNhap;

        public string NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
    }
}
