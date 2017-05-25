using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using BUS;
using DTO;
using System.Data.SqlClient;

namespace QL_Coffee
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        SqlConnect con = new SqlConnect();

        void allClear()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtNewPassWord.Text = "";
            txtAgainPassWord.Text = "";
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            SqlConnect con = new SqlConnect();
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string newPassword = txtNewPassWord.Text;
            string confNewPassword = txtAgainPassWord.Text;
            try
            {
                if (txtNewPassWord.Text != txtAgainPassWord.Text)
                {
                    MessageBox.Show("Tên Đăng Nhập Hoặc Mật Khẩu Không Chính Xác!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allClear();
                    txtUserName.Focus();
                    return;
                }
                else
                {
                    if (txtPassword.Text.Length <= 6 && txtNewPassWord.Text.Length <= 6 && txtAgainPassWord.Text.Length <= 6)
                    {
                        MessageBox.Show("Mật Khẩu Phải Từ 6 Kí Tự Trở Lên!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        allClear();
                        txtUserName.Focus();
                        return;
                    }
                }
                if (txtNewPassWord.Text == txtAgainPassWord.Text)
                {
                    var sb = new StringBuilder();
                    sb.Append("Update DANGNHAP set MATKHAU = '");
                    sb.Append(txtNewPassWord.Text.Trim());
                    sb.Append("' where TENDN ='");
                    sb.Append(txtUserName.Text.Trim());
                    sb.Append("' AND MATKHAU ='");
                    sb.Append(txtPassword.Text.Trim());
                    sb.Append("'");
                    con.getDataTable(sb.ToString());
                    allClear();
                    frmChangePassword_Load(sender, e);
                    MessageBox.Show("Update Sucessfuly!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Không Thể Upate");
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
