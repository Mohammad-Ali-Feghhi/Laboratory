
namespace Laboratory.Forms.Doctors
{
    partial class frmNewDoctor
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
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbDoctorStatus = new System.Windows.Forms.GroupBox();
            this.rdbDisable = new System.Windows.Forms.RadioButton();
            this.rdbEnable = new System.Windows.Forms.RadioButton();
            this.lblLicenseNumber = new System.Windows.Forms.Label();
            this.txtLicenseNumber = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.grbDoctorStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Location = new System.Drawing.Point(181, 31);
            this.txtDoctorName.MaxLength = 150;
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.Size = new System.Drawing.Size(230, 27);
            this.txtDoctorName.TabIndex = 0;
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Location = new System.Drawing.Point(61, 31);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(63, 23);
            this.lblDoctorName.TabIndex = 1;
            this.lblDoctorName.Text = "نام پزشک:";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(195, 327);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(103, 35);
            this.btnAddNew.TabIndex = 4;
            this.btnAddNew.Text = "ثبت جدید";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            // 
            // grbDoctorStatus
            // 
            this.grbDoctorStatus.Controls.Add(this.rdbDisable);
            this.grbDoctorStatus.Controls.Add(this.rdbEnable);
            this.grbDoctorStatus.Location = new System.Drawing.Point(65, 193);
            this.grbDoctorStatus.Name = "grbDoctorStatus";
            this.grbDoctorStatus.Size = new System.Drawing.Size(356, 100);
            this.grbDoctorStatus.TabIndex = 3;
            this.grbDoctorStatus.TabStop = false;
            this.grbDoctorStatus.Text = "وضعیت دکتر:";
            // 
            // rdbDisable
            // 
            this.rdbDisable.AutoSize = true;
            this.rdbDisable.Location = new System.Drawing.Point(38, 47);
            this.rdbDisable.Name = "rdbDisable";
            this.rdbDisable.Size = new System.Drawing.Size(74, 27);
            this.rdbDisable.TabIndex = 1;
            this.rdbDisable.Text = "غیر فعال";
            this.rdbDisable.UseVisualStyleBackColor = true;
            // 
            // rdbEnable
            // 
            this.rdbEnable.AutoSize = true;
            this.rdbEnable.Checked = true;
            this.rdbEnable.Location = new System.Drawing.Point(220, 47);
            this.rdbEnable.Name = "rdbEnable";
            this.rdbEnable.Size = new System.Drawing.Size(55, 27);
            this.rdbEnable.TabIndex = 0;
            this.rdbEnable.TabStop = true;
            this.rdbEnable.Text = "فعال";
            this.rdbEnable.UseVisualStyleBackColor = true;
            // 
            // lblLicenseNumber
            // 
            this.lblLicenseNumber.AutoSize = true;
            this.lblLicenseNumber.Location = new System.Drawing.Point(61, 69);
            this.lblLicenseNumber.Name = "lblLicenseNumber";
            this.lblLicenseNumber.Size = new System.Drawing.Size(114, 23);
            this.lblLicenseNumber.TabIndex = 5;
            this.lblLicenseNumber.Text = "شماره نظام پزشکی:";
            // 
            // txtLicenseNumber
            // 
            this.txtLicenseNumber.Location = new System.Drawing.Point(181, 69);
            this.txtLicenseNumber.MaxLength = 8;
            this.txtLicenseNumber.Name = "txtLicenseNumber";
            this.txtLicenseNumber.Size = new System.Drawing.Size(230, 27);
            this.txtLicenseNumber.TabIndex = 1;
            this.txtLicenseNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseNumber_KeyPress);
            this.txtLicenseNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLicenseNumber_KeyUp);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(61, 107);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 23);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "توضیحات:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(181, 107);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(230, 75);
            this.txtDescription.TabIndex = 2;
            // 
            // frmNewDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 388);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblLicenseNumber);
            this.Controls.Add(this.txtLicenseNumber);
            this.Controls.Add(this.grbDoctorStatus);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lblDoctorName);
            this.Controls.Add(this.txtDoctorName);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewDoctor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ثبت پزشک جدید";
            this.Load += new System.EventHandler(this.frmNewDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.grbDoctorStatus.ResumeLayout(false);
            this.grbDoctorStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.GroupBox grbDoctorStatus;
        private System.Windows.Forms.RadioButton rdbDisable;
        private System.Windows.Forms.RadioButton rdbEnable;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblLicenseNumber;
        private System.Windows.Forms.TextBox txtLicenseNumber;
    }
}