
namespace Laboratory.Forms.Employees
{
    partial class frmBasicEmployeeInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.grbEmployeeStatus = new System.Windows.Forms.GroupBox();
            this.rdbDisable = new System.Windows.Forms.RadioButton();
            this.rdbEnable = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.birthDateSelector = new Atf.UI.DateTimeSelector();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.grbEmployeeStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام و نام خانوادگی:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(204, 35);
            this.txtFullName.MaxLength = 100;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(205, 27);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFullName_KeyPress);
            // 
            // grbEmployeeStatus
            // 
            this.grbEmployeeStatus.Controls.Add(this.rdbDisable);
            this.grbEmployeeStatus.Controls.Add(this.rdbEnable);
            this.grbEmployeeStatus.Location = new System.Drawing.Point(80, 274);
            this.grbEmployeeStatus.Name = "grbEmployeeStatus";
            this.grbEmployeeStatus.Size = new System.Drawing.Size(409, 100);
            this.grbEmployeeStatus.TabIndex = 5;
            this.grbEmployeeStatus.TabStop = false;
            this.grbEmployeeStatus.Text = "وضعیت کاربر:";
            // 
            // rdbDisable
            // 
            this.rdbDisable.AutoSize = true;
            this.rdbDisable.Location = new System.Drawing.Point(86, 42);
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
            this.rdbEnable.Location = new System.Drawing.Point(230, 42);
            this.rdbEnable.Name = "rdbEnable";
            this.rdbEnable.Size = new System.Drawing.Size(55, 27);
            this.rdbEnable.TabIndex = 0;
            this.rdbEnable.TabStop = true;
            this.rdbEnable.Text = "فعال";
            this.rdbEnable.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(11, 395);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(107, 36);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // birthDateSelector
            // 
            this.birthDateSelector.Location = new System.Drawing.Point(204, 153);
            this.birthDateSelector.Name = "birthDateSelector";
            this.birthDateSelector.Size = new System.Drawing.Size(205, 28);
            this.birthDateSelector.TabIndex = 3;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(204, 74);
            this.txtMobile.MaxLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobile.Size = new System.Drawing.Size(205, 27);
            this.txtMobile.TabIndex = 1;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            this.txtMobile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMobile_KeyUp);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(76, 73);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(74, 23);
            this.lblMobile.TabIndex = 5;
            this.lblMobile.Text = "تلفن همراه:";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(204, 113);
            this.txtTel.MaxLength = 11;
            this.txtTel.Name = "txtTel";
            this.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTel.Size = new System.Drawing.Size(205, 27);
            this.txtTel.TabIndex = 2;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            this.txtTel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTel_KeyUp);
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(76, 111);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(38, 23);
            this.lblTel.TabIndex = 7;
            this.lblTel.Text = "تلفن:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(204, 194);
            this.txtAddress.MaxLength = 500;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(205, 74);
            this.txtAddress.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "آدرس:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(76, 153);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(63, 23);
            this.lblBirthDate.TabIndex = 11;
            this.lblBirthDate.Text = "تاریخ تولد:";
            // 
            // frmBasicEmployeeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 443);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.birthDateSelector);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.grbEmployeeStatus);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBasicEmployeeInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت اطلاعات پایه";
            this.Load += new System.EventHandler(this.frmBasicEmployeeInfo_Load);
            this.grbEmployeeStatus.ResumeLayout(false);
            this.grbEmployeeStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.GroupBox grbEmployeeStatus;
        private System.Windows.Forms.RadioButton rdbEnable;
        private System.Windows.Forms.Button btnNext;
        private Atf.UI.DateTimeSelector birthDateSelector;
        private System.Windows.Forms.RadioButton rdbDisable;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBirthDate;
    }
}