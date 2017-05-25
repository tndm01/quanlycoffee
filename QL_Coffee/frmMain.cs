using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using DAO;
using BUS;
using System.Data.SqlClient;

namespace QL_Coffee
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        SqlConnect con = new SqlConnect();
        DataTable dt_ThucDon = new DataTable();
        BUS_thucDon tdBUS = new BUS_thucDon();
        DTO_Phieu pDTO = new DTO_Phieu();
        DAO_Phieu pDAO = new DAO_Phieu();
        BUS_Phieu pBUS = new BUS_Phieu();

        private void frmMain_Load(object sender, EventArgs e)
        {
            dt_ThucDon = tdBUS.layDuLieu("");
            dgvThucDon.DataSource = dt_ThucDon;
            loadMaMon();
            bingding();
        }

        void bingding()
        {
            cboMaMon.DataBindings.Clear();
            cboMaMon.DataBindings.Add("Text", dgvThucDon.DataSource, "MAMON");
        }

        void bingDing()
        {
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dgvTenMon.DataSource, "SOLUONG");
        }

        void loadMaMon()
        {
            cboMaMon.DataSource = tdBUS.layMaMon("");
            cboMaMon.ValueMember = "MAMON";
            cboMaMon.DisplayMember = "TENMON";
        }

        void clearform()
        {
            txtTongTien.Text = "";
            txtSoLuong.Text = "";
            txtMaPhieu.Text = "";
        }

        void ganDulieuPhieu(DTO_Phieu pDTO)
        {
            
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            try
            {
                int columnIndex = dgvTenMon.CurrentCell.ColumnIndex;
                int maCT = dgvTenMon.CurrentCell.RowIndex;

                string maPhieu = con.getDataTable("select COUNT (MAPHIEU) from PHIEU ").Rows[0][0].ToString();
                string maCTP = con.getDataTable("select COUNT (MACTP) from CHITIETPHIEU").Rows[0][0].ToString().Trim();
                string MaMon = con.getDataTable("select MAMON from THUCDON where MAMON = '" + cboMaMon.Text.Trim() + "'").Rows[0][0].ToString().Trim();
                //Lấy đơn giá
                float tien = Convert.ToInt32(con.getDataTable("SELECT DONGIA FROM THUCDON WHERE MAMON = '" + MaMon + "'").Rows[0][0].ToString()) * Convert.ToInt32(txtSoLuong.Text.Trim());
                //Update lại số lượng
                con.getDataTable("update CHITIETPHIEU SET SOLUONG = '" + Convert.ToInt32(txtSoLuong.Text.ToString().Trim()) + "',tien = '" + tien + "'where MACTP = '" + maCT + "'");
                //Số lượng
                int soLuong = Convert.ToInt32(con.getDataTable("SELECT soluong FROM CHITIETPHIEU WHERE MAMON = '" + MaMon + "'").Rows[0][0].ToString());
                //Load dữ liệu lên DataGridView
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("select TENMON,DONGIA,SOLUONG,DVT,GIAMGIA ");
                sb1.Append("from CHITIETPHIEU CT");
                sb1.Append(" LEFT JOIN THUCDON TD ON CT.MAMON = TD.MAMON ");
                sb1.Append("WHERE CT.MAPHIEU = '" + txtMaPhieu.Text.Trim() + "' ");
                dgvTenMon.DataSource = con.getDataTable(sb1.ToString());
                txtTongTien.Text = con.getDataTable("select SUM(tien) AS TONGTIEN FROM CHITIETPHIEU where MAPHIEU = '" + maPhieu + "' ").Rows[0][0].ToString().Trim();
                btnBan1.Image = ((System.Drawing.Image)(Properties.Resources.Actions_user_group_delete_icon));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn Có Muốn Xóa Không??", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //Lấy số lượng phiếu
                    string maPhieu = con.getDataTable("select COUNT(MAPHIEU) FROM PHIEU").Rows[0][0].ToString();
                    //Lấy số lượng chi tiết phiếu
                    string maCTP = con.getDataTable("select COUNT(MACTP) FROM CHITIETPHIEU").Rows[0][0].ToString();
                    //string maCTP = con.getDataTable("SELECT MACTP FROM CHITIETPHIEU WHERE MAMON = '" + cboMaMon.Text.Trim() + "'").Rows[0][0].ToString();
                    //Lấy mã Chi tiết phiếu
                    if (txtMaPhieu.Text.Trim() != maCTP)
                    {
                        var sB = new StringBuilder();
                        sB.Append("delete from CHITIETPHIEU where MACTP = '" + maCTP.Trim() + "'");
                        con.getDataTable(sB.ToString());
                        txtTongTien.Text = con.getDataTable("select SUM(tien) AS TONGTIEN FROM CHITIETPHIEU where MAPHIEU = '" + maPhieu + "' ").Rows[0][0].ToString().Trim();
                    }
                    else
                    {
                        //Delete MaCTP
                        var sB = new StringBuilder();
                        sB.Append("delete from CHITIETPHIEU where MACTP = '" + maCTP.Trim() + "'");
                        con.getDataTable(sB.ToString());

                        //Delete MaPhieu
                        var sB1 = new StringBuilder();
                        sB1.Append("delete from PHIEU where MAPHIEU = '" + maPhieu + "'");
                        con.getDataTable(sB1.ToString());
                        clearform();
                        txtTongTien.Text = con.getDataTable("select SUM(tien) AS TONGTIEN FROM CHITIETPHIEU where MAPHIEU = '" + maPhieu + "' ").Rows[0][0].ToString().Trim();
                    }
                    
                    //Load dữ liệu lên DataGridView
                    StringBuilder sb1 = new StringBuilder();
                    sb1.Append("select TENMON,DONGIA,SOLUONG,DVT,GIAMGIA ");
                    sb1.Append("from CHITIETPHIEU CT");
                    sb1.Append(" LEFT JOIN THUCDON TD ON CT.MAMON = TD.MAMON ");
                    sb1.Append("WHERE CT.MAPHIEU = '" + txtMaPhieu.Text.Trim() + "' ");
                    dgvTenMon.DataSource = con.getDataTable(sb1.ToString());

                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgvTenMon.SelectedCells)
            {
                if (oneCell.Selected)
                    dgvTenMon.Rows.RemoveAt(oneCell.RowIndex);
                bingding();
                bingDing();
                clearform();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            clearform();
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChamCong frm = new frmChamCong();
            frm.Show();
        }

        private void tínhLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLuongNhanVien frm = new frmLuongNhanVien();
            frm.Show();
        }

        private void thêmBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan("");
            frm.Show();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhuVuc frm = new frmKhuVuc();
            frm.Show();
        }

        private void loạiThứcĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaLoai frm = new frmMaLoai();
            frm.Show();
        }

        private void thựcĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThucDon frm = new frmThucDon();
            frm.Show();
        }

        private void nguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNguyenLieu frm = new frmNguyenLieu();
            frm.Show();
        }

        private void thốngKếDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.Show();
        }

        private void nguyênLiệuTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTonKho frm = new frmTonKho();
            frm.Show();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string timKiem = button.Text;

            switch (timKiem)
            {
                case "Bàn 1":
                    var sb1 = new StringBuilder();
                    sb1.Append("Select MABAN from Ban ");
                    sb1.Append("where MABAN = ");
                    sb1.Append("'B01'");
                    con.getDataTable(sb1.ToString());
                    break;

                case "Bàn 2":
                    var sb2 = new StringBuilder();
                    sb2.Append("Select MABAN from Ban ");
                    sb2.Append("where MABAN = ");
                    sb2.Append("'B02'");
                    con.getDataTable(sb2.ToString());
                    break;
                default:
                    break;
            }
        }

        private void btn_GoiMon_Click(object sender, EventArgs e)
        {
            //Insert into Phieu
            var sb = new StringBuilder();
            sb.Append("INSERT INTO PHIEU values('");
            sb.Append(txtMaPhieu.Text.Trim());
            sb.Append("','");
            sb.Append("");
            sb.Append("','");
            sb.Append(0);
            sb.Append("')'");
            con.getDataTable(sb.ToString());
        }
    }
}
