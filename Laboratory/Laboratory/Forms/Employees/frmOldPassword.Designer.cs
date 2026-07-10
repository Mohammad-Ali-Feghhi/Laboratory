
namespace Laboratory.Forms.Employees
{
    partial class frmOldPassword
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
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.btnCheckPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("Kalameh", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtOldPassword.Location = new System.Drawing.Point(130, 49);
            this.txtOldPassword.MaxLength = 100;
            this.txtOldPassword.Multiline = true;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '●';
            this.txtOldPassword.Size = new System.Drawing.Size(156, 27);
            this.txtOldPassword.TabIndex = 0;
            this.txtOldPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldPassword_KeyPress);
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(40, 52);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(84, 23);
            this.lblOldPassword.TabIndex = 1;
            this.lblOldPassword.Text = "رمز عبور فعلی:";
            // 
            // btnCheckPassword
            // 
            this.btnCheckPassword.Location = new System.Drawing.Point(130, 143);
            this.btnCheckPassword.Name = "btnCheckPassword";
            this.btnCheckPassword.Size = new System.Drawing.Size(100, 32);
            this.btnCheckPassword.TabIndex = 2;
            this.btnCheckPassword.Text = "بررسی";
            this.btnCheckPassword.UseVisualStyleBackColor = true;
            this.btnCheckPassword.Click += new System.EventHandler(this.btnCheckPassword_Click);
            // 
            // frmOldPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 211);
            this.Controls.Add(this.btnCheckPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOldPassword";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغییر رمز عبور";
            this.Load += new System.EventHandler(this.frmOldPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Button btnCheckPassword;
    }
}