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
    public partial class frmBan : Form
    {
        static string maKV;

        public frmBan(string makhuvuc)
        {
            maKV = makhuvuc;
            InitializeComponent();
        }

        DAO_ban bDAO = new DAO_ban();
        DTO_ban bDTO = new DTO_ban();
        BUS_ban bBUS = new BUS_ban();
        int flag = 0;

        /// <summary>
        /// Hàm load dữ liệu lên DataGirdView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBan_Load(object sender, EventArgs e)
        {
            DataTable dtBan = new DataTable();
            dtBan = bBUS.getDataTable();
            dgvBan.DataSource = dtBan;
            bingding();
            loadTenKV();
            dis_en(false);
        }

        void bingding()
        {
            txtMaBan.DataBindings.Clear();
            txtMaBan.DataBindings.Add("Text", dgvBan.DataSource, "MABAN");

            txtTenBan.DataBindings.Clear();
            txtTenBan.DataBindings.Add("Text", dgvBan.DataSource, "TENBAN");

            txtSoNguoi.DataBindings.Clear();
            txtSoNguoi.DataBindings.Add("Text", dgvBan.DataSource, "SONGUOI");

            cboVitri.DataBindings.Clear();
            cboVitri.DataBindings.Add("Text", dgvBan.DataSource, "MAKV");
        }

        /// <summary>
        /// Hàm Load Tên Khu Vực
        /// </summary>
        void loadTenKV()
        {
            cboVitri.DataSource = bBUS.getDataTable();
            cboVitri.DisplayMember = "KHUVUC";
            cboVitri.ValueMember = "MAKV";
        }


        /// <summary>
        /// Hàm Khóa Điều Kiện
        /// </summary>
        /// <param name="e"></param>
        void dis_en(bool e)
        {
            txtMaBan.Enabled = e;
            txtSoNguoi.Enabled = e;
            txtTenBan.Enabled = e;
            cboVitri.Enabled = e;

            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
            btnHuy.Enabled = e;
            btnThoat.Enabled = !e;
            btnLuu.Enabled = e;
        }

        void khoaMa()
        {
            txtMaBan.ReadOnly = true;
        }

        void clearform()
        {
            txtMaBan.Text = "";
            txtTenBan.Text = "";
            txtSoNguoi.Text = "";
            cboVitri.Text = "";
        }

        void ganGiaTri(DTO_ban bDTO)
        {
            bDTO.MaBan = txtMaBan.Text.Trim();
            bDTO.TenBan = txtTenBan.Text.Trim();
            bDTO.SoNguoi = txtSoNguoi.Text.Trim();
            bDTO.MaKV = cboVitri.Text.Trim();
        }


        /// <summary>
        /// Nút Xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
            loadTenKV();
        }


        /// <summary>
        /// Nút Hủy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            dis_en(false);
            frmBan_Load(sender, e);
        }

        void blockMABAN()
        {
            txtMaBan.ReadOnly = true;
        }

        /// <summary>
        /// Nút Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            blockMABAN();
            dis_en(true);
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
                if (txtMaBan.Text == "" || txtTenBan.Text == "" || txtSoNguoi.Text == "")
                {
                    MessageBox.Show("Yêu Cầu Nhập Đầy Đủ Thông Tin", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ganGiaTri(bDTO);
                if (flag == 0)
                {
                    if (bBUS.addData(bDTO))
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Thêm Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (bBUS.upData(bDTO))
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sửa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                khoaMa();
                dis_en(false);
                clearform();
                frmBan_Load(sender, e);
            }
            catch(Exception ex)
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
                if (txtMaBan.Text == "" || txtTenBan.Text =="" || txtSoNguoi.Text =="")
                {
                    MessageBox.Show("Hãy Chọn 1 Đối Tượng Để Xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult dr = MessageBox.Show("Bạn Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (bBUS.deleteData(txtMaBan.Text.Trim()))
                        MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Xóa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    return;
                clearform();
                frmBan_Load(sender, e);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
