
namespace Laboratory.Forms.Patients
{
    partial class frmPatientShowInfo
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
            this.lblPatientName = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtNationalCode = new System.Windows.Forms.TextBox();
            this.lblNationalCode = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(27, 12);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(59, 23);
            this.lblPatientName.TabIndex = 0;
            this.lblPatientName.Text = "نام بیمار:";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(109, 12);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(247, 27);
            this.txtPatientName.TabIndex = 1;
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.Location = new System.Drawing.Point(109, 50);
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.Size = new System.Drawing.Size(247, 27);
            this.txtNationalCode.TabIndex = 3;
            // 
            // lblNationalCode
            // 
            this.lblNationalCode.AutoSize = true;
            this.lblNationalCode.Location = new System.Drawing.Point(27, 50);
            this.lblNationalCode.Name = "lblNationalCode";
            this.lblNationalCode.Size = new System.Drawing.Size(51, 23);
            this.lblNationalCode.TabIndex = 2;
            this.lblNationalCode.Text = "کد ملی:";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(109, 88);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(247, 27);
            this.txtMobile.TabIndex = 5;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(27, 88);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(74, 23);
            this.lblMobile.TabIndex = 4;
            this.lblMobile.Text = "تلفن همراه:";
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Location = new System.Drawing.Point(109, 126);
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.Size = new System.Drawing.Size(247, 27);
            this.txtBirthDate.TabIndex = 7;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(27, 126);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(63, 23);
            this.lblBirthDate.TabIndex = 6;
            this.lblBirthDate.Text = "تاریخ تولد:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(109, 164);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(247, 140);
            this.txtDescription.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(27, 164);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 23);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "توضیحات:";
            // 
            // frmPatientShowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 318);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtBirthDate);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.txtNationalCode);
            this.Controls.Add(this.lblNationalCode);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lblPatientName);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientShowInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمایش اطلاعات بیمار";
            this.Load += new System.EventHandler(this.frmPatientShowInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtNationalCode;
        private System.Windows.Forms.Label lblNationalCode;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtBirthDate;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
    }
}