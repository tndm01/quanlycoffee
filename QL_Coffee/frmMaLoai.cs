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
    public partial class frmMaLoai : Form
    {
        public frmMaLoai()
        {
            InitializeComponent();
        }

        BUS_loaiMon lmBUS = new BUS_loaiMon();
        DTO_loaiMon lmDTO = new DTO_loaiMon();
        int flag = 0;//Khai báo biến cờ


        /// <summary>
        /// Hàm load dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMaLoai_Load(object sender, EventArgs e)
        {
            DataTable dtMaLoai = new DataTable();
            dtMaLoai = lmBUS.getdataTable();
            dgvMaLoai.DataSource = dtMaLoai;
            bingding();
            dis_en(false);
        }


        /// <summary>
        /// Hàm load dữ liệu lên dataGridView
        /// </summary>
        void bingding()
        {
            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("Text", dgvMaLoai.DataSource, "MALOAI");

            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", dgvMaLoai.DataSource, "TENLOAI");
        }


        /// <summary>
        /// Hàm khóa dữ liệu
        /// </summary>
        /// <param name="e"></param>
        void dis_en(bool e)
        {
            txtMaLoai.Enabled = e;
            txtTenLoai.Enabled = e;

            //Khóa điều kiện các Buttonn
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThoat.Enabled = !e;
        }

        void blockMALOAI()
        {
            txtMaLoai.ReadOnly = true;
        }
        /// <summary>
        /// Hàm làm sạch dữ liệu
        /// </summary>
        void clearform()
        {
            txtTenLoai.Text = "";
            txtMaLoai.Text = "";
        }


        /// <summary>
        /// Hàm Gán dữ liệu
        /// </summary>
        /// <param name="lmDTO"></param>
        void ganDuLieu(DTO_loaiMon lmDTO)
        {
            lmDTO.MaLoai = txtMaLoai.Text.Trim();
            lmDTO.TenLoai = txtTenLoai.Text.Trim();
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
            frmMaLoai_Load(sender, e);
        }


        /// <summary>
        /// Nút Thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            dis_en(true);
            clearform();
        }


        /// <summary>
        /// Nút Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            blockMALOAI();
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
                ganDuLieu(lmDTO);
                if (flag == 0)
                {
                    if (lmBUS.adddataTable(lmDTO))
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
                    if (lmBUS.upData(lmDTO))
                    {
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            clearform();
            dis_en(false);
            frmMaLoai_Load(sender, e);
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
                DialogResult dr = MessageBox.Show("Bạn Có Muốn Xóa Không? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (lmBUS.deleteData(txtMaLoai.Text.Trim()))
                    {
                        MessageBox.Show("Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa Thất Bại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                dis_en(false);
                clearform();
                frmMaLoai_Load(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
