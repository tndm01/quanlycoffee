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
    public partial class frmKhuVuc : Form
    {
        public frmKhuVuc()
        {
            InitializeComponent();
        }

        BUS_khuVuc kvBUS = new BUS_khuVuc();
        DAO_khuVuc kvDAO = new DAO_khuVuc();
        DTO_khuVuc kvDTO = new DTO_khuVuc();
        BUS_ban bBUS = new BUS_ban();
        DTO_ban bDTO = new DTO_ban();
        int flag = 0;


        /// <summary>
        /// Hàm load dữ liệu lên DataGirdView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmKhuVuc_Load(object sender, EventArgs e)
        {
            DataTable dtKhuVuc = new DataTable();
            dtKhuVuc = kvBUS.getdataTable();
            dgvKhuVuc.DataSource = dtKhuVuc;
            bingding();
            loadTenKV();
            dis_en(false);
        }

        void bingding()
        {
            txtMaKV.DataBindings.Clear();
            txtMaKV.DataBindings.Add("Text", dgvKhuVuc.DataSource, "MAKV");

            cboTenKV.DataBindings.Clear();
            cboTenKV.DataBindings.Add("Text", dgvKhuVuc.DataSource, "TENKV");
        }


        /// <summary>
        /// Hàm load tên khu vực
        /// </summary>
        void loadTenKV()
        {
            cboTenKV.DataSource = kvBUS.getdataTable();
            cboTenKV.ValueMember = "MAKV";
            cboTenKV.DisplayMember = "TENKV";
        }


        /// <summary>
        /// Hàm khóa điều kiện
        /// </summary>
        /// <param name="e"></param>
        void dis_en(bool e)
        {
            txtMaKV.Enabled = e;
            cboTenKV.Enabled = e;

            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThoat.Enabled = !e;
        }


        /// <summary>
        /// Hàm làm sạch các dữ liệu
        /// </summary>
        void clearform()
        {
            txtMaKV.Text = "";
            cboTenKV.Text = "";
        }


        /// <summary>
        /// Hàm gán dữ liệu
        /// </summary>
        /// <param name="kvDTO"></param>
        void ganDuLieu(DTO_khuVuc kvDTO)
        {
            kvDTO.MaKV = txtMaKV.Text.Trim();
            kvDTO.TenKV = cboTenKV.Text.Trim();
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
        /// Nút thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            dis_en(true);
            loadTenKV();
            clearform();
        }


        /// <summary>
        /// Nút Hủy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            dis_en(false);
            frmKhuVuc_Load(sender, e);
        }

        void blockMAKV()
        {
            txtMaKV.ReadOnly = true;
        }

        /// <summary>
        /// Nút sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            blockMAKV();
            dis_en(true);
        }


        /// <summary>
        /// Nút lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ganDuLieu(kvDTO);
                if (flag == 0)
                {
                    if (kvBUS.addData(kvDTO))
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Thêm Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (kvBUS.upData(kvDTO))
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sửa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dis_en(false);
                clearform();
                frmKhuVuc_Load(sender, e);
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
            if (MessageBox.Show("Bạn Có Muốn Xóa Không", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    kvBUS.deleteData(txtMaKV.Text);
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bạn Không Thể Xóa Ở Bảng Này Hãy Xóa Ở Bảng Kế Tiếp!!!" + ex.Message);
                    frmBan frm = new frmBan(txtMaKV.Text);
                    frm.ShowDialog();
                }
            }
            else
                return;
                clearform();
                frmKhuVuc_Load(sender, e);
        }
    }
}
