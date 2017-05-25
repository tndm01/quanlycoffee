using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class DTO_Phieu
    {
        #region
        private string maPhieu;

        public string MaPhieu
        {
            get { return maPhieu; }
            set { maPhieu = value; }
        }

        private string maBan;

        public string MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }

        private string tongTien;

        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        #endregion
    }
}
