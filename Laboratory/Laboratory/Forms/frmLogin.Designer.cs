
namespace Laboratory.Forms
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pcbLeft = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pcbPassword = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.pcbUsername = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLeft)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsername)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Location = new System.Drawing.Point(3, 7);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUsername.Size = new System.Drawing.Size(203, 21);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Kalameh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPassword.Location = new System.Drawing.Point(3, 5);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.Size = new System.Drawing.Size(203, 25);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.WordWrap = false;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblUsername.Location = new System.Drawing.Point(4, 7);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUsername.Size = new System.Drawing.Size(65, 21);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "نام کاربری";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblPassword.Location = new System.Drawing.Point(4, 7);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPassword.Size = new System.Drawing.Size(54, 21);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "رمز عبور";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(345, 388);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(254, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "ورود";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pcbLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLeft.Location = new System.Drawing.Point(496, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(229, 474);
            this.pnlLeft.TabIndex = 4;
            // 
            // pcbLeft
            // 
            this.pcbLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbLeft.Image = ((System.Drawing.Image)(resources.GetObject("pcbLeft.Image")));
            this.pcbLeft.Location = new System.Drawing.Point(0, 0);
            this.pcbLeft.Name = "pcbLeft";
            this.pcbLeft.Size = new System.Drawing.Size(229, 474);
            this.pcbLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbLeft.TabIndex = 0;
            this.pcbLeft.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.pnlPassword);
            this.pnlRight.Controls.Add(this.label3);
            this.pnlRight.Controls.Add(this.label2);
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Controls.Add(this.button1);
            this.pnlRight.Controls.Add(this.pcbLogo);
            this.pnlRight.Controls.Add(this.pnlUsername);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlRight.Size = new System.Drawing.Size(725, 474);
            this.pnlRight.TabIndex = 0;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPassword.Controls.Add(this.pcbPassword);
            this.pnlPassword.Controls.Add(this.lblPassword);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Location = new System.Drawing.Point(345, 326);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(254, 37);
            this.pnlPassword.TabIndex = 1;
            // 
            // pcbPassword
            // 
            this.pcbPassword.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcbPassword.Image = ((System.Drawing.Image)(resources.GetObject("pcbPassword.Image")));
            this.pcbPassword.Location = new System.Drawing.Point(212, 0);
            this.pcbPassword.Name = "pcbPassword";
            this.pcbPassword.Size = new System.Drawing.Size(40, 35);
            this.pcbPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbPassword.TabIndex = 3;
            this.pcbPassword.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Vazir", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(314, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "لطفا برای ورود، اطلاعات کاربری خود را وارد کنید";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(304, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "سیستم مدیریت آزمایشگاه خاتون";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // pcbLogo
            // 
            this.pcbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogo.Image")));
            this.pcbLogo.Location = new System.Drawing.Point(413, 35);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(128, 128);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbLogo.TabIndex = 0;
            this.pcbLogo.TabStop = false;
            // 
            // pnlUsername
            // 
            this.pnlUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUsername.Controls.Add(this.pcbUsername);
            this.pnlUsername.Controls.Add(this.lblUsername);
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Location = new System.Drawing.Point(345, 275);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(254, 37);
            this.pnlUsername.TabIndex = 0;
            // 
            // pcbUsername
            // 
            this.pcbUsername.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcbUsername.Image = ((System.Drawing.Image)(resources.GetObject("pcbUsername.Image")));
            this.pcbUsername.Location = new System.Drawing.Point(212, 0);
            this.pcbUsername.Name = "pcbUsername";
            this.pcbUsername.Size = new System.Drawing.Size(40, 35);
            this.pcbUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbUsername.TabIndex = 3;
            this.pcbUsername.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(725, 474);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ورود";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbLeft)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsername)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox pcbLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.PictureBox pcbUsername;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.PictureBox pcbPassword;
    }
}