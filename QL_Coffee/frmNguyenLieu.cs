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
    public partial class frmNguyenLieu : Form
    {
        public frmNguyenLieu()
        {
            InitializeComponent();
        }

        SqlConnect con = new SqlConnect();
        BUS_NguyenLieu nlBUS = new BUS_NguyenLieu();
        DTO_NguyenLieu nlDTO = new DTO_NguyenLieu();
        int flag = 0;
        DataView dv;
        DataTable dt_NguyenLieu = new DataTable();


        /// <summary>
        /// Hàm load dữ liệu lên DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            dt_NguyenLieu = nlBUS.getDataTable();
            dgvNguyenLieu.DataSource = dt_NguyenLieu;
            dv = new DataView(dt_NguyenLieu);
            bingding();
            dis_en(false);
        }

        /// <summary>
        /// Hàm nhận dạng từ dòng của DataGridView
        /// </summary>
        void bingding()
        {
            txtMaNL.DataBindings.Clear();
            txtMaNL.DataBindings.Add("Text", dgvNguyenLieu.DataSource, "MANL");

            txtTenNL.DataBindings.Clear();
            txtTenNL.DataBindings.Add("Text", dgvNguyenLieu.DataSource, "TENNL");

            txtSLN.DataBindings.Clear();
            txtSLN.DataBindings.Add("Text", dgvNguyenLieu.DataSource, "SOLUONG");

            txtDVT.DataBindings.Clear();
            txtDVT.DataBindings.Add("Text", dgvNguyenLieu.DataSource, "DVT");
        }


        /// <summary>
        /// Hàm khóa điều kiện textbox và button
        /// </summary>
        /// <param name="e"></param>
        void dis_en(bool e)
        {
            txtMaNL.Enabled = e;
            txtTenNL.Enabled = e;
            txtSLN.Enabled = e;
            txtDVT.Enabled = e;
            dptNgayNhap.Enabled = e;

            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
            btnThoat.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
        }


        /// <summary>
        /// Hàm khóa Mã Nguyên Liệu
        /// </summary>
        void khoaMANL()
        {
            txtMaNL.ReadOnly = true;
        }


        /// <summary>
        /// Hàm làm sạch dữ liệu
        /// </summary>
        void clearform()
        {
            txtMaNL.Text = "";
            txtTenNL.Text = "";
            txtSLN.Text = "";
            txtDVT.Text = "";
            dptNgayNhap.Text = "";
        }

        void clearTenNL()
        {
            txtTimKiem.Text = "";
        }

        /// <summary>
        /// Hàm gán dữ liệu
        /// </summary>
        /// <param name="nlDTO"></param>
        void ganDuLieu(DTO_NguyenLieu nlDTO)
        {
            nlDTO.MaNL = txtMaNL.Text.Trim();
            nlDTO.TenNL = txtTenNL.Text.Trim();
            nlDTO.Dvt = txtDVT.Text.Trim();
            nlDTO.SoLuong = txtSLN.Text.Trim();
            nlDTO.NgayNhap = dptNgayNhap.Text.Trim();
        }


        /// <summary>
        /// Nút thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            dis_en(true);
            clearform();
        }


        /// <summary>
        /// Nút sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            khoaMANL();
            dis_en(true);
        }


        /// <summary>
        /// Nút hủy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            dis_en(false);
            clearTenNL();
            frmNguyenLieu_Load(sender, e);
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
        /// Nút lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNL.Text == "" || txtTenNL.Text == "" || txtDVT.Text == "" || txtSLN.Text == "")
            {
                MessageBox.Show("Yêu Cầu Nhập Đầy Đủ Thông Tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ganDuLieu(nlDTO);
                if (flag == 0)
                {
                    if (nlBUS.addData(nlDTO))
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
                    if (nlBUS.upData(nlDTO))
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
                frmNguyenLieu_Load(sender, e);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Nút xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (nlBUS.deleteData(txtMaNL.Text.Trim()))
                    {
                        MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    return;
                clearform();
                frmNguyenLieu_Load(sender, e);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Nút tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Quản lý tìm kiếm
            string bookName = txtTimKiem.Text;
            dv.RowFilter =String.Format( "TENNL LIKE'" + bookName + "%'");
            dgvNguyenLieu.DataSource = dv;
        }

        private void txtSLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Yêu Cầu Nhập Số!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Yêu Cầu Nhập Số!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTenNL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Yêu Cầu Nhập Chữ!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
