
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearchPatient = new System.Windows.Forms.TextBox();
            this.btnTestAcceptionHeader = new System.Windows.Forms.Button();
            this.lblPatientSearch = new System.Windows.Forms.Label();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.clmnTempId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTestAcceptionHeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTestMethodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnMethodTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.grbBaseInfo = new System.Windows.Forms.GroupBox();
            this.txtTestAcceptionHeaderId = new System.Windows.Forms.TextBox();
            this.lblTestAcceptionHeaderId = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbTestParameters = new System.Windows.Forms.GroupBox();
            this.lstTestParameter = new System.Windows.Forms.ListBox();
            this.txtSearchTestParameter = new System.Windows.Forms.TextBox();
            this.lblSearchTestParameter = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtTestMethod = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddParameters = new System.Windows.Forms.Button();
            this.btnAddTestAcceptionItem = new System.Windows.Forms.Button();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblTestMethod = new System.Windows.Forms.Label();
            this.cmbTestMethod = new System.Windows.Forms.ComboBox();
            this.err2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.grbBaseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.grbTestParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchPatient
            // 
            this.txtSearchPatient.Location = new System.Drawing.Point(436, 36);
            this.txtSearchPatient.MaxLength = 150;
            this.txtSearchPatient.Multiline = true;
            this.txtSearchPatient.Name = "txtSearchPatient";
            this.txtSearchPatient.Size = new System.Drawing.Size(281, 31);
            this.txtSearchPatient.TabIndex = 0;
            this.txtSearchPatient.TextChanged += new System.EventHandler(this.txtSearchPatient_TextChanged);
            // 
            // btnTestAcceptionHeader
            // 
            this.btnTestAcceptionHeader.Location = new System.Drawing.Point(306, 36);
            this.btnTestAcceptionHeader.Name = "btnTestAcceptionHeader";
            this.btnTestAcceptionHeader.Size = new System.Drawing.Size(115, 31);
            this.btnTestAcceptionHeader.TabIndex = 1;
            this.btnTestAcceptionHeader.Text = "ثبت آزمایش";
            this.btnTestAcceptionHeader.UseVisualStyleBackColor = true;
            this.btnTestAcceptionHeader.Visible = false;
            this.btnTestAcceptionHeader.Click += new System.EventHandler(this.btnTestAcceptionHeader_Click);
            // 
            // lblPatientSearch
            // 
            this.lblPatientSearch.AutoSize = true;
            this.lblPatientSearch.Location = new System.Drawing.Point(723, 36);
            this.lblPatientSearch.Name = "lblPatientSearch";
            this.lblPatientSearch.Size = new System.Drawing.Size(86, 21);
            this.lblPatientSearch.TabIndex = 2;
            this.lblPatientSearch.Text = "جستجو بیمار: ";
            // 
            // DataGrid
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnTempId,
            this.clmnTestAcceptionHeaderId,
            this.clmnTestId,
            this.clmnTestName,
            this.clmnTestMethodId,
            this.clmnMethodTestName,
            this.clmnUnitId,
            this.clmnUnitName,
            this.clmnEdit,
            this.clmnDelete});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle24;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGrid.Location = new System.Drawing.Point(3, 127);
            this.DataGrid.Name = "DataGrid";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.DataGrid.RowTemplate.Height = 35;
            this.DataGrid.Size = new System.Drawing.Size(843, 226);
            this.DataGrid.TabIndex = 9;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            // 
            // clmnTempId
            // 
            this.clmnTempId.DataPropertyName = "TempId";
            this.clmnTempId.HeaderText = "شناسه موقت";
            this.clmnTempId.Name = "clmnTempId";
            this.clmnTempId.ReadOnly = true;
            this.clmnTempId.Visible = false;
            // 
            // clmnTestAcceptionHeaderId
            // 
            this.clmnTestAcceptionHeaderId.DataPropertyName = "TestAcceptionHeaderId";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnTestAcceptionHeaderId.DefaultCellStyle = dataGridViewCellStyle22;
            this.clmnTestAcceptionHeaderId.HeaderText = "کد سر تست پذیرش";
            this.clmnTestAcceptionHeaderId.MaxInputLength = 150;
            this.clmnTestAcceptionHeaderId.MinimumWidth = 200;
            this.clmnTestAcceptionHeaderId.Name = "clmnTestAcceptionHeaderId";
            this.clmnTestAcceptionHeaderId.ReadOnly = true;
            this.clmnTestAcceptionHeaderId.Visible = false;
            this.clmnTestAcceptionHeaderId.Width = 200;
            // 
            // clmnTestId
            // 
            this.clmnTestId.DataPropertyName = "TestId";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnTestId.DefaultCellStyle = dataGridViewCellStyle23;
            this.clmnTestId.HeaderText = "کد آزمایش";
            this.clmnTestId.MaxInputLength = 100;
            this.clmnTestId.MinimumWidth = 135;
            this.clmnTestId.Name = "clmnTestId";
            this.clmnTestId.ReadOnly = true;
            this.clmnTestId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnTestId.Visible = false;
            this.clmnTestId.Width = 135;
            // 
            // clmnTestName
            // 
            this.clmnTestName.DataPropertyName = "TestName";
            this.clmnTestName.HeaderText = "نام آزمایش";
            this.clmnTestName.MinimumWidth = 270;
            this.clmnTestName.Name = "clmnTestName";
            this.clmnTestName.ReadOnly = true;
            this.clmnTestName.Width = 270;
            // 
            // clmnTestMethodId
            // 
            this.clmnTestMethodId.DataPropertyName = "TestMethodId";
            this.clmnTestMethodId.HeaderText = "کد متد تست";
            this.clmnTestMethodId.MaxInputLength = 20;
            this.clmnTestMethodId.MinimumWidth = 135;
            this.clmnTestMethodId.Name = "clmnTestMethodId";
            this.clmnTestMethodId.ReadOnly = true;
            this.clmnTestMethodId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnTestMethodId.Visible = false;
            this.clmnTestMethodId.Width = 135;
            // 
            // clmnMethodTestName
            // 
            this.clmnMethodTestName.DataPropertyName = "TestMethodName";
            this.clmnMethodTestName.HeaderText = "روش آزمایش";
            this.clmnMethodTestName.MinimumWidth = 210;
            this.clmnMethodTestName.Name = "clmnMethodTestName";
            this.clmnMethodTestName.ReadOnly = true;
            this.clmnMethodTestName.Width = 210;
            // 
            // clmnUnitId
            // 
            this.clmnUnitId.DataPropertyName = "UnitId";
            this.clmnUnitId.HeaderText = "کد واحد تست";
            this.clmnUnitId.Name = "clmnUnitId";
            this.clmnUnitId.ReadOnly = true;
            this.clmnUnitId.Visible = false;
            // 
            // clmnUnitName
            // 
            this.clmnUnitName.DataPropertyName = "UnitName";
            this.clmnUnitName.HeaderText = "واحد اندازه‌گیری";
            this.clmnUnitName.MinimumWidth = 140;
            this.clmnUnitName.Name = "clmnUnitName";
            this.clmnUnitName.ReadOnly = true;
            this.clmnUnitName.Width = 140;
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
            this.btnAddNewPatient.Location = new System.Drawing.Point(306, 36);
            this.btnAddNewPatient.Name = "btnAddNewPatient";
            this.btnAddNewPatient.Size = new System.Drawing.Size(115, 31);
            this.btnAddNewPatient.TabIndex = 10;
            this.btnAddNewPatient.Text = "ثبت بیمار جدید";
            this.btnAddNewPatient.UseVisualStyleBackColor = true;
            this.btnAddNewPatient.Visible = false;
            this.btnAddNewPatient.Click += new System.EventHandler(this.btnAddNewPatient_Click);
            // 
            // lstPatient
            // 
            this.lstPatient.FormattingEnabled = true;
            this.lstPatient.ItemHeight = 21;
            this.lstPatient.Location = new System.Drawing.Point(436, 66);
            this.lstPatient.Name = "lstPatient";
            this.lstPatient.Size = new System.Drawing.Size(281, 130);
            this.lstPatient.TabIndex = 11;
            this.lstPatient.Visible = false;
            this.lstPatient.SelectedIndexChanged += new System.EventHandler(this.lstPatient_SelectedIndexChanged);
            // 
            // txtPatientAge
            // 
            this.txtPatientAge.Location = new System.Drawing.Point(574, 83);
            this.txtPatientAge.MaxLength = 3;
            this.txtPatientAge.Name = "txtPatientAge";
            this.txtPatientAge.ReadOnly = true;
            this.txtPatientAge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPatientAge.Size = new System.Drawing.Size(143, 28);
            this.txtPatientAge.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(776, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "سن:";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(574, 163);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(143, 29);
            this.cmbDoctor.TabIndex = 14;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(732, 163);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(80, 21);
            this.lblDoctor.TabIndex = 15;
            this.lblDoctor.Text = "پزشک معالج:";
            // 
            // dtpAcceptionDate
            // 
            this.dtpAcceptionDate.Location = new System.Drawing.Point(574, 122);
            this.dtpAcceptionDate.Name = "dtpAcceptionDate";
            this.dtpAcceptionDate.Size = new System.Drawing.Size(143, 29);
            this.dtpAcceptionDate.TabIndex = 16;
            // 
            // lblAcceptionDate
            // 
            this.lblAcceptionDate.AutoSize = true;
            this.lblAcceptionDate.Location = new System.Drawing.Point(734, 122);
            this.lblAcceptionDate.Name = "lblAcceptionDate";
            this.lblAcceptionDate.Size = new System.Drawing.Size(81, 21);
            this.lblAcceptionDate.TabIndex = 17;
            this.lblAcceptionDate.Text = "تاریخ پذیرش:";
            // 
            // grbBaseInfo
            // 
            this.grbBaseInfo.Controls.Add(this.lstPatient);
            this.grbBaseInfo.Controls.Add(this.txtTestAcceptionHeaderId);
            this.grbBaseInfo.Controls.Add(this.lblTestAcceptionHeaderId);
            this.grbBaseInfo.Controls.Add(this.btnAddNewPatient);
            this.grbBaseInfo.Controls.Add(this.lblPatientSearch);
            this.grbBaseInfo.Controls.Add(this.txtPatientAge);
            this.grbBaseInfo.Controls.Add(this.txtSearchPatient);
            this.grbBaseInfo.Controls.Add(this.lblDoctor);
            this.grbBaseInfo.Controls.Add(this.lblAcceptionDate);
            this.grbBaseInfo.Controls.Add(this.cmbDoctor);
            this.grbBaseInfo.Controls.Add(this.label1);
            this.grbBaseInfo.Controls.Add(this.btnTestAcceptionHeader);
            this.grbBaseInfo.Controls.Add(this.dtpAcceptionDate);
            this.grbBaseInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbBaseInfo.Location = new System.Drawing.Point(0, 0);
            this.grbBaseInfo.Name = "grbBaseInfo";
            this.grbBaseInfo.Size = new System.Drawing.Size(849, 215);
            this.grbBaseInfo.TabIndex = 18;
            this.grbBaseInfo.TabStop = false;
            this.grbBaseInfo.Text = "اطلاعات پایه";
            // 
            // txtTestAcceptionHeaderId
            // 
            this.txtTestAcceptionHeaderId.Location = new System.Drawing.Point(41, 42);
            this.txtTestAcceptionHeaderId.MaxLength = 3;
            this.txtTestAcceptionHeaderId.Name = "txtTestAcceptionHeaderId";
            this.txtTestAcceptionHeaderId.ReadOnly = true;
            this.txtTestAcceptionHeaderId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTestAcceptionHeaderId.Size = new System.Drawing.Size(143, 28);
            this.txtTestAcceptionHeaderId.TabIndex = 18;
            // 
            // lblTestAcceptionHeaderId
            // 
            this.lblTestAcceptionHeaderId.AutoSize = true;
            this.lblTestAcceptionHeaderId.Location = new System.Drawing.Point(190, 42);
            this.lblTestAcceptionHeaderId.Name = "lblTestAcceptionHeaderId";
            this.lblTestAcceptionHeaderId.Size = new System.Drawing.Size(81, 21);
            this.lblTestAcceptionHeaderId.TabIndex = 19;
            this.lblTestAcceptionHeaderId.Text = "شماه پذیرش:";
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            this.err.RightToLeft = true;
            // 
            // grbTestParameters
            // 
            this.grbTestParameters.Controls.Add(this.lstTestParameter);
            this.grbTestParameters.Controls.Add(this.txtSearchTestParameter);
            this.grbTestParameters.Controls.Add(this.lblSearchTestParameter);
            this.grbTestParameters.Controls.Add(this.DataGrid);
            this.grbTestParameters.Controls.Add(this.txtUnit);
            this.grbTestParameters.Controls.Add(this.txtTestMethod);
            this.grbTestParameters.Controls.Add(this.btnCancel);
            this.grbTestParameters.Controls.Add(this.btnAddParameters);
            this.grbTestParameters.Controls.Add(this.btnAddTestAcceptionItem);
            this.grbTestParameters.Controls.Add(this.lblUnit);
            this.grbTestParameters.Controls.Add(this.cmbUnit);
            this.grbTestParameters.Controls.Add(this.lblTestMethod);
            this.grbTestParameters.Controls.Add(this.cmbTestMethod);
            this.grbTestParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTestParameters.Enabled = false;
            this.grbTestParameters.Location = new System.Drawing.Point(0, 215);
            this.grbTestParameters.Name = "grbTestParameters";
            this.grbTestParameters.Size = new System.Drawing.Size(849, 356);
            this.grbTestParameters.TabIndex = 19;
            this.grbTestParameters.TabStop = false;
            this.grbTestParameters.Text = "پارامترهای آزمایش";
            // 
            // lstTestParameter
            // 
            this.lstTestParameter.FormattingEnabled = true;
            this.lstTestParameter.ItemHeight = 21;
            this.lstTestParameter.Location = new System.Drawing.Point(237, 54);
            this.lstTestParameter.Name = "lstTestParameter";
            this.lstTestParameter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstTestParameter.Size = new System.Drawing.Size(336, 130);
            this.lstTestParameter.TabIndex = 22;
            this.lstTestParameter.Visible = false;
            this.lstTestParameter.SelectedIndexChanged += new System.EventHandler(this.lstTestParameter_SelectedIndexChanged);
            // 
            // txtSearchTestParameter
            // 
            this.txtSearchTestParameter.Location = new System.Drawing.Point(237, 24);
            this.txtSearchTestParameter.MaxLength = 150;
            this.txtSearchTestParameter.Multiline = true;
            this.txtSearchTestParameter.Name = "txtSearchTestParameter";
            this.txtSearchTestParameter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearchTestParameter.Size = new System.Drawing.Size(336, 31);
            this.txtSearchTestParameter.TabIndex = 20;
            this.txtSearchTestParameter.TextChanged += new System.EventHandler(this.txtSearchTestParameter_TextChanged);
            // 
            // lblSearchTestParameter
            // 
            this.lblSearchTestParameter.AutoSize = true;
            this.lblSearchTestParameter.Location = new System.Drawing.Point(579, 24);
            this.lblSearchTestParameter.Name = "lblSearchTestParameter";
            this.lblSearchTestParameter.Size = new System.Drawing.Size(90, 21);
            this.lblSearchTestParameter.TabIndex = 21;
            this.lblSearchTestParameter.Text = "جستجو پارامتر:";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(200, 90);
            this.txtUnit.Multiline = true;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnit.Size = new System.Drawing.Size(158, 29);
            this.txtUnit.TabIndex = 36;
            // 
            // txtTestMethod
            // 
            this.txtTestMethod.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTestMethod.Location = new System.Drawing.Point(485, 90);
            this.txtTestMethod.Multiline = true;
            this.txtTestMethod.Name = "txtTestMethod";
            this.txtTestMethod.ReadOnly = true;
            this.txtTestMethod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTestMethod.Size = new System.Drawing.Size(197, 29);
            this.txtTestMethod.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(23, 54);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 31);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "بازگشت";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddParameters
            // 
            this.btnAddParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddParameters.ForeColor = System.Drawing.Color.White;
            this.btnAddParameters.Location = new System.Drawing.Point(23, 91);
            this.btnAddParameters.Name = "btnAddParameters";
            this.btnAddParameters.Size = new System.Drawing.Size(115, 31);
            this.btnAddParameters.TabIndex = 32;
            this.btnAddParameters.Text = "ثبت نهایی";
            this.btnAddParameters.UseVisualStyleBackColor = true;
            this.btnAddParameters.Click += new System.EventHandler(this.btnAddParameters_Click);
            // 
            // btnAddTestAcceptionItem
            // 
            this.btnAddTestAcceptionItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTestAcceptionItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTestAcceptionItem.ForeColor = System.Drawing.Color.White;
            this.btnAddTestAcceptionItem.Location = new System.Drawing.Point(23, 17);
            this.btnAddTestAcceptionItem.Name = "btnAddTestAcceptionItem";
            this.btnAddTestAcceptionItem.Size = new System.Drawing.Size(115, 31);
            this.btnAddTestAcceptionItem.TabIndex = 20;
            this.btnAddTestAcceptionItem.Text = "افزودن پارامتر";
            this.btnAddTestAcceptionItem.UseVisualStyleBackColor = true;
            this.btnAddTestAcceptionItem.Click += new System.EventHandler(this.btnAddTestAcceptionItem_Click);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(364, 90);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(96, 21);
            this.lblUnit.TabIndex = 26;
            this.lblUnit.Text = "واحد اندازه‌گیری:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(210, 90);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(148, 29);
            this.cmbUnit.TabIndex = 25;
            // 
            // lblTestMethod
            // 
            this.lblTestMethod.AutoSize = true;
            this.lblTestMethod.Location = new System.Drawing.Point(688, 90);
            this.lblTestMethod.Name = "lblTestMethod";
            this.lblTestMethod.Size = new System.Drawing.Size(116, 21);
            this.lblTestMethod.TabIndex = 24;
            this.lblTestMethod.Text = "روش انجام آزمایش:";
            // 
            // cmbTestMethod
            // 
            this.cmbTestMethod.FormattingEnabled = true;
            this.cmbTestMethod.Location = new System.Drawing.Point(512, 90);
            this.cmbTestMethod.Name = "cmbTestMethod";
            this.cmbTestMethod.Size = new System.Drawing.Size(170, 29);
            this.cmbTestMethod.TabIndex = 23;
            // 
            // err2
            // 
            this.err2.BlinkRate = 500;
            this.err2.ContainerControl = this;
            this.err2.RightToLeft = true;
            // 
            // frmNewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 571);
            this.Controls.Add(this.grbTestParameters);
            this.Controls.Add(this.grbBaseInfo);
            this.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
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
            this.grbBaseInfo.ResumeLayout(false);
            this.grbBaseInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.grbTestParameters.ResumeLayout(false);
            this.grbTestParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchPatient;
        private System.Windows.Forms.Button btnTestAcceptionHeader;
        private System.Windows.Forms.Label lblPatientSearch;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button btnAddNewPatient;
        private System.Windows.Forms.ListBox lstPatient;
        private System.Windows.Forms.TextBox txtPatientAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private Atf.UI.DateTimeSelector dtpAcceptionDate;
        private System.Windows.Forms.Label lblAcceptionDate;
        private System.Windows.Forms.GroupBox grbBaseInfo;
        private System.Windows.Forms.TextBox txtTestAcceptionHeaderId;
        private System.Windows.Forms.Label lblTestAcceptionHeaderId;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.GroupBox grbTestParameters;
        private System.Windows.Forms.ListBox lstTestParameter;
        private System.Windows.Forms.Label lblSearchTestParameter;
        private System.Windows.Forms.TextBox txtSearchTestParameter;
        private System.Windows.Forms.ComboBox cmbTestMethod;
        private System.Windows.Forms.Label lblTestMethod;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddParameters;
        private System.Windows.Forms.Button btnAddTestAcceptionItem;
        private System.Windows.Forms.ErrorProvider err2;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtTestMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTempId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTestAcceptionHeaderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTestMethodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnMethodTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnUnitName;
        private System.Windows.Forms.DataGridViewButtonColumn clmnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn clmnDelete;
    }
}