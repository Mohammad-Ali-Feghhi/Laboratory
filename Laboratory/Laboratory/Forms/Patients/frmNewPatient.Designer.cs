
namespace Laboratory.Forms.Patients
{
    partial class frmNewPatient
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
            this.lblPatientName = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtNationalCode = new System.Windows.Forms.TextBox();
            this.lblNationalCode = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.dateTimeSelector = new Atf.UI.DateTimeSelector();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(49, 23);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(59, 23);
            this.lblPatientName.TabIndex = 1;
            this.lblPatientName.Text = "نام بیمار:";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(166, 313);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(110, 37);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "ثبت اطلاعات";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(129, 23);
            this.txtPatientName.MaxLength = 100;
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(187, 27);
            this.txtPatientName.TabIndex = 0;
            this.txtPatientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientName_KeyPress);
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.Location = new System.Drawing.Point(129, 61);
            this.txtNationalCode.MaxLength = 10;
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.Size = new System.Drawing.Size(187, 27);
            this.txtNationalCode.TabIndex = 1;
            this.txtNationalCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNationalCode_KeyPress);
            this.txtNationalCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNationalCode_KeyUp);
            // 
            // lblNationalCode
            // 
            this.lblNationalCode.AutoSize = true;
            this.lblNationalCode.Location = new System.Drawing.Point(49, 61);
            this.lblNationalCode.Name = "lblNationalCode";
            this.lblNationalCode.Size = new System.Drawing.Size(51, 23);
            this.lblNationalCode.TabIndex = 18;
            this.lblNationalCode.Text = "کد ملی:";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(129, 140);
            this.txtMobile.MaxLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(187, 27);
            this.txtMobile.TabIndex = 3;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            this.txtMobile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMobile_KeyUp);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(49, 140);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(74, 23);
            this.lblMobile.TabIndex = 20;
            this.lblMobile.Text = "تلفن همراه:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(129, 179);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(187, 122);
            this.txtDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(49, 179);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 23);
            this.lblDescription.TabIndex = 22;
            this.lblDescription.Text = "توضیحات:";
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(49, 100);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(63, 23);
            this.lblBirthDate.TabIndex = 23;
            this.lblBirthDate.Text = "تاریخ تولد:";
            // 
            // dateTimeSelector
            // 
            this.dateTimeSelector.Location = new System.Drawing.Point(129, 100);
            this.dateTimeSelector.Name = "dateTimeSelector";
            this.dateTimeSelector.Size = new System.Drawing.Size(187, 28);
            this.dateTimeSelector.TabIndex = 2;
            // 
            // frmNewPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 363);
            this.Controls.Add(this.dateTimeSelector);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.txtNationalCode);
            this.Controls.Add(this.lblNationalCode);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lblPatientName);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewPatient";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ثبت بیمار جدید";
            this.Load += new System.EventHandler(this.frmNewPatient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtNationalCode;
        private System.Windows.Forms.Label lblNationalCode;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ErrorProvider err;
        private Atf.UI.DateTimeSelector dateTimeSelector;
        private System.Windows.Forms.Label lblBirthDate;
    }
}