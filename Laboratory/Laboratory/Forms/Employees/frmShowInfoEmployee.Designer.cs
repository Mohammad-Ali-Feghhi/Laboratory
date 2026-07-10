
namespace Laboratory.Forms.Employees
{
    partial class frmShowInfoEmployee
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
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grbStatusUser = new System.Windows.Forms.GroupBox();
            this.rdbEnable = new System.Windows.Forms.RadioButton();
            this.rdbDisable = new System.Windows.Forms.RadioButton();
            this.grbStatusUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(133, 36);
            this.txtEmployeeName.MaxLength = 150;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(207, 27);
            this.txtEmployeeName.TabIndex = 0;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(423, 36);
            this.txtUsername.MaxLength = 100;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(207, 27);
            this.txtUsername.TabIndex = 1;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(423, 88);
            this.txtTel.MaxLength = 20;
            this.txtTel.Name = "txtTel";
            this.txtTel.ReadOnly = true;
            this.txtTel.Size = new System.Drawing.Size(207, 27);
            this.txtTel.TabIndex = 3;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Location = new System.Drawing.Point(423, 140);
            this.txtBirthDate.MaxLength = 50;
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.ReadOnly = true;
            this.txtBirthDate.Size = new System.Drawing.Size(207, 27);
            this.txtBirthDate.TabIndex = 5;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(133, 88);
            this.txtPhoneNumber.MaxLength = 20;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(207, 27);
            this.txtPhoneNumber.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(133, 140);
            this.txtAddress.MaxLength = 500;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(207, 112);
            this.txtAddress.TabIndex = 4;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(12, 39);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(115, 23);
            this.lblEmployeeName.TabIndex = 6;
            this.lblEmployeeName.Text = "نام  و نام خانوادگی:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(354, 39);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 23);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "نام کاربری:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(12, 91);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(74, 23);
            this.lblPhoneNumber.TabIndex = 8;
            this.lblPhoneNumber.Text = "تلفن همراه:";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(354, 91);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(67, 23);
            this.lblTel.TabIndex = 9;
            this.lblTel.Text = "تلفن منزل:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(354, 143);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(63, 23);
            this.lblBirthDate.TabIndex = 10;
            this.lblBirthDate.Text = "تاریخ تولد:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 143);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(71, 23);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "آدرس منزل:";
            // 
            // grbStatusUser
            // 
            this.grbStatusUser.Controls.Add(this.rdbDisable);
            this.grbStatusUser.Controls.Add(this.rdbEnable);
            this.grbStatusUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbStatusUser.Location = new System.Drawing.Point(0, 258);
            this.grbStatusUser.Name = "grbStatusUser";
            this.grbStatusUser.Size = new System.Drawing.Size(642, 84);
            this.grbStatusUser.TabIndex = 6;
            this.grbStatusUser.TabStop = false;
            this.grbStatusUser.Text = "وضعیت کاربر:";
            // 
            // rdbEnable
            // 
            this.rdbEnable.AutoCheck = false;
            this.rdbEnable.AutoSize = true;
            this.rdbEnable.Location = new System.Drawing.Point(391, 26);
            this.rdbEnable.Name = "rdbEnable";
            this.rdbEnable.Size = new System.Drawing.Size(55, 27);
            this.rdbEnable.TabIndex = 0;
            this.rdbEnable.TabStop = true;
            this.rdbEnable.Text = "فعال";
            this.rdbEnable.UseVisualStyleBackColor = true;
            // 
            // rdbDisable
            // 
            this.rdbDisable.AutoCheck = false;
            this.rdbDisable.AutoSize = true;
            this.rdbDisable.Location = new System.Drawing.Point(133, 26);
            this.rdbDisable.Name = "rdbDisable";
            this.rdbDisable.Size = new System.Drawing.Size(74, 27);
            this.rdbDisable.TabIndex = 1;
            this.rdbDisable.TabStop = true;
            this.rdbDisable.Text = "غیر فعال";
            this.rdbDisable.UseVisualStyleBackColor = true;
            // 
            // frmShowInfoEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 342);
            this.Controls.Add(this.grbStatusUser);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtBirthDate);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtEmployeeName);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowInfoEmployee";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اطلاعات کامل کارمند";
            this.Load += new System.EventHandler(this.frmShowInfoEmployee_Load);
            this.grbStatusUser.ResumeLayout(false);
            this.grbStatusUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtBirthDate;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.GroupBox grbStatusUser;
        private System.Windows.Forms.RadioButton rdbDisable;
        private System.Windows.Forms.RadioButton rdbEnable;
    }
}