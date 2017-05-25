namespace QL_Coffee
{
    partial class frmReport
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
            this.components = new System.ComponentModel.Container();   
            this.CHITIETPHIEUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new QL_Coffee.DataSet1();
            this.CHITIETPHIEUTableAdapter = new QL_Coffee.DataSet1TableAdapters.CHITIETPHIEUTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CHITIETPHIEUBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // CHITIETPHIEUBindingSource
            // 
            this.CHITIETPHIEUBindingSource.DataMember = "CHITIETPHIEU";
            this.CHITIETPHIEUBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CHITIETPHIEUTableAdapter
            // 
            this.CHITIETPHIEUTableAdapter.ClearBeforeFill = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 462);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CHITIETPHIEUBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource CHITIETPHIEUBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.CHITIETPHIEUTableAdapter CHITIETPHIEUTableAdapter;
    }
}