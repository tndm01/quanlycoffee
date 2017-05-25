namespace QL_Coffee
{
    partial class frmTonKho
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
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTonKho = new System.Windows.Forms.TextBox();
            this.txtDaBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTinhHang = new System.Windows.Forms.Button();
            this.cboTenMon = new System.Windows.Forms.ComboBox();
            this.txtConLai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(251, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống Kê Tồn Kho";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTonKho);
            this.groupBox1.Controls.Add(this.txtTonKho);
            this.groupBox1.Controls.Add(this.txtDaBan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 247);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hàng Tồn Kho";
            // 
            // dgvTonKho
            // 
            this.dgvTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvTonKho.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTonKho.Location = new System.Drawing.Point(3, 78);
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.Size = new System.Drawing.Size(663, 166);
            this.dgvTonKho.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TENMON";
            this.Column1.HeaderText = "Tên Món";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DONGIA";
            this.Column2.HeaderText = "Đơn Giá";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DVT";
            this.Column3.HeaderText = "Đơn Vị Tính";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SLN";
            this.Column4.HeaderText = "SLN";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SLT";
            this.Column5.HeaderText = "SLT";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // txtTonKho
            // 
            this.txtTonKho.Location = new System.Drawing.Point(504, 26);
            this.txtTonKho.Name = "txtTonKho";
            this.txtTonKho.Size = new System.Drawing.Size(129, 26);
            this.txtTonKho.TabIndex = 2;
            // 
            // txtDaBan
            // 
            this.txtDaBan.Location = new System.Drawing.Point(198, 26);
            this.txtDaBan.Name = "txtDaBan";
            this.txtDaBan.Size = new System.Drawing.Size(129, 26);
            this.txtDaBan.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số Lượng Hàng Tồn Kho";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số Lượng Hàng Đã Bán";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTinhHang);
            this.groupBox2.Controls.Add(this.cboTenMon);
            this.groupBox2.Controls.Add(this.txtConLai);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 110);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nguyên Liệu Tồn Kho";
            // 
            // btnTinhHang
            // 
            this.btnTinhHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhHang.Location = new System.Drawing.Point(567, 30);
            this.btnTinhHang.Name = "btnTinhHang";
            this.btnTinhHang.Size = new System.Drawing.Size(92, 53);
            this.btnTinhHang.TabIndex = 3;
            this.btnTinhHang.Text = "Tính Hàng";
            this.btnTinhHang.UseVisualStyleBackColor = true;
            this.btnTinhHang.Click += new System.EventHandler(this.btnTinhHang_Click);
            // 
            // cboTenMon
            // 
            this.cboTenMon.FormattingEnabled = true;
            this.cboTenMon.Location = new System.Drawing.Point(144, 41);
            this.cboTenMon.Name = "cboTenMon";
            this.cboTenMon.Size = new System.Drawing.Size(154, 27);
            this.cboTenMon.TabIndex = 2;
            // 
            // txtConLai
            // 
            this.txtConLai.Location = new System.Drawing.Point(391, 42);
            this.txtConLai.Name = "txtConLai";
            this.txtConLai.Size = new System.Drawing.Size(151, 26);
            this.txtConLai.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tồn Kho";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên Nguyên Liệu";
            // 
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 394);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTonKho";
            this.Load += new System.EventHandler(this.frmTonKho_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.TextBox txtDaBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTonKho;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTinhHang;
        private System.Windows.Forms.ComboBox cboTenMon;
        private System.Windows.Forms.TextBox txtConLai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}