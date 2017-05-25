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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        sqlConnect con = new sqlConnect();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = txtUesrName.Text.Trim();//Lấy User vừa nhập
                string password = txtPassword.Text.Trim();//Lấy Password vừa nhập
                //Câu truy vấn xem TENDN và MATKHAU
                string sql = "Select * from DANGNHAP where TENDN = '" + ID + "' AND MATKHAU = '" + password + "'";
                //Xét Password lớn hơn 6
                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Tối Đa Phải 6 Kí Tự!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtUesrName.Text = "";
                    txtUesrName.Focus();
                    return;
                }
                //Phân quyền cho User
                if (ID != "" || password != "")
                {
                    if (con.getDataTable(sql).Rows.Count != 0)
                    {
                        frmHoaDon.quyen = con.getDataTable("Select QUYEN from DANGNHAP where TENDN = '" + ID + "'AND MATKHAU = '" + password + "'").Rows[0][0].ToString();
                        this.Hide();
                        frmHoaDon frm = new frmHoaDon();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Đăng Nhập Thất Bại!!!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtUesrName.Text = "";
                        txtPassword.Text = "";
                        txtUesrName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
