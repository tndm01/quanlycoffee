using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class DTO_ban
    {
        #region Properties
        private string maBan;

        public string MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }
        private string tenBan;

        public string TenBan
        {
            get { return tenBan; }
            set { tenBan = value; }
        }
        private string soNguoi;

        public string SoNguoi
        {
            get { return soNguoi; }
            set { soNguoi = value; }
        }
        private string maKV;

        public string MaKV
        {
            get { return maKV; }
            set { maKV = value; }
        }
        #endregion
    }
}
