
namespace Laboratory.Forms.Employees
{
    partial class frmEmployee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.clmnEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEmployeeInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new Atf.UI.DateTimeSelector();
            this.grbUserStatus = new System.Windows.Forms.GroupBox();
            this.rdbDisable = new System.Windows.Forms.RadioButton();
            this.rdbEnable = new System.Windows.Forms.RadioButton();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.grbUserStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnEmployeeId,
            this.clmnEmployeeName,
            this.clmnUsername,
            this.clmnPhoneNumber,
            this.clmnAddress,
            this.clmnEmployeeInfo,
            this.clmnEdit,
            this.clmnDelete});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle14;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGrid.Location = new System.Drawing.Point(0, 267);
            this.DataGrid.Name = "DataGrid";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DataGrid.RowTemplate.Height = 35;
            this.DataGrid.Size = new System.Drawing.Size(1084, 244);
            this.DataGrid.TabIndex = 1;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            // 
            // clmnEmployeeId
            // 
            this.clmnEmployeeId.DataPropertyName = "EmployeeId";
            this.clmnEmployeeId.HeaderText = "کد کارمند";
            this.clmnEmployeeId.Name = "clmnEmployeeId";
            this.clmnEmployeeId.ReadOnly = true;
            this.clmnEmployeeId.Visible = false;
            // 
            // clmnEmployeeName
            // 
            this.clmnEmployeeName.DataPropertyName = "EmployeeName";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnEmployeeName.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmnEmployeeName.HeaderText = "نام کارمند";
            this.clmnEmployeeName.MinimumWidth = 180;
            this.clmnEmployeeName.Name = "clmnEmployeeName";
            this.clmnEmployeeName.ReadOnly = true;
            this.clmnEmployeeName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnEmployeeName.Width = 180;
            // 
            // clmnUsername
            // 
            this.clmnUsername.DataPropertyName = "Username";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnUsername.DefaultCellStyle = dataGridViewCellStyle13;
            this.clmnUsername.HeaderText = "نام کاربری";
            this.clmnUsername.MinimumWidth = 150;
            this.clmnUsername.Name = "clmnUsername";
            this.clmnUsername.ReadOnly = true;
            this.clmnUsername.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnUsername.Width = 150;
            // 
            // clmnPhoneNumber
            // 
            this.clmnPhoneNumber.DataPropertyName = "PhoneNumber";
            this.clmnPhoneNumber.HeaderText = "تلفن همراه";
            this.clmnPhoneNumber.MaxInputLength = 20;
            this.clmnPhoneNumber.MinimumWidth = 130;
            this.clmnPhoneNumber.Name = "clmnPhoneNumber";
            this.clmnPhoneNumber.ReadOnly = true;
            this.clmnPhoneNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnPhoneNumber.Width = 130;
            // 
            // clmnAddress
            // 
            this.clmnAddress.DataPropertyName = "Address";
            this.clmnAddress.HeaderText = "آدرس";
            this.clmnAddress.MaxInputLength = 400;
            this.clmnAddress.MinimumWidth = 280;
            this.clmnAddress.Name = "clmnAddress";
            this.clmnAddress.ReadOnly = true;
            this.clmnAddress.Width = 280;
            // 
            // clmnEmployeeInfo
            // 
            this.clmnEmployeeInfo.HeaderText = "";
            this.clmnEmployeeInfo.Name = "clmnEmployeeInfo";
            this.clmnEmployeeInfo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnEmployeeInfo.Text = "نمایش جزئیات";
            this.clmnEmployeeInfo.UseColumnTextForButtonValue = true;
            // 
            // clmnEdit
            // 
            this.clmnEdit.HeaderText = "";
            this.clmnEdit.Name = "clmnEdit";
            this.clmnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnEdit.Text = "ویرایش";
            this.clmnEdit.UseColumnTextForButtonValue = true;
            // 
            // clmnDelete
            // 
            this.clmnDelete.HeaderText = "";
            this.clmnDelete.Name = "clmnDelete";
            this.clmnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnDelete.Text = "حذف";
            this.clmnDelete.UseColumnTextForButtonValue = true;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(178, 45);
            this.txtEmployeeName.MaxLength = 150;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(187, 27);
            this.txtEmployeeName.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(523, 45);
            this.txtUsername.MaxLength = 100;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(187, 27);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(178, 91);
            this.txtPhoneNumber.MaxLength = 11;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(187, 27);
            this.txtPhoneNumber.TabIndex = 4;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            this.txtPhoneNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPhoneNumber_KeyUp);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(523, 139);
            this.txtAddress.MaxLength = 500;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(187, 110);
            this.txtAddress.TabIndex = 5;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(523, 91);
            this.txtTel.MaxLength = 11;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(187, 27);
            this.txtTel.TabIndex = 6;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            this.txtTel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTel_KeyUp);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(178, 139);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(187, 28);
            this.dateTimePicker.TabIndex = 7;
            // 
            // grbUserStatus
            // 
            this.grbUserStatus.Controls.Add(this.rdbDisable);
            this.grbUserStatus.Controls.Add(this.rdbEnable);
            this.grbUserStatus.Location = new System.Drawing.Point(749, 45);
            this.grbUserStatus.Name = "grbUserStatus";
            this.grbUserStatus.Size = new System.Drawing.Size(277, 100);
            this.grbUserStatus.TabIndex = 8;
            this.grbUserStatus.TabStop = false;
            this.grbUserStatus.Text = "وضعیت کاربر:";
            // 
            // rdbDisable
            // 
            this.rdbDisable.AutoSize = true;
            this.rdbDisable.Location = new System.Drawing.Point(28, 41);
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
            this.rdbEnable.Location = new System.Drawing.Point(189, 41);
            this.rdbEnable.Name = "rdbEnable";
            this.rdbEnable.Size = new System.Drawing.Size(55, 27);
            this.rdbEnable.TabIndex = 0;
            this.rdbEnable.TabStop = true;
            this.rdbEnable.Text = "فعال";
            this.rdbEnable.UseVisualStyleBackColor = true;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(450, 94);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(67, 23);
            this.lblTel.TabIndex = 9;
            this.lblTel.Text = "تلفن منزل:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(60, 142);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(63, 23);
            this.lblBirthDate.TabIndex = 10;
            this.lblBirthDate.Text = "تاریخ تولد:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(450, 143);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(42, 23);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "آدرس:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(60, 94);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(83, 23);
            this.lblPhoneNumber.TabIndex = 12;
            this.lblPhoneNumber.Text = "شماره همراه:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(450, 48);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 23);
            this.lblUsername.TabIndex = 13;
            this.lblUsername.Text = "نام کاربری:";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(60, 48);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(112, 23);
            this.lblEmployeeName.TabIndex = 14;
            this.lblEmployeeName.Text = "نام و نام خانوادگی:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(749, 212);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 37);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "ثبت تغییرات";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(916, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 37);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "بازگشت";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 231);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(55, 23);
            this.lblSearch.TabIndex = 29;
            this.lblSearch.Text = "جستجو:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(73, 231);
            this.txtSearch.MaxLength = 150;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(164, 27);
            this.txtSearch.TabIndex = 28;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 511);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.grbUserStatus);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.DataGrid);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmployee";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجو و ویرایش اطلاعات کارمندان";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.grbUserStatus.ResumeLayout(false);
            this.grbUserStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTel;
        private Atf.UI.DateTimeSelector dateTimePicker;
        private System.Windows.Forms.GroupBox grbUserStatus;
        private System.Windows.Forms.RadioButton rdbDisable;
        private System.Windows.Forms.RadioButton rdbEnable;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnAddress;
        private System.Windows.Forms.DataGridViewButtonColumn clmnEmployeeInfo;
        private System.Windows.Forms.DataGridViewButtonColumn clmnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn clmnDelete;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}