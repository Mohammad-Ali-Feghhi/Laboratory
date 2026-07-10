
namespace Laboratory.Forms.Patients
{
    partial class frmPatientTestAcceptionList
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
            this.clmnTestAcceptionHeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDoctorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnRegistrationEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnRegistrationEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnAcceptionDatePersianDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnShowTest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.clmnTestAcceptionHeaderId,
            this.clmnDoctorId,
            this.clmnRegistrationEmployeeId,
            this.clmnDoctorName,
            this.clmnRegistrationEmployeeName,
            this.clmnAcceptionDatePersianDateTime,
            this.clmnShowTest,
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
            this.DataGrid.Size = new System.Drawing.Size(793, 467);
            this.DataGrid.TabIndex = 9;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            // 
            // clmnTestAcceptionHeaderId
            // 
            this.clmnTestAcceptionHeaderId.DataPropertyName = "TestAcceptionHeaderId";
            this.clmnTestAcceptionHeaderId.HeaderText = "کد آزمایش";
            this.clmnTestAcceptionHeaderId.Name = "clmnTestAcceptionHeaderId";
            this.clmnTestAcceptionHeaderId.ReadOnly = true;
            this.clmnTestAcceptionHeaderId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnTestAcceptionHeaderId.Visible = false;
            // 
            // clmnDoctorId
            // 
            this.clmnDoctorId.DataPropertyName = "DoctorId";
            this.clmnDoctorId.HeaderText = "کد دکتر";
            this.clmnDoctorId.Name = "clmnDoctorId";
            this.clmnDoctorId.ReadOnly = true;
            this.clmnDoctorId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnDoctorId.Visible = false;
            // 
            // clmnRegistrationEmployeeId
            // 
            this.clmnRegistrationEmployeeId.DataPropertyName = "RegistrationEmployeeId";
            this.clmnRegistrationEmployeeId.HeaderText = "کد کارمند";
            this.clmnRegistrationEmployeeId.Name = "clmnRegistrationEmployeeId";
            this.clmnRegistrationEmployeeId.ReadOnly = true;
            this.clmnRegistrationEmployeeId.Visible = false;
            // 
            // clmnDoctorName
            // 
            this.clmnDoctorName.DataPropertyName = "DoctorName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnDoctorName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmnDoctorName.HeaderText = "نام دکتر";
            this.clmnDoctorName.MaxInputLength = 150;
            this.clmnDoctorName.MinimumWidth = 160;
            this.clmnDoctorName.Name = "clmnDoctorName";
            this.clmnDoctorName.ReadOnly = true;
            this.clmnDoctorName.Width = 160;
            // 
            // clmnRegistrationEmployeeName
            // 
            this.clmnRegistrationEmployeeName.DataPropertyName = "RegistrationEmployeeName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnRegistrationEmployeeName.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmnRegistrationEmployeeName.HeaderText = "نام کاربر ثبت کننده";
            this.clmnRegistrationEmployeeName.MaxInputLength = 100;
            this.clmnRegistrationEmployeeName.MinimumWidth = 160;
            this.clmnRegistrationEmployeeName.Name = "clmnRegistrationEmployeeName";
            this.clmnRegistrationEmployeeName.ReadOnly = true;
            this.clmnRegistrationEmployeeName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnRegistrationEmployeeName.Width = 160;
            // 
            // clmnAcceptionDatePersianDateTime
            // 
            this.clmnAcceptionDatePersianDateTime.DataPropertyName = "AcceptionDatePersianDateTime";
            this.clmnAcceptionDatePersianDateTime.HeaderText = "تاریخ ثبت آزمایش";
            this.clmnAcceptionDatePersianDateTime.MaxInputLength = 20;
            this.clmnAcceptionDatePersianDateTime.MinimumWidth = 130;
            this.clmnAcceptionDatePersianDateTime.Name = "clmnAcceptionDatePersianDateTime";
            this.clmnAcceptionDatePersianDateTime.ReadOnly = true;
            this.clmnAcceptionDatePersianDateTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnAcceptionDatePersianDateTime.Width = 130;
            // 
            // clmnShowTest
            // 
            this.clmnShowTest.HeaderText = "";
            this.clmnShowTest.Name = "clmnShowTest";
            this.clmnShowTest.Text = "نمایش آزمایش";
            this.clmnShowTest.UseColumnTextForButtonValue = true;
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
            // frmPatientTestAcceptionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 467);
            this.Controls.Add(this.DataGrid);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientTestAcceptionList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم لیست آزمایش‌ها";
            this.Load += new System.EventHandler(this.frmPatientTestAcceptionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTestAcceptionHeaderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDoctorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnRegistrationEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnRegistrationEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnAcceptionDatePersianDateTime;
        private System.Windows.Forms.DataGridViewButtonColumn clmnShowTest;
        private System.Windows.Forms.DataGridViewButtonColumn clmnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn clmnDelete;
    }
}