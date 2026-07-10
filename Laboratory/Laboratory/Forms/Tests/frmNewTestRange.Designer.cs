
namespace Laboratory.Forms.Tests
{
    partial class frmNewTestRange
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
            this.btnAddNew = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbStatusRange = new System.Windows.Forms.GroupBox();
            this.ckbEmergency = new System.Windows.Forms.CheckBox();
            this.ckbStar = new System.Windows.Forms.CheckBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lstTestName = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.grbStatusRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTestName
            // 
            this.txtTestName.Location = new System.Drawing.Point(114, 38);
            this.txtTestName.MaxLength = 100;
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTestName.Size = new System.Drawing.Size(212, 27);
            this.txtTestName.TabIndex = 0;
            this.txtTestName.TextChanged += new System.EventHandler(this.txtTestName_TextChanged);
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Location = new System.Drawing.Point(37, 38);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(71, 23);
            this.lblTestName.TabIndex = 2;
            this.lblTestName.Text = "نام آزمایش:";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(12, 93);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(119, 32);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "ثبت اطلاعات";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // err
            // 
            this.err.BlinkRate = 500;
            this.err.ContainerControl = this;
            // 
            // grbStatusRange
            // 
            this.grbStatusRange.Controls.Add(this.ckbEmergency);
            this.grbStatusRange.Controls.Add(this.btnAddNew);
            this.grbStatusRange.Controls.Add(this.ckbStar);
            this.grbStatusRange.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbStatusRange.Location = new System.Drawing.Point(0, 292);
            this.grbStatusRange.Name = "grbStatusRange";
            this.grbStatusRange.Size = new System.Drawing.Size(692, 137);
            this.grbStatusRange.TabIndex = 4;
            this.grbStatusRange.TabStop = false;
            this.grbStatusRange.Text = "وضعیت بازه مرجع:";
            // 
            // ckbEmergency
            // 
            this.ckbEmergency.AutoSize = true;
            this.ckbEmergency.ForeColor = System.Drawing.Color.Red;
            this.ckbEmergency.Location = new System.Drawing.Point(499, 80);
            this.ckbEmergency.Name = "ckbEmergency";
            this.ckbEmergency.Size = new System.Drawing.Size(72, 27);
            this.ckbEmergency.TabIndex = 1;
            this.ckbEmergency.Text = "اورژانسی";
            this.ckbEmergency.UseVisualStyleBackColor = true;
            // 
            // ckbStar
            // 
            this.ckbStar.AutoSize = true;
            this.ckbStar.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ckbStar.Location = new System.Drawing.Point(470, 37);
            this.ckbStar.Name = "ckbStar";
            this.ckbStar.Size = new System.Drawing.Size(101, 27);
            this.ckbStar.TabIndex = 0;
            this.ckbStar.Text = "غیر طبیعی (*)";
            this.ckbStar.UseVisualStyleBackColor = true;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(355, 38);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 23);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "از بازه:";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(432, 38);
            this.txtFrom.MaxLength = 10;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(212, 27);
            this.txtFrom.TabIndex = 1;
            this.txtFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrom_KeyPress);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(355, 81);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(42, 23);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "تا بازه:";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(432, 81);
            this.txtTo.MaxLength = 10;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(212, 27);
            this.txtTo.TabIndex = 2;
            this.txtTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTo_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(355, 124);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 23);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "توضیحات:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(432, 124);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescription.Size = new System.Drawing.Size(212, 151);
            this.txtDescription.TabIndex = 3;
            // 
            // lstTestName
            // 
            this.lstTestName.FormattingEnabled = true;
            this.lstTestName.ItemHeight = 23;
            this.lstTestName.Location = new System.Drawing.Point(114, 64);
            this.lstTestName.Name = "lstTestName";
            this.lstTestName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstTestName.Size = new System.Drawing.Size(212, 211);
            this.lstTestName.TabIndex = 9;
            this.lstTestName.SelectedIndexChanged += new System.EventHandler(this.lstTestName_SelectedIndexChanged);
            this.lstTestName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstTestName_KeyDown);
            // 
            // frmNewTestRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 429);
            this.Controls.Add(this.lstTestName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.grbStatusRange);
            this.Controls.Add(this.lblTestName);
            this.Controls.Add(this.txtTestName);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewTestRange";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ثبت بازه‌های مرجع";
            this.Load += new System.EventHandler(this.frmNewTestRange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.grbStatusRange.ResumeLayout(false);
            this.grbStatusRange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.GroupBox grbStatusRange;
        private System.Windows.Forms.CheckBox ckbEmergency;
        private System.Windows.Forms.CheckBox ckbStar;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ListBox lstTestName;
    }
}