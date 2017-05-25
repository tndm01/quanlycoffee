namespace QL_Coffee
{
    partial class frmNguyenLieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dptNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.txtTenNL = new System.Windows.Forms.TextBox();
            this.txtSLN = new System.Windows.Forms.TextBox();
            this.txtMaNL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvNguyenLieu = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(202, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Nguyên Liệu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dptNgayNhap);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtDVT);
            this.groupBox1.Controls.Add(this.txtTenNL);
            this.groupBox1.Controls.Add(this.txtSLN);
            this.groupBox1.Controls.Add(this.txtMaNL);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 192);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản Lý Nhập Liệu";
            // 
            // dptNgayNhap
            // 
            this.dptNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptNgayNhap.Location = new System.Drawing.Point(140, 102);
            this.dptNgayNhap.Name = "dptNgayNhap";
            this.dptNgayNhap.Size = new System.Drawing.Size(155, 26);
            this.dptNgayNhap.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 19);
            this.label7.TabIndex = 3;
            this.label7.Text = "Ngày Nhập";
            // 
            // btnThoat
            // 
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Location = new System.Drawing.Point(494, 140);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(78, 46);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Location = new System.Drawing.Point(398, 140);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(78, 46);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Location = new System.Drawing.Point(206, 140);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(78, 46);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Location = new System.Drawing.Point(302, 140);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(78, 46);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Location = new System.Drawing.Point(110, 140);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(78, 46);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Location = new System.Drawing.Point(14, 140);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(78, 46);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(415, 69);
            this.txtDVT.MaxLength = 10;
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(149, 26);
            this.txtDVT.TabIndex = 4;
            this.txtDVT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDVT_KeyPress);
            // 
            // txtTenNL
            // 
            this.txtTenNL.Location = new System.Drawing.Point(140, 69);
            this.txtTenNL.MaxLength = 30;
            this.txtTenNL.Name = "txtTenNL";
            this.txtTenNL.Size = new System.Drawing.Size(155, 26);
            this.txtTenNL.TabIndex = 3;
            this.txtTenNL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenNL_KeyPress);
            // 
            // txtSLN
            // 
            this.txtSLN.Location = new System.Drawing.Point(415, 31);
            this.txtSLN.MaxLength = 30;
            this.txtSLN.Name = "txtSLN";
            this.txtSLN.Size = new System.Drawing.Size(149, 26);
            this.txtSLN.TabIndex = 2;
            this.txtSLN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSLN_KeyPress);
            // 
            // txtMaNL
            // 
            this.txtMaNL.Location = new System.Drawing.Point(140, 31);
            this.txtMaNL.MaxLength = 10;
            this.txtMaNL.Name = "txtMaNL";
            this.txtMaNL.Size = new System.Drawing.Size(155, 26);
            this.txtMaNL.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số Lượng Nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đơn Vị Tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã Nguyên Liệu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Nguyên Liệu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dgvNguyenLieu);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 273);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Nguyên Liệu";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Location = new System.Drawing.Point(440, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(87, 55);
            this.btnTimKiem.TabIndex = 14;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(239, 31);
            this.txtTimKiem.MaxLength = 20;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(175, 26);
            this.txtTimKiem.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Nhập Tên Sản Phẩm";
            // 
            // dgvNguyenLieu
            // 
            this.dgvNguyenLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguyenLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguyenLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvNguyenLieu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNguyenLieu.Location = new System.Drawing.Point(3, 84);
            this.dgvNguyenLieu.Name = "dgvNguyenLieu";
            this.dgvNguyenLieu.Size = new System.Drawing.Size(604, 186);
            this.dgvNguyenLieu.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MANL";
            this.Column1.HeaderText = "MANL";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENNL";
            this.Column2.HeaderText = "Tên NL";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SOLUONG";
            this.Column3.HeaderText = "Số Lượng";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DVT";
            this.Column4.HeaderText = "Đơn Vị Tính";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NGAYNHAP";
            this.Column5.HeaderText = "Ngày Nhập";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // frmNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 502);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmNguyenLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNguyenLieu";
            this.Load += new System.EventHandler(this.frmNguyenLieu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.TextBox txtTenNL;
        private System.Windows.Forms.TextBox txtSLN;
        private System.Windows.Forms.TextBox txtMaNL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvNguyenLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DateTimePicker dptNgayNhap;
        private System.Windows.Forms.Label label7;
    }
}