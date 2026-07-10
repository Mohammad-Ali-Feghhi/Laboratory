
namespace Laboratory.Forms.Doctors
{
    partial class frmInactiveDoctors
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.clmnDoctorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnMedicalLicenseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIsEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEnable = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnDoctorId,
            this.clmnDoctorName,
            this.clmnMedicalLicenseNumber,
            this.clmnIsEnabled,
            this.btnEnable});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataGrid.Name = "DataGrid";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGrid.RowTemplate.Height = 35;
            this.DataGrid.Size = new System.Drawing.Size(593, 420);
            this.DataGrid.TabIndex = 1;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            // 
            // clmnDoctorId
            // 
            this.clmnDoctorId.DataPropertyName = "DoctorId";
            this.clmnDoctorId.HeaderText = "کد پزشک";
            this.clmnDoctorId.Name = "clmnDoctorId";
            this.clmnDoctorId.ReadOnly = true;
            this.clmnDoctorId.Visible = false;
            // 
            // clmnDoctorName
            // 
            this.clmnDoctorName.DataPropertyName = "DoctorName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnDoctorName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmnDoctorName.HeaderText = "نام پزشک";
            this.clmnDoctorName.MinimumWidth = 250;
            this.clmnDoctorName.Name = "clmnDoctorName";
            this.clmnDoctorName.ReadOnly = true;
            this.clmnDoctorName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnDoctorName.Width = 250;
            // 
            // clmnMedicalLicenseNumber
            // 
            this.clmnMedicalLicenseNumber.DataPropertyName = "MedicalLicenseNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnMedicalLicenseNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmnMedicalLicenseNumber.HeaderText = "شماره نظام پزشکی";
            this.clmnMedicalLicenseNumber.MinimumWidth = 200;
            this.clmnMedicalLicenseNumber.Name = "clmnMedicalLicenseNumber";
            this.clmnMedicalLicenseNumber.ReadOnly = true;
            this.clmnMedicalLicenseNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnMedicalLicenseNumber.Width = 200;
            // 
            // clmnIsEnabled
            // 
            this.clmnIsEnabled.DataPropertyName = "IsEnabled";
            this.clmnIsEnabled.HeaderText = "فعال";
            this.clmnIsEnabled.Name = "clmnIsEnabled";
            this.clmnIsEnabled.Visible = false;
            // 
            // btnEnable
            // 
            this.btnEnable.HeaderText = "";
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Text = "فعال کردن";
            this.btnEnable.UseColumnTextForButtonValue = true;
            // 
            // frmInactiveDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 420);
            this.Controls.Add(this.DataGrid);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInactiveDoctors";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست پزشکان غیر فعال";
            this.Load += new System.EventHandler(this.frmInactiveDoctors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDoctorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnMedicalLicenseNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnIsEnabled;
        private System.Windows.Forms.DataGridViewButtonColumn btnEnable;
    }
}