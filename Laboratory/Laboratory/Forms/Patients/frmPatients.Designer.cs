
namespace Laboratory.Forms.Patients
{
    partial class frmPatients
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblNationalCode = new System.Windows.Forms.Label();
            this.txtNationalCode = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeSelector = new Atf.UI.DateTimeSelector();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.clmnPatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnNationalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnShowInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnAddNewTest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnTestList = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(483, 33);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 23);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "توضیحات:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(554, 33);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(261, 155);
            this.txtDescription.TabIndex = 4;
            // 
            // lblNationalCode
            // 
            this.lblNationalCode.AutoSize = true;
            this.lblNationalCode.Location = new System.Drawing.Point(108, 78);
            this.lblNationalCode.Name = "lblNationalCode";
            this.lblNationalCode.Size = new System.Drawing.Size(51, 23);
            this.lblNationalCode.TabIndex = 20;
            this.lblNationalCode.Text = "کد ملی:";
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.Location = new System.Drawing.Point(188, 78);
            this.txtNationalCode.MaxLength = 10;
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.Size = new System.Drawing.Size(222, 27);
            this.txtNationalCode.TabIndex = 1;
            this.txtNationalCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNationalCode_KeyPress);
            this.txtNationalCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNationalCode_KeyUp);
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(108, 33);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(59, 23);
            this.lblPatientName.TabIndex = 19;
            this.lblPatientName.Text = "نام بیمار:";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(188, 33);
            this.txtPatientName.MaxLength = 150;
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(222, 27);
            this.txtPatientName.TabIndex = 0;
            this.txtPatientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientName_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(703, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "بازگشت";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(554, 205);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 33);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "ثبت تغییرات";
            this.btnUpdate.UseVisualStyleBackColor = true;
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
            this.clmnPatientId,
            this.clmnPatientName,
            this.clmnNationalCode,
            this.clmnMobile,
            this.clmnBirthDate,
            this.clmnShowInfo,
            this.clmnAddNewTest,
            this.clmnTestList,
            this.clmnEdit,
            this.clmnDelete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGrid.Location = new System.Drawing.Point(0, 288);
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
            this.DataGrid.Size = new System.Drawing.Size(1013, 270);
            this.DataGrid.TabIndex = 8;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(108, 124);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(74, 23);
            this.lblMobile.TabIndex = 23;
            this.lblMobile.Text = "تلفن همراه:";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(188, 124);
            this.txtMobile.MaxLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(222, 27);
            this.txtMobile.TabIndex = 2;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            this.txtMobile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMobile_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "تاریخ تولد:";
            // 
            // dateTimeSelector
            // 
            this.dateTimeSelector.Location = new System.Drawing.Point(188, 170);
            this.dateTimeSelector.Name = "dateTimeSelector";
            this.dateTimeSelector.Size = new System.Drawing.Size(222, 28);
            this.dateTimeSelector.TabIndex = 3;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 251);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(55, 23);
            this.lblSearch.TabIndex = 27;
            this.lblSearch.Text = "جستجو:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(73, 251);
            this.txtSearch.MaxLength = 150;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(164, 27);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // clmnPatientId
            // 
            this.clmnPatientId.DataPropertyName = "PatientId";
            this.clmnPatientId.HeaderText = "کد بیمار";
            this.clmnPatientId.Name = "clmnPatientId";
            this.clmnPatientId.ReadOnly = true;
            this.clmnPatientId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnPatientId.Visible = false;
            // 
            // clmnPatientName
            // 
            this.clmnPatientName.DataPropertyName = "PatientName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnPatientName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmnPatientName.HeaderText = "نام بیمار";
            this.clmnPatientName.MaxInputLength = 150;
            this.clmnPatientName.MinimumWidth = 200;
            this.clmnPatientName.Name = "clmnPatientName";
            this.clmnPatientName.ReadOnly = true;
            this.clmnPatientName.Width = 200;
            // 
            // clmnNationalCode
            // 
            this.clmnNationalCode.DataPropertyName = "NationalCode";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnNationalCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmnNationalCode.HeaderText = "کد ملی";
            this.clmnNationalCode.MaxInputLength = 100;
            this.clmnNationalCode.MinimumWidth = 135;
            this.clmnNationalCode.Name = "clmnNationalCode";
            this.clmnNationalCode.ReadOnly = true;
            this.clmnNationalCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnNationalCode.Width = 135;
            // 
            // clmnMobile
            // 
            this.clmnMobile.DataPropertyName = "Mobile";
            this.clmnMobile.HeaderText = "تلفن همراه";
            this.clmnMobile.MaxInputLength = 20;
            this.clmnMobile.MinimumWidth = 135;
            this.clmnMobile.Name = "clmnMobile";
            this.clmnMobile.ReadOnly = true;
            this.clmnMobile.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnMobile.Width = 135;
            // 
            // clmnBirthDate
            // 
            this.clmnBirthDate.DataPropertyName = "BirthDate";
            this.clmnBirthDate.HeaderText = "تاریخ تولد";
            this.clmnBirthDate.Name = "clmnBirthDate";
            this.clmnBirthDate.ReadOnly = true;
            this.clmnBirthDate.Visible = false;
            // 
            // clmnShowInfo
            // 
            this.clmnShowInfo.HeaderText = "";
            this.clmnShowInfo.Name = "clmnShowInfo";
            this.clmnShowInfo.Text = "نمایش اطلاعات";
            this.clmnShowInfo.UseColumnTextForButtonValue = true;
            // 
            // clmnAddNewTest
            // 
            this.clmnAddNewTest.HeaderText = "";
            this.clmnAddNewTest.MinimumWidth = 120;
            this.clmnAddNewTest.Name = "clmnAddNewTest";
            this.clmnAddNewTest.Text = "ثبت آزمایش جدید";
            this.clmnAddNewTest.UseColumnTextForButtonValue = true;
            this.clmnAddNewTest.Width = 120;
            // 
            // clmnTestList
            // 
            this.clmnTestList.HeaderText = "";
            this.clmnTestList.Name = "clmnTestList";
            this.clmnTestList.Text = "لیست آزمایش‌ها";
            this.clmnTestList.UseColumnTextForButtonValue = true;
            // 
            // clmnEdit
            // 
            this.clmnEdit.HeaderText = "";
            this.clmnEdit.Name = "clmnEdit";
            this.clmnEdit.Text = "ویرایش";
            this.clmnEdit.UseColumnTextForButtonValue = true;
            this.clmnEdit.Width = 90;
            // 
            // clmnDelete
            // 
            this.clmnDelete.HeaderText = "";
            this.clmnDelete.Name = "clmnDelete";
            this.clmnDelete.Text = "حذف";
            this.clmnDelete.UseColumnTextForButtonValue = true;
            this.clmnDelete.Width = 90;
            // 
            // frmPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 558);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dateTimeSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblNationalCode);
            this.Controls.Add(this.txtNationalCode);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.DataGrid);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatients";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم جستجو و ویرایش اطلاعات بیمار";
            this.Load += new System.EventHandler(this.frmPatients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblNationalCode;
        private System.Windows.Forms.TextBox txtNationalCode;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label2;
        private Atf.UI.DateTimeSelector dateTimeSelector;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNationalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnBirthDate;
        private System.Windows.Forms.DataGridViewButtonColumn clmnShowInfo;
        private System.Windows.Forms.DataGridViewButtonColumn clmnAddNewTest;
        private System.Windows.Forms.DataGridViewButtonColumn clmnTestList;
        private System.Windows.Forms.DataGridViewButtonColumn clmnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn clmnDelete;
    }
}