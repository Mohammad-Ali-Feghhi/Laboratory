
namespace Laboratory.Forms.Employees
{
    partial class frmNewPassword
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
            this.btnAddNewPassword = new System.Windows.Forms.Button();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddNewPassword
            // 
            this.btnAddNewPassword.Location = new System.Drawing.Point(127, 152);
            this.btnAddNewPassword.Name = "btnAddNewPassword";
            this.btnAddNewPassword.Size = new System.Drawing.Size(100, 32);
            this.btnAddNewPassword.TabIndex = 2;
            this.btnAddNewPassword.Text = "ثبت";
            this.btnAddNewPassword.UseVisualStyleBackColor = true;
            this.btnAddNewPassword.Click += new System.EventHandler(this.btnAddNewPassword_Click);
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(32, 45);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(83, 23);
            this.lblOldPassword.TabIndex = 4;
            this.lblOldPassword.Text = "رمز عبور جدید:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Kalameh", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNewPassword.Location = new System.Drawing.Point(146, 42);
            this.txtNewPassword.MaxLength = 100;
            this.txtNewPassword.Multiline = true;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.Size = new System.Drawing.Size(156, 27);
            this.txtNewPassword.TabIndex = 0;
            this.txtNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPassword_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "تکرار رمز عبور جدید:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Kalameh", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(146, 80);
            this.txtConfirmPassword.MaxLength = 100;
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new System.Drawing.Size(156, 27);
            this.txtConfirmPassword.TabIndex = 1;
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
            this.txtConfirmPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyUp);
            // 
            // frmNewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnAddNewPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewPassword";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغییر رمز عبور";
            this.Load += new System.EventHandler(this.frmNewPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmPassword;
    }
}