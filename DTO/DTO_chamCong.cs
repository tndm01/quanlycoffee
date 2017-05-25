using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class DTO_chamCong
    {
        #region
        private string maNV;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        private string stt;

        public string Stt
        {
            get { return stt; }
            set { stt = value; }
        }
        private string tenNV;

        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }
        private string ngayLam;

        public string NgayLam
        {
            get { return ngayLam; }
            set { ngayLam = value; }
        }
        private string soCa;

        public string SoCa
        {
            get { return soCa; }
            set { soCa = value; }
        }
        #endregion
    }
}
