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

namespace QL_Coffee
{
    public partial class frmLuongNhanVien : Form
    {
        public frmLuongNhanVien()
        {
            InitializeComponent();
        }

        public static string MaNV;

        SqlConnect con = new SqlConnect();
        DTO_chamCong ccDTO = new DTO_chamCong();
        DAO_chamCong ccDAO = new DAO_chamCong();
        BUS_chamCong ccBUS = new BUS_chamCong();
        int dong = 0;

        DataTable dt = new DataTable();

        private void frmLuongNhanVien_Load(object sender, EventArgs e)
        {
            dgvLuong.DataSource = con.getDataTable("select MANV ,NGAY, SOCA from CHAMCONG where MANV = '" + MaNV + "'");
            loadTenNV();
        }

        void loadTenNV()
        {
            cboTenNV.DataSource = ccBUS.getdataTable();
            cboTenNV.ValueMember = "TENNV";
            cboTenNV.DisplayMember = "MANV";
        }

        void ganDuLieu(DTO_chamCong ccDTO)
        {
            ccDTO.TenNV = cboTenNV.Text.Trim();
            ccDTO.NgayLam = dtpTuNgay.Text.Trim();
        }

        private void dgvLuongNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (dgvLuong.Rows.Count > 0)
            {
                try
                {
                    //Lấy Mã Nhân Viên
                    string MaNV = con.getDataTable("select MANV from NHANVIEN where TENNV = N'" + cboTenNV.Text.Trim() + "'").Rows[0][0].ToString().Trim();
                    //Lấy Tiền Lương Nhân Viên
                    float tienLuong = Convert.ToInt32(con.getDataTable("SELECT LUONGCOBAN FROM NHANVIEN WHERE MANV = '" + MaNV + "'").Rows[0][0].ToString().Trim());
                    //Cập Nhật lại số ngày vừa mới tính
                    con.getDataTable("update CHAMCONG  set NGAY ='" + String.Format(dtpDenNgay.Text.ToString()) + "'where MANV = '" + MaNV + "'");
                    //Lấy Số Ca Nhân Viên
                    int soCa = Convert.ToInt32(con.getDataTable("SELECT SOCA FROM CHAMCONG WHERE MANV = '" + MaNV + "'").Rows[0][0].ToString().Trim());
                    //Lấy Số Ngày
                    TimeSpan diff = DateTime.Parse(dtpDenNgay.Value.ToString()) - DateTime.Parse(dtpTuNgay.Value.ToString());
                    if (diff.TotalDays < 0)
                    {
                        MessageBox.Show("Ngày Tháng Không Hợp Lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Lấy Số Ca Nhân Viên Làm Được
                    int tinhLuong = Convert.ToInt32(diff.TotalDays) * Convert.ToInt32(soCa);
                    //Tính Tiền Nhân Viên Làm Được
                    lblTongTien.Text = (tienLuong * tinhLuong).ToString();
                    lblTongTien.Text = (lblTongTien.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("id-ID"), "{0:#,##0}", double.Parse(lblTongTien.Text)));
                    //Load dữ liệu lên dataGridView
                    dgvLuong.DataSource = con.getDataTable("select MANV ,NGAY,SOCA from CHAMCONG where MANV = '" + MaNV + "'");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
