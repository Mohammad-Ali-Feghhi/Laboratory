
namespace Laboratory.Forms.Tests
{
    partial class frmNewTest
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
            this.txtSearchPatient = new System.Windows.Forms.TextBox();
            this.btnRegisterTest = new System.Windows.Forms.Button();
            this.lblPatientSearch = new System.Windows.Forms.Label();
            this.DataGrid = new System.Windows.Forms.DataGridView();
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
            this.btnAddNewPatient = new System.Windows.Forms.Button();
            this.lstPatient = new System.Windows.Forms.ListBox();
            this.txtPatientAge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.dtpAcceptionDate = new Atf.UI.DateTimeSelector();
            this.lblAcceptionDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchPatient
            // 
            this.txtSearchPatient.Location = new System.Drawing.Point(105, 12);
            this.txtSearchPatient.MaxLength = 150;
            this.txtSearchPatient.Multiline = true;
            this.txtSearchPatient.Name = "txtSearchPatient";
            this.txtSearchPatient.Size = new System.Drawing.Size(281, 34);
            this.txtSearchPatient.TabIndex = 0;
            this.txtSearchPatient.TextChanged += new System.EventHandler(this.txtSearchPatient_TextChanged);
            // 
            // btnRegisterTest
            // 
            this.btnRegisterTest.Location = new System.Drawing.Point(730, 176);
            this.btnRegisterTest.Name = "btnRegisterTest";
            this.btnRegisterTest.Size = new System.Drawing.Size(115, 37);
            this.btnRegisterTest.TabIndex = 1;
            this.btnRegisterTest.Text = "ثبت آزمایش";
            this.btnRegisterTest.UseVisualStyleBackColor = true;
            this.btnRegisterTest.Visible = false;
            // 
            // lblPatientSearch
            // 
            this.lblPatientSearch.AutoSize = true;
            this.lblPatientSearch.Location = new System.Drawing.Point(12, 12);
            this.lblPatientSearch.Name = "lblPatientSearch";
            this.lblPatientSearch.Size = new System.Drawing.Size(87, 23);
            this.lblPatientSearch.TabIndex = 2;
            this.lblPatientSearch.Text = "جستجو بیمار: ";
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
            this.DataGrid.Location = new System.Drawing.Point(0, 228);
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
            this.DataGrid.Size = new System.Drawing.Size(857, 270);
            this.DataGrid.TabIndex = 9;
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
            // btnAddNewPatient
            // 
            this.btnAddNewPatient.Location = new System.Drawing.Point(392, 12);
            this.btnAddNewPatient.Name = "btnAddNewPatient";
            this.btnAddNewPatient.Size = new System.Drawing.Size(115, 34);
            this.btnAddNewPatient.TabIndex = 10;
            this.btnAddNewPatient.Text = "ثبت بیمار جدید";
            this.btnAddNewPatient.UseVisualStyleBackColor = true;
            this.btnAddNewPatient.Visible = false;
            this.btnAddNewPatient.Click += new System.EventHandler(this.btnAddNewPatient_Click);
            // 
            // lstPatient
            // 
            this.lstPatient.FormattingEnabled = true;
            this.lstPatient.ItemHeight = 23;
            this.lstPatient.Location = new System.Drawing.Point(105, 45);
            this.lstPatient.Name = "lstPatient";
            this.lstPatient.Size = new System.Drawing.Size(281, 165);
            this.lstPatient.TabIndex = 11;
            this.lstPatient.Visible = false;
            this.lstPatient.SelectedIndexChanged += new System.EventHandler(this.lstPatient_SelectedIndexChanged);
            // 
            // txtPatientAge
            // 
            this.txtPatientAge.Location = new System.Drawing.Point(480, 61);
            this.txtPatientAge.MaxLength = 3;
            this.txtPatientAge.Name = "txtPatientAge";
            this.txtPatientAge.ReadOnly = true;
            this.txtPatientAge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPatientAge.Size = new System.Drawing.Size(60, 27);
            this.txtPatientAge.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "سن:";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(589, 115);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(169, 31);
            this.cmbDoctor.TabIndex = 14;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(505, 115);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(78, 23);
            this.lblDoctor.TabIndex = 15;
            this.lblDoctor.Text = "پزشک معالج:";
            // 
            // dtpAcceptionDate
            // 
            this.dtpAcceptionDate.Location = new System.Drawing.Point(653, 45);
            this.dtpAcceptionDate.Name = "dtpAcceptionDate";
            this.dtpAcceptionDate.Size = new System.Drawing.Size(169, 28);
            this.dtpAcceptionDate.TabIndex = 16;
            // 
            // lblAcceptionDate
            // 
            this.lblAcceptionDate.AutoSize = true;
            this.lblAcceptionDate.Location = new System.Drawing.Point(571, 45);
            this.lblAcceptionDate.Name = "lblAcceptionDate";
            this.lblAcceptionDate.Size = new System.Drawing.Size(76, 23);
            this.lblAcceptionDate.TabIndex = 17;
            this.lblAcceptionDate.Text = "تاریخ پذیرش:";
            // 
            // frmNewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 498);
            this.Controls.Add(this.lblAcceptionDate);
            this.Controls.Add(this.dtpAcceptionDate);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatientAge);
            this.Controls.Add(this.lstPatient);
            this.Controls.Add(this.btnAddNewPatient);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.lblPatientSearch);
            this.Controls.Add(this.btnRegisterTest);
            this.Controls.Add(this.txtSearchPatient);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewTest";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ثبت آزمایش جدید";
            this.Load += new System.EventHandler(this.frmNewTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchPatient;
        private System.Windows.Forms.Button btnRegisterTest;
        private System.Windows.Forms.Label lblPatientSearch;
        private System.Windows.Forms.DataGridView DataGrid;
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
        private System.Windows.Forms.Button btnAddNewPatient;
        private System.Windows.Forms.ListBox lstPatient;
        private System.Windows.Forms.TextBox txtPatientAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private Atf.UI.DateTimeSelector dtpAcceptionDate;
        private System.Windows.Forms.Label lblAcceptionDate;
    }
}