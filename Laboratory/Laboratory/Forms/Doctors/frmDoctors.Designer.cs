
namespace Laboratory.Forms.Doctors
{
    partial class frmDoctors
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.clmnDoctorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnMedicalLicenseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIsEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbDoctorStatus = new System.Windows.Forms.GroupBox();
            this.rdbDisable = new System.Windows.Forms.RadioButton();
            this.rdbEnable = new System.Windows.Forms.RadioButton();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.lblLicenseNumber = new System.Windows.Forms.Label();
            this.txtLicenseNumber = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.grbDoctorStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnDoctorId,
            this.clmnDoctorName,
            this.clmnMedicalLicenseNumber,
            this.clmnDescription,
            this.clmnIsEnabled,
            this.clmnEdit,
            this.clmnDelete});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle9;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGrid.Location = new System.Drawing.Point(0, 269);
            this.DataGrid.Name = "DataGrid";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DataGrid.RowTemplate.Height = 35;
            this.DataGrid.Size = new System.Drawing.Size(913, 269);
            this.DataGrid.TabIndex = 2;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnDoctorName.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmnDoctorName.HeaderText = "نام پزشک";
            this.clmnDoctorName.MaxInputLength = 150;
            this.clmnDoctorName.MinimumWidth = 200;
            this.clmnDoctorName.Name = "clmnDoctorName";
            this.clmnDoctorName.ReadOnly = true;
            this.clmnDoctorName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnDoctorName.Width = 200;
            // 
            // clmnMedicalLicenseNumber
            // 
            this.clmnMedicalLicenseNumber.DataPropertyName = "MedicalLicenseNumber";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnMedicalLicenseNumber.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmnMedicalLicenseNumber.HeaderText = "شماره نظام پزشکی";
            this.clmnMedicalLicenseNumber.MaxInputLength = 100;
            this.clmnMedicalLicenseNumber.MinimumWidth = 150;
            this.clmnMedicalLicenseNumber.Name = "clmnMedicalLicenseNumber";
            this.clmnMedicalLicenseNumber.ReadOnly = true;
            this.clmnMedicalLicenseNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnMedicalLicenseNumber.Width = 150;
            // 
            // clmnDescription
            // 
            this.clmnDescription.DataPropertyName = "Description";
            this.clmnDescription.HeaderText = "توضیحات";
            this.clmnDescription.MaxInputLength = 1000;
            this.clmnDescription.MinimumWidth = 320;
            this.clmnDescription.Name = "clmnDescription";
            this.clmnDescription.ReadOnly = true;
            this.clmnDescription.Width = 320;
            // 
            // clmnIsEnabled
            // 
            this.clmnIsEnabled.DataPropertyName = "IsEnabled";
            this.clmnIsEnabled.HeaderText = "فعال";
            this.clmnIsEnabled.Name = "clmnIsEnabled";
            this.clmnIsEnabled.Visible = false;
            // 
            // clmnEdit
            // 
            this.clmnEdit.HeaderText = "";
            this.clmnEdit.Name = "clmnEdit";
            this.clmnEdit.Text = "ویرایش";
            this.clmnEdit.UseColumnTextForButtonValue = true;
            // 
            // clmnDelete
            // 
            this.clmnDelete.HeaderText = "";
            this.clmnDelete.Name = "clmnDelete";
            this.clmnDelete.Text = "حذف";
            this.clmnDelete.UseColumnTextForButtonValue = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(581, 146);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 33);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "ثبت تغییرات";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(709, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "بازگشت";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grbDoctorStatus
            // 
            this.grbDoctorStatus.Controls.Add(this.rdbDisable);
            this.grbDoctorStatus.Controls.Add(this.rdbEnable);
            this.grbDoctorStatus.Location = new System.Drawing.Point(536, 28);
            this.grbDoctorStatus.Name = "grbDoctorStatus";
            this.grbDoctorStatus.Size = new System.Drawing.Size(324, 100);
            this.grbDoctorStatus.TabIndex = 3;
            this.grbDoctorStatus.TabStop = false;
            this.grbDoctorStatus.Text = "وضعیت پزشک:";
            // 
            // rdbDisable
            // 
            this.rdbDisable.AutoSize = true;
            this.rdbDisable.Location = new System.Drawing.Point(49, 51);
            this.rdbDisable.Name = "rdbDisable";
            this.rdbDisable.Size = new System.Drawing.Size(74, 27);
            this.rdbDisable.TabIndex = 1;
            this.rdbDisable.TabStop = true;
            this.rdbDisable.Text = "غیر فعال";
            this.rdbDisable.UseVisualStyleBackColor = true;
            // 
            // rdbEnable
            // 
            this.rdbEnable.AutoSize = true;
            this.rdbEnable.Location = new System.Drawing.Point(214, 51);
            this.rdbEnable.Name = "rdbEnable";
            this.rdbEnable.Size = new System.Drawing.Size(55, 27);
            this.rdbEnable.TabIndex = 0;
            this.rdbEnable.TabStop = true;
            this.rdbEnable.Text = "فعال";
            this.rdbEnable.UseVisualStyleBackColor = true;
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Location = new System.Drawing.Point(183, 28);
            this.txtDoctorName.MaxLength = 150;
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.Size = new System.Drawing.Size(222, 27);
            this.txtDoctorName.TabIndex = 0;
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Location = new System.Drawing.Point(63, 28);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(63, 23);
            this.lblDoctorName.TabIndex = 7;
            this.lblDoctorName.Text = "نام پزشک:";
            // 
            // lblLicenseNumber
            // 
            this.lblLicenseNumber.AutoSize = true;
            this.lblLicenseNumber.Location = new System.Drawing.Point(63, 73);
            this.lblLicenseNumber.Name = "lblLicenseNumber";
            this.lblLicenseNumber.Size = new System.Drawing.Size(114, 23);
            this.lblLicenseNumber.TabIndex = 9;
            this.lblLicenseNumber.Text = "شماره نظام پزشکی:";
            // 
            // txtLicenseNumber
            // 
            this.txtLicenseNumber.Location = new System.Drawing.Point(183, 73);
            this.txtLicenseNumber.MaxLength = 8;
            this.txtLicenseNumber.Name = "txtLicenseNumber";
            this.txtLicenseNumber.Size = new System.Drawing.Size(222, 27);
            this.txtLicenseNumber.TabIndex = 1;
            this.txtLicenseNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseNumber_KeyPress);
            this.txtLicenseNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLicenseNumber_KeyUp);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(63, 119);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 23);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "توضیحات:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(183, 119);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(222, 128);
            this.txtDescription.TabIndex = 2;
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(676, 233);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(55, 23);
            this.lblSearch.TabIndex = 31;
            this.lblSearch.Text = "جستجو:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(737, 233);
            this.txtSearch.MaxLength = 150;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(164, 27);
            this.txtSearch.TabIndex = 30;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 538);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblLicenseNumber);
            this.Controls.Add(this.txtLicenseNumber);
            this.Controls.Add(this.lblDoctorName);
            this.Controls.Add(this.txtDoctorName);
            this.Controls.Add(this.grbDoctorStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.DataGrid);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoctors";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجو و ویرایش اطلاعات پزشکان";
            this.Load += new System.EventHandler(this.frmDoctors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.grbDoctorStatus.ResumeLayout(false);
            this.grbDoctorStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDoctorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnMedicalLicenseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnIsEnabled;
        private System.Windows.Forms.DataGridViewButtonColumn clmnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn clmnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbDoctorStatus;
        private System.Windows.Forms.RadioButton rdbDisable;
        private System.Windows.Forms.RadioButton rdbEnable;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label lblLicenseNumber;
        private System.Windows.Forms.TextBox txtLicenseNumber;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}