using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using DAO;
using BUS;

namespace QL_Coffee
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        BUS_nhanVien nvBUS = new BUS_nhanVien();
        DAO_nhanVien nvDAO = new DAO_nhanVien();
        DTO_nhanVien nvDTO = new DTO_nhanVien();
        
        int flag = 0; // Khai báo biến cờ


        /// <summary>
        /// Hàm Load Dữ Liệu Lên DataGirdView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DataTable dtNhanVien = new DataTable();
            dtNhanVien = nvBUS.getDataTable();
            dgvNhanVien.DataSource = dtNhanVien;
            bingding();
            loadControl();
            dis_en(false);
        }

        void bingding()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dgvNhanVien.DataSource, "MANV");

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", dgvNhanVien.DataSource, "TENNV");

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvNhanVien.DataSource, "DIACHI");

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvNhanVien.DataSource, "STD");

            cboGioiTinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "GIOITINH");

            dteNgaySinh.DataBindings.Clear();
            dteNgaySinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "NGAYSINH");

            txtLuong.DataBindings.Clear();
            txtLuong.DataBindings.Add("Text", dgvNhanVien.DataSource, "LUONGCOBAN");

        }

        /// <summary>
        /// Load Dữ Liệu Giới Tính và Khu Vực
        /// </summary>
        void loadControl()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("NAM");
            cboGioiTinh.Items.Add("NỮ");
        }

        /// <summary>
        /// Khóa Điều Kiện
        /// </summary>
        /// <param name="e"></param>
        void dis_en(bool e)
        {
            //Khóa điều kiện các textbox
            txtMaNV.Enabled = e;
            txtTenNV.Enabled = e;
            txtDiaChi.Enabled = e;
            cboGioiTinh.Enabled = e;
            txtSDT.Enabled = e;
            txtLuong.Enabled = e;
            dteNgaySinh.Enabled = e;
            
            //Khóa điều kiện các Buttonn
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThoat.Enabled = !e;
        }

        /// <summary>
        /// Làm Sạch Dữ Liệu
        /// </summary>
        void clearform()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtLuong.Text = "";
            cboGioiTinh.Text = "";
            dteNgaySinh.Text = "";
        }


        /// <summary>
        /// Hàm gán dữ liệu
        /// </summary>
        /// <param name="nvDTO"></param>
        void ganDuLieu(DTO_nhanVien nvDTO)
        {
            nvDTO.MaNV = txtMaNV.Text.Trim();
            nvDTO.TenNV = txtTenNV.Text.Trim();
            nvDTO.DiaChi = txtDiaChi.Text.Trim();
            nvDTO.Sdt = txtSDT.Text.Trim();
            nvDTO.GioiTinh = cboGioiTinh.Text.Trim();
            nvDTO.NgaySinh = dteNgaySinh.Text.Trim();
            nvDTO.LuongCoBan = txtLuong.Text.Trim();
        }

        /// <summary>
        /// Nút Thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Nút Hủy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            dis_en(false);
            frmNhanVien_Load(sender, e);
        }

        /// <summary>
        /// Nút Thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            dis_en(true);
            clearform();
            loadControl();
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
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtLuong.Text == "")
                {
                    MessageBox.Show("Yêu Cầu Nhập Đầy Đủ Thông Tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ganDuLieu(nvDTO);
                if (flag == 0)
                {
                    if (nvBUS.addData(nvDTO))
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Thêm Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (nvBUS.upData(nvDTO))
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sửa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dis_en(false);
                clearform();
                frmNhanVien_Load(sender, e);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        void blockMANV()
        {
            txtMaNV.ReadOnly = true;
        }

        /// <summary>
        /// Nút Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            blockMANV();
            dis_en(true);
            //loadControl();
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
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtLuong.Text == "")
                {
                    MessageBox.Show("Hãy Chọn 1 Đối Tượng Để Xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult dr = MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //Thực Thi câu lệnh xóa
                    if (nvBUS.deleteData(txtMaNV.Text.Trim()))
                        MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Xóa Không Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    return;
                clearform();
                frmNhanVien_Load(sender, e);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
