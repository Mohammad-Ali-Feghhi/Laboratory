
namespace Laboratory.Forms.Tests
{
    partial class frmNewTestParameter
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
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.lblTestName = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.btnAddNewTestParameter = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblSampleType = new System.Windows.Forms.Label();
            this.cmbSampleType = new System.Windows.Forms.ComboBox();
            this.lblTestMethod = new System.Windows.Forms.Label();
            this.cmbTestMethod = new System.Windows.Forms.ComboBox();
            this.lblTestCategory = new System.Windows.Forms.Label();
            this.cmbTestCategory = new System.Windows.Forms.ComboBox();
            this.lblResponseType = new System.Windows.Forms.Label();
            this.cmbResponseType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTestName
            // 
            this.txtTestName.Location = new System.Drawing.Point(164, 42);
            this.txtTestName.MaxLength = 100;
            this.txtTestName.Multiline = true;
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(208, 31);
            this.txtTestName.TabIndex = 0;
            this.txtTestName.WordWrap = false;
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Location = new System.Drawing.Point(47, 42);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(71, 23);
            this.lblTestName.TabIndex = 1;
            this.lblTestName.Text = "نام آزمایش:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(164, 89);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(208, 31);
            this.cmbUnit.TabIndex = 1;
            // 
            // btnAddNewTestParameter
            // 
            this.btnAddNewTestParameter.Location = new System.Drawing.Point(336, 294);
            this.btnAddNewTestParameter.Name = "btnAddNewTestParameter";
            this.btnAddNewTestParameter.Size = new System.Drawing.Size(120, 38);
            this.btnAddNewTestParameter.TabIndex = 7;
            this.btnAddNewTestParameter.Text = "ثبت اطلاعات";
            this.btnAddNewTestParameter.UseVisualStyleBackColor = true;
            this.btnAddNewTestParameter.Click += new System.EventHandler(this.btnAddNewTestParameter_Click);
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(437, 136);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 23);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "توضیحات:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(523, 136);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(208, 78);
            this.txtDescription.TabIndex = 6;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(47, 89);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(98, 23);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "واحد اندازه گیری:";
            // 
            // lblSampleType
            // 
            this.lblSampleType.AutoSize = true;
            this.lblSampleType.Location = new System.Drawing.Point(47, 136);
            this.lblSampleType.Name = "lblSampleType";
            this.lblSampleType.Size = new System.Drawing.Size(64, 23);
            this.lblSampleType.TabIndex = 8;
            this.lblSampleType.Text = "نوع نمونه:";
            // 
            // cmbSampleType
            // 
            this.cmbSampleType.FormattingEnabled = true;
            this.cmbSampleType.Location = new System.Drawing.Point(164, 133);
            this.cmbSampleType.Name = "cmbSampleType";
            this.cmbSampleType.Size = new System.Drawing.Size(208, 31);
            this.cmbSampleType.TabIndex = 2;
            // 
            // lblTestMethod
            // 
            this.lblTestMethod.AutoSize = true;
            this.lblTestMethod.Location = new System.Drawing.Point(47, 183);
            this.lblTestMethod.Name = "lblTestMethod";
            this.lblTestMethod.Size = new System.Drawing.Size(111, 23);
            this.lblTestMethod.TabIndex = 10;
            this.lblTestMethod.Text = "روش انجام آزمایش:";
            // 
            // cmbTestMethod
            // 
            this.cmbTestMethod.FormattingEnabled = true;
            this.cmbTestMethod.Location = new System.Drawing.Point(164, 183);
            this.cmbTestMethod.Name = "cmbTestMethod";
            this.cmbTestMethod.Size = new System.Drawing.Size(208, 31);
            this.cmbTestMethod.TabIndex = 3;
            // 
            // lblTestCategory
            // 
            this.lblTestCategory.AutoSize = true;
            this.lblTestCategory.Location = new System.Drawing.Point(437, 42);
            this.lblTestCategory.Name = "lblTestCategory";
            this.lblTestCategory.Size = new System.Drawing.Size(80, 23);
            this.lblTestCategory.TabIndex = 12;
            this.lblTestCategory.Text = "گروه آزمایش:";
            // 
            // cmbTestCategory
            // 
            this.cmbTestCategory.FormattingEnabled = true;
            this.cmbTestCategory.Location = new System.Drawing.Point(523, 42);
            this.cmbTestCategory.Name = "cmbTestCategory";
            this.cmbTestCategory.Size = new System.Drawing.Size(208, 31);
            this.cmbTestCategory.TabIndex = 4;
            // 
            // lblResponseType
            // 
            this.lblResponseType.AutoSize = true;
            this.lblResponseType.Location = new System.Drawing.Point(437, 89);
            this.lblResponseType.Name = "lblResponseType";
            this.lblResponseType.Size = new System.Drawing.Size(61, 23);
            this.lblResponseType.TabIndex = 14;
            this.lblResponseType.Text = "نوع پاسخ:";
            // 
            // cmbResponseType
            // 
            this.cmbResponseType.FormattingEnabled = true;
            this.cmbResponseType.Location = new System.Drawing.Point(523, 89);
            this.cmbResponseType.Name = "cmbResponseType";
            this.cmbResponseType.Size = new System.Drawing.Size(208, 31);
            this.cmbResponseType.TabIndex = 5;
            // 
            // frmNewTestParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 378);
            this.Controls.Add(this.lblResponseType);
            this.Controls.Add(this.cmbResponseType);
            this.Controls.Add(this.lblTestCategory);
            this.Controls.Add(this.cmbTestCategory);
            this.Controls.Add(this.lblTestMethod);
            this.Controls.Add(this.cmbTestMethod);
            this.Controls.Add(this.lblSampleType);
            this.Controls.Add(this.cmbSampleType);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnAddNewTestParameter);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblTestName);
            this.Controls.Add(this.txtTestName);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewTestParameter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ثبت پارامترهای آزمایش";
            this.Load += new System.EventHandler(this.frmNewTestParameter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Button btnAddNewTestParameter;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblSampleType;
        private System.Windows.Forms.ComboBox cmbSampleType;
        private System.Windows.Forms.Label lblResponseType;
        private System.Windows.Forms.ComboBox cmbResponseType;
        private System.Windows.Forms.Label lblTestCategory;
        private System.Windows.Forms.ComboBox cmbTestCategory;
        private System.Windows.Forms.Label lblTestMethod;
        private System.Windows.Forms.ComboBox cmbTestMethod;
    }
}