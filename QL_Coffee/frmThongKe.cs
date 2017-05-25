using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using DTO;
using BUS;
using System.Globalization;

namespace QL_Coffee
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        SqlConnect con = new SqlConnect();

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                //Get id Maphieu
                string maPhieu = con.getDataTable("select COUNT(*) from PHIEU").Rows[0][0].ToString();
                //GET id MACTP
                string maCTP = con.getDataTable("select COUNT(*) from CHITIETPHIEU").Rows[0][0].ToString();
                int n = Convert.ToInt32(maCTP);
                if (n == 0)
                {
                    MessageBox.Show("Dữ Liệu Không Hợp Lệ!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    //string maCTP = con.getDataTable("select COUNT(MACTP) from CHITIETPHIEU").Rows[0][0].ToString();
                    //Lấy ngày tháng để tính toán
                    TimeSpan diff = DateTime.Parse(dtpDenNgay.Value.ToString()) - DateTime.Parse(dtpTuNgay.Value.ToString());
                    //Lấy ngày bán được (Số lượng * Ngày tháng)
                    int layNgay = Convert.ToInt32(diff.TotalDays);
                    if (DateTime.Parse(dtpDenNgay.Value.ToString()) < DateTime.Parse(dtpTuNgay.Value.ToString()))
                    {
                        MessageBox.Show("Yêu Cầu Nhập Ngày Hợp Lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT CT.MAPHIEU, P.MABAN, SUM(TIEN * " + layNgay + ")/ '" + maPhieu + "' AS TONGTIEN  ");
                    sb.Append("from CHITIETPHIEU CT, PHIEU P ");
                    sb.Append("GROUP BY CT.MAPHIEU, MABAN");
                    dgvThongKe.DataSource = con.getDataTable(sb.ToString());
                    lblDoanhThu.Text = con.getDataTable("Select sum(TIEN) * " + layNgay + " as TONGTIEN from CHITIETPHIEU").Rows[0][0].ToString().Trim();
                    lblDoanhThu.Text = (lblDoanhThu.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("id-ID"), "{0:#,##0}", double.Parse(lblDoanhThu.Text)));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
