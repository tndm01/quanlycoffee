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
    public partial class frmTonKho : Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }

        BUS_thucDon tdBUS = new BUS_thucDon();
        SqlConnect con = new SqlConnect();
        

        private void btnTinhHang_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy số lượng tồn
                int soLuongTon = Convert.ToInt32(txtTonKho.Text.ToString().Trim());
                //Lấy số lượng tồn
                int soLuongDaBan = Convert.ToInt32(txtDaBan.Text.ToString().Trim());
                //Tính số lượng tồn
                float tinhSoLuong = Convert.ToInt32(txtTonKho.Text) - Convert.ToInt32(txtDaBan.Text);
                //Ràng buộc số lượng tồn
                if (soLuongTon < soLuongDaBan)
                {
                    MessageBox.Show("Dữ Liệu Không Hợp Lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Hiện số lượng tồn còn lại
                txtConLai.Text = (tinhSoLuong).ToString();
                //load dữ liệu lên DataGirdView
                dgvTonKho.DataSource = con.getDataTable("SELECT TENMON, DONGIA, DVT, SLN, SLT FROM THUCDON");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void loadTenMon()
        {
            cboTenMon.DataSource = tdBUS.getDataTable();
            cboTenMon.ValueMember = "MAMON";
            cboTenMon.DisplayMember = "TENMON";
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            loadTenMon();
        }
    }
}
