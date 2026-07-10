
namespace Laboratory.Forms.Employees
{
    partial class frmUserPassEmployee
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
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Enabled = false;
            this.btnAddEmployee.Location = new System.Drawing.Point(12, 280);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(107, 36);
            this.btnAddEmployee.TabIndex = 3;
            this.btnAddEmployee.Text = "ثبت اطلاعات";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(132, 46);
            this.txtUsername.MaxLength = 100;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsername.Size = new System.Drawing.Size(205, 27);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(48, 46);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 23);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "نام کاربری:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Kalameh", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPassword.Location = new System.Drawing.Point(132, 84);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(205, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(48, 84);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 23);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "رمز عبور:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Kalameh", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(132, 122);
            this.txtConfirmPassword.MaxLength = 100;
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtConfirmPassword.Size = new System.Drawing.Size(205, 27);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
            this.txtConfirmPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyUp);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(48, 122);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(78, 23);
            this.lblConfirmPassword.TabIndex = 13;
            this.lblConfirmPassword.Text = "تکرار رمز عبور:";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(329, 280);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(107, 36);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "قبلی";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // frmUserPassEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 328);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserPassEmployee";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت حساب کاربری";
            this.Load += new System.EventHandler(this.frmUserPassEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnPrevious;
    }
}