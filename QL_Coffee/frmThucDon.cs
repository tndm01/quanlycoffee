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

namespace QL_Coffee
{
    public partial class frmThucDon : Form
    {
        public frmThucDon()
        {
            InitializeComponent();
        }

        DTO_thucDon tdDTO = new DTO_thucDon();
        DAO_thucDon tdDAO = new DAO_thucDon();
        BUS_thucDon tdBUS = new BUS_thucDon();

        int flag = 0;


        /// <summary>
        /// Hàm load dữ liệu lên DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmThucDon_Load(object sender, EventArgs e)
        {
            DataTable dtThucDon = new DataTable();
            dtThucDon = tdBUS.getDataTable();
            dgvThucDon.DataSource = dtThucDon;
            bingding();
            dis_en(false);
            loadMaLoai();
        }


        /// <summary>
        /// Hiển thị dữ liệu lên DataGridView
        /// </summary>
        void bingding()
        {
            txtMaMon.DataBindings.Clear();
            txtMaMon.DataBindings.Add("Text", dgvThucDon.DataSource, "MAMON");

            txtTenMon.DataBindings.Clear();
            txtTenMon.DataBindings.Add("Text", dgvThucDon.DataSource, "TENMON");

            cboLoaiMon.DataBindings.Clear();
            cboLoaiMon.DataBindings.Add("Text", dgvThucDon.DataSource, "MALOAI");

            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dgvThucDon.DataSource, "DONGIA");

            txtDvT.DataBindings.Clear();
            txtDvT.DataBindings.Add("Text", dgvThucDon.DataSource, "DVT");

            txtSLN.DataBindings.Clear();
            txtSLN.DataBindings.Add("Text", dgvThucDon.DataSource, "SLN");

            txtSLT.DataBindings.Clear();
            txtSLT.DataBindings.Add("Text", dgvThucDon.DataSource, "SLT");
        }


        /// <summary>
        /// Hàm load Mã Loại
        /// </summary>
        void loadMaLoai()
        {
            cboLoaiMon.DataSource = tdBUS.laythongTin("");
            cboLoaiMon.ValueMember = "MALOAI";
            cboLoaiMon.DisplayMember = "TENLOAI";
        }


        /// <summary>
        /// Hàm khóa các điều kiện
        /// </summary>
        /// <param name="e"></param>
        void dis_en(bool e)
        {
            //Khóa các điều kiện textbox
            txtMaMon.Enabled = e;
            txtTenMon.Enabled = e;
            cboLoaiMon.Enabled = e;
            txtDonGia.Enabled = e;
            txtDvT.Enabled = e;
            txtSLN.Enabled = e;
            txtSLT.Enabled = e;

            //Khóa các điều kiện button
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
            btnThoat.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
        }


        /// <summary>
        /// Hàm làm sạch các dữ liệu
        /// </summary>
        void clearform()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            cboLoaiMon.Text = "";
            txtDonGia.Text = "";
            txtDvT.Text = "";
            txtSLN.Text = "";
            txtSLT.Text = "";
        }


        /// <summary>
        /// Hàm khóa MAMON
        /// </summary>
        void khoaMAMON()
        {
            txtMaMon.ReadOnly = true;
        }


        /// <summary>
        /// Nút thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            dis_en(true);
            clearform();
            loadMaLoai();
        }


        /// <summary>
        /// Nút Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            khoaMAMON();
            dis_en(true);
        }


        /// <summary>
        /// Nút Hủy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            dis_en(false);
            loadMaLoai();
            frmThucDon_Load(sender, e);
        }


        /// <summary>
        /// Hàm gán dữ liệu
        /// </summary>
        /// <param name="tdDTO"></param>
        void ganDuLieu(DTO_thucDon tdDTO)
        {
            tdDTO.MaMon = txtMaMon.Text.Trim();
            tdDTO.TenMon = txtTenMon.Text.Trim();
            tdDTO.MaLoai = cboLoaiMon.Text.Trim();
            tdDTO.DonGia = txtDonGia.Text.Trim();
            tdDTO.Dvt = txtDvT.Text.Trim();
            tdDTO.Sln = txtSLN.Text.Trim();
            tdDTO.Slt = txtSLT.Text.Trim();
        }


        /// <summary>
        /// Nút thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Nút Lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaMon.Text == "" || txtTenMon.Text == "" || txtDonGia.Text == "" || txtDvT.Text == "" || txtSLN.Text == "" || txtSLT.Text == "")
                {
                    MessageBox.Show("Yêu Cầu Nhập Đầy Đủ Thông Tin", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    ganDuLieu(tdDTO);
                    if (flag == 0)
                    {
                        if (tdBUS.addData(tdDTO))
                        {
                            MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (tdBUS.upData(tdDTO))
                        {
                            MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Sửa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    dis_en(false);
                    clearform();
                    frmThucDon_Load(sender, e);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Nút Xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaMon.Text == "" || txtTenMon.Text == "" || txtDonGia.Text == "" || txtDvT.Text == "" || txtSLN.Text == "" || txtSLT.Text == "")
                {
                    MessageBox.Show("Yêu Cầu Nhập Đầy Đủ Thông Tin", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    DialogResult dr = MessageBox.Show("Bạn Có Muốn Xóa Không? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        if (tdBUS.deleteData(txtMaMon.Text.Trim()))
                        {
                            MessageBox.Show("Đã Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa Không Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        return;
                    dis_en(false);
                    clearform();
                    frmThucDon_Load(sender, e);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Ràng buộc chỉ cho nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Ràng buộc chỉ cho nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSLT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Hãy Nhập Số!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Ràng buộc chỉ cho nhập chữ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTenMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Cho Phép Nhập Chữ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
