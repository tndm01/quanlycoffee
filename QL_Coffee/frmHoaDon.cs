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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        SqlConnect con = new SqlConnect();//Hàm kết nối DB
        BUS_ban bBUS = new BUS_ban();

        public string MACTP;
        public static string quyen;

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            //Thêm các sản phẩm vào listbox1
            string sql = "Select * from THUCDON";
            for (int i = 0; i < con.getDataTable(sql).Rows.Count; i++)
            {
                listBox1.Items.Add(con.getDataTable(sql).Rows[i][1].ToString());
            }
            loadMaBan();
            //Phân quyền
            if (quyen == "NHÂN VIÊN")
            {
                ribbonButton7.Enabled = false;
                ribbonButton8.Enabled = false;
                ribbonButton9.Enabled = false;
            }
            this.cboBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Hàm chọn các sản phảm 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                while (listBox1.SelectedItems.Count > 0)
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Hàm bỏ chọn các sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBoChon_Click(object sender, EventArgs e)
        {
            try
            {
                while(listBox2.SelectedItems.Count > 0)
                {
                    listBox1.Items.Add(listBox2.SelectedItem);
                    listBox2.Items.Remove(listBox2.SelectedItem);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hàm load mã bàn
        /// </summary>
        void loadMaBan()
        {
            cboBan.DataSource = bBUS.getDataTable();
            cboBan.ValueMember = ("TENBAN");
            cboBan.DisplayMember = ("MABAN");
        }

        /// <summary>
        /// Hàm Insert into Phiếu và Mã Phiếu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox2.Items.Count > 0)
                {
                    //Insert into PHIEU
                    var Sb = new StringBuilder();
                    Sb.Append("INSERT INTO PHIEU values('");
                    //Sb.Append(txtHoaDon.Text.Trim());
                    //Sb.Append("',N'");
                    Sb.Append(cboBan.Text.Trim());
                    Sb.Append("','");
                    Sb.Append(dtThoiGianLap.Value);
                    Sb.Append("','");
                    Sb.Append(0);
                    Sb.Append("')");
                    con.ThucThiCauLenh(Sb.ToString());

                    //Insert into MACTP

                    for (int i = 0; i < listBox2.Items.Count; i++)//Quét các Items trong listbox2
                    {
                        //Get Id MAPHIEU
                        string maPhieu = con.getDataTable("Select COUNT(*) MAPHIEU from PHIEU").Rows[0][0].ToString();
                        //Get Id MACTP
                        string maCTP = con.getDataTable("Select COUNT(*) MACTP from CHITIETPHIEU").Rows[0][0].ToString();
                        //Lấy mã thực đơn
                        string MAMON = con.getDataTable("Select * from THUCDON Where TENMON = N'" + listBox2.Items[i].ToString().Trim() + "'").Rows[0][0].ToString().Trim();
                        //Tính tiền mỗi sản phẩm với giá trị tương ứng
                        string Tien = con.getDataTable("Select DONGIA from THUCDON where MAMON = '" + MAMON + "'").Rows[0][0].ToString().Trim();
                        //Thực thi câu lệnh Insert into MACTP
                        var sB = new StringBuilder();
                        sB.Append("Insert into CHITIETPHIEU (MAPHIEU,MAMON,SOLUONG,TIEN) values('");
                        //sB.Append(i.ToString());
                        //sB.Append("',N'");
                        sB.Append(maPhieu);
                        sB.Append("','");
                        sB.Append(MAMON);
                        sB.Append("','");
                        sB.Append(1);
                        sB.Append("','");
                        sB.Append(Convert.ToInt32(Tien));
                        sB.Append("')");
                        con.getDataTable(sB.ToString());
                    }
                    //Get id Maphieu
                    string MaPhieu = con.getDataTable("Select COUNT(*) MAPHIEU from PHIEU").Rows[0][0].ToString();
                    dgvHoaDon.DataSource = con.getDataTable("select MACTP,TENMON,SOLUONG,TIEN FROM PHIEU P,CHITIETPHIEU CT,THUCDON TD where P.MAPHIEU = CT.MAPHIEU AND CT.MAMON = TD.MAMON AND P.MAPHIEU = '"+MaPhieu+"'");
                    //Tính tổng các hóa đơn
                    lblTongTien.Text = con.getDataTable("Select sum(TIEN) as TONGTIEN from CHITIETPHIEU where MAPHIEU = '"+MaPhieu+"' ").Rows[0][0].ToString();
                    lblTongTien.Text = (lblTongTien.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("id-ID"), "{0:#,##0}", double.Parse(lblTongTien.Text)));
                    btnLamLai_Click(sender, e);

                }
                else
                {
                    MessageBox.Show("Dữ Liệu Không Hợp Lệ!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hàm clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLamLai_Click(object sender, EventArgs e)
        {
            //Làm sạch listbox1
            listBox1.Items.Clear();
            //Làm sạch listbox2
            listBox2.Items.Clear();
            frmHoaDon_Load(sender, e);
        }

        /// <summary>
        /// Hàm sửa số lượng vừa mới cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                int soLuong = Convert.ToInt32(textBox1.Text);
                if (textBox1.Text == "" || soLuong <= 0)
                {
                    MessageBox.Show("Dữ Liệu Không Hợp Lệ!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dgvHoaDon.Rows.Count > 1)
                {
                    //Get maCTHD
                    int index = dgvHoaDon.CurrentCell.RowIndex;
                    //MACTP = dgvHoaDon.Rows[index].ToString().Trim();
                    string MACTP = dgvHoaDon.Rows[index].Cells[0].Value.ToString();
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        //Get id Maphieu
                        string maPhieu = con.getDataTable("Select COUNT (*) MaPhieu from PHIEU").Rows[0][0].ToString();
                        //
                        string MAMON = con.getDataTable("Select * from THUCDON Where TENMON = N'" + listBox1.Items[i].ToString().Trim() + "'").Rows[0][0].ToString().Trim();
                        //Lấy tiền tương ứng với mã món
                        float Tien = Convert.ToInt32(con.getDataTable("select DONGIA from THUCDON where MAMON ='" + MAMON + "'").Rows[0][0].ToString().Trim()) * Convert.ToInt32(textBox1.Text.Trim());
                        //Thực thi câu lệnh Upadate
                        con.getDataTable("Update CHITIETPHIEU set SOLUONG = '" + Convert.ToInt32(textBox1.Text.Trim()) + "',Tien = '" + Tien + "' where MACTP = '" + MACTP + "' AND MAMON = '" + MAMON + "'");
                        //Load lại dữ liệu
                        dgvHoaDon.DataSource = con.getDataTable("select MACTP,TENMON,SOLUONG,TIEN FROM PHIEU P,CHITIETPHIEU CT,THUCDON TD where P.MAPHIEU = CT.MAPHIEU AND CT.MAMON = TD.MAMON AND P.MAPHIEU = '"+maPhieu+"' ");
                        //Tính tổng các hóa đơn
                        lblTongTien.Text = con.getDataTable("Select sum(TIEN) as TONGTIEN from CHITIETPHIEU WHERE MAPHIEU ='"+maPhieu+"'").Rows[0][0].ToString();
                        //Format Tiền
                        lblTongTien.Text = (lblTongTien.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("id-ID"), "{0:#,##0}", double.Parse(lblTongTien.Text)));
                    }
                }
                else
                {
                    MessageBox.Show("Dữ Liệu Không Hợp Lệ!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        void ClearAll()
        {
            lblTongTien.Text = "";
            textBox1.Text = "";
        }

        /// <summary>
        /// Hàm xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        
        {
            try
            {
                if (dgvHoaDon.Rows.Count > 1)
                {
                    DialogResult dr = MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    int index = dgvHoaDon.CurrentCell.RowIndex;
                    //Count MACTP
                    string Count = con.getDataTable("select COUNT(*) MACTP FROM CHITIETPHIEU").Rows[0][0].ToString();
                    int n = Convert.ToInt32(Count);
                    //Get id MACTP
                    string MACTP = dgvHoaDon.Rows[index].Cells[0].Value.ToString();
                    //Get id MAPHIEU
                    string maPhieu = con.getDataTable("Select COUNT(*) MAPHIEU from PHIEU").Rows[0][0].ToString();
                    if (dr == DialogResult.Yes)
                    {
                        //Delete MACTP
                        var SB = new StringBuilder();
                        SB.Append("Delete from CHITIETPHIEU where MACTP = '" + MACTP + "'");
                        con.getDataTable(SB.ToString());
                        dgvHoaDon.DataSource = con.getDataTable("select MACTP,TENMON,SOLUONG,TIEN FROM PHIEU P,CHITIETPHIEU CT,THUCDON TD where P.MAPHIEU = CT.MAPHIEU AND CT.MAMON = TD.MAMON AND P.MAPHIEU = '"+maPhieu+"' ");
                        //Tính tổng các hóa đơn
                        lblTongTien.Text = con.getDataTable("Select sum(TIEN) as TONGTIEN from CHITIETPHIEU WHERE MAPHIEU ='"+maPhieu+"'").Rows[0][0].ToString();
                        if (n == 1)
                        {
                            //Tính tổng các hóa đơn
                            lblTongTien.Text = con.getDataTable("Select sum(TIEN) as TONGTIEN from CHITIETPHIEU Where MAPHIEU = '" + maPhieu + "'").Rows[0][0].ToString();
                            ClearAll();
                            btnLamLai_Click(sender, e);
                            MessageBox.Show("Xóa Thành Công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Format Tiền 
                        lblTongTien.Text = (lblTongTien.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("id-ID"), "{0:#,##0}", double.Parse(lblTongTien.Text)));
                        MessageBox.Show("Xóa Thành Công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamLai_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa Không Thành Công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dữ Liệu Không Hợp Lệ!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Hàm thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan("");
            frm.ShowDialog();
        }

        private void ribbonButton13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            frmKhuVuc frm = new frmKhuVuc();
            frm.ShowDialog();
        }

        private void ribbonButton5_Click(object sender, EventArgs e)
        {
            frmMaLoai frm = new frmMaLoai();
            frm.ShowDialog();
        }

        private void ribbonButton4_Click(object sender, EventArgs e)
        {
            frmThucDon frm = new frmThucDon();
            frm.ShowDialog();
        }

        private void ribbonButton6_Click(object sender, EventArgs e)
        {
            frmNguyenLieu frm = new frmNguyenLieu();
            frm.ShowDialog();
        }

        private void ribbonButton7_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void ribbonButton8_Click(object sender, EventArgs e)
        {
            frmChamCong frm = new frmChamCong();
            frm.ShowDialog();
        }

        private void ribbonButton9_Click(object sender, EventArgs e)
        {
            frmLuongNhanVien frm = new frmLuongNhanVien();
            frm.ShowDialog();
            Application.Exit();
        }

        private void ribbonButton10_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.ShowDialog();
        }

        private void ribbonButton11_Click(object sender, EventArgs e)
        {
            frmTonKho frm = new frmTonKho();
            frm.ShowDialog();
        }

        private void ribbonButton12_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            Application.Exit();
        }

        /// <summary>
        /// Khóa Điều Kiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Số Lượng Là Kí Tự Số!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
