using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QL_Coffee
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmNhanVien());
            //Application.Run(new frmBan(""));
            //Application.Run(new frmKhuVuc());
            //Application.Run(new frmMaLoai());
            //Application.Run(new frmThucDon());
            //Application.Run(new frmChamCong());
            //Application.Run(new frmLuongNhanVien());
            //Application.Run(new frmThongKe());
            //Application.Run(new frmTonKho());
            //Application.Run(new frmNguyenLieu());
            //Application.Run(new frmMain());
            Application.Run(new frmHoaDon());
            //Application.Run(new frmLogin());
            //Application.Run(new frmReport());
            //Application.Run(new frmChangePassword());
        }
    }
}
