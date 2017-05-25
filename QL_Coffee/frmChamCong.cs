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
    public partial class frmChamCong : Form
    {
        public frmChamCong()
        {
            InitializeComponent();
        }

        BUS_chamCong ccBUS = new BUS_chamCong();
        DTO_chamCong ccDTO = new DTO_chamCong();

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            DataTable dtChamCong = new DataTable();
            dtChamCong = ccBUS.getdataTable();
            dgvChamCong.DataSource = dtChamCong;
            bingding();
            loadTENNV();
            dis_en(false);
        }

        void bingding()
        {
            txtSTT.DataBindings.Clear();
            txtSTT.DataBindings.Add("Text", dgvChamCong.DataSource, "STT");

            cboTenNV.DataBindings.Clear();
            cboTenNV.DataBindings.Add("Text", dgvChamCong.DataSource, "TENNV");

            txtSoCa.DataBindings.Clear();
            txtSoCa.DataBindings.Add("Text", dgvChamCong.DataSource, "SOCA");
        }

        void loadTENNV()
        {
            cboTenNV.DataSource = ccBUS.layThongTin("");
            cboTenNV.ValueMember = "TENNV";
            cboTenNV.DisplayMember = "MANV";
        }

        void dis_en(bool e)
        {
            txtSTT.Enabled = e;
            cboTenNV.Enabled = e;
            txtSoCa.Enabled = e;

            btnLuu.Enabled = e;
            btnSua.Enabled = !e;
            btnHuy.Enabled = e;
            btnXoa.Enabled = !e;
        }

        void clearform()
        {
            txtSTT.Text = "";
            cboTenNV.Text = "";
            txtSoCa.Text = "";
        }

        void block()
        {
            txtSTT.ReadOnly = true;
            cboTenNV.Enabled = false;
        }

        void ganDuLieu(DTO_chamCong ccDTO)
        {
            ccDTO.Stt = txtSTT.Text.Trim();
            ccDTO.TenNV = cboTenNV.Text.Trim();
            ccDTO.SoCa = txtSoCa.Text.Trim();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dis_en(true);
            block();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLuongNhanVien frm = new frmLuongNhanVien();
            frm.ShowDialog();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dis_en(false);
            frmChamCong_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ganDuLieu(ccDTO);
                if (ccBUS.upData(ccDTO))
                {
                    MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dis_en(false);
                clearform();
                frmChamCong_Load(sender, e);
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
                DialogResult dr = MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (ccBUS.deleteData(txtSTT.Text.Trim()))
                    {
                        MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dis_en(false);
                clearform();
                frmChamCong_Load(sender, e);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
