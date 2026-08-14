
namespace Laboratory.Quick_Access
{
    partial class QuickAccessListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlIconBackground = new System.Windows.Forms.Panel();
            this.pnlUnderline = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BackColor = System.Drawing.Color.Teal;
            this.picBox.Location = new System.Drawing.Point(621, 18);
            this.picBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(99, 93);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Font = new System.Drawing.Font("Kalameh", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(18, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(577, 31);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            this.lblTitle.MouseEnter += new System.EventHandler(this.QuickAccessListItem_MouseEnter);
            this.lblTitle.MouseLeave += new System.EventHandler(this.QuickAccessListItem_MouseLeave);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Font = new System.Drawing.Font("Kalameh", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(18, 67);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(576, 44);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Lorem Ipsum - some text here";
            this.lblDescription.MouseEnter += new System.EventHandler(this.QuickAccessListItem_MouseEnter);
            this.lblDescription.MouseLeave += new System.EventHandler(this.QuickAccessListItem_MouseLeave);
            // 
            // pnlIconBackground
            // 
            this.pnlIconBackground.BackColor = System.Drawing.Color.Teal;
            this.pnlIconBackground.Location = new System.Drawing.Point(600, 0);
            this.pnlIconBackground.Name = "pnlIconBackground";
            this.pnlIconBackground.Size = new System.Drawing.Size(138, 127);
            this.pnlIconBackground.TabIndex = 3;
            // 
            // pnlUnderline
            // 
            this.pnlUnderline.BackColor = System.Drawing.Color.DarkGray;
            this.pnlUnderline.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUnderline.Location = new System.Drawing.Point(0, 125);
            this.pnlUnderline.Name = "pnlUnderline";
            this.pnlUnderline.Size = new System.Drawing.Size(738, 2);
            this.pnlUnderline.TabIndex = 4;
            // 
            // QuickAccessListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlUnderline);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.pnlIconBackground);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "QuickAccessListItem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(738, 127);
            this.Click += new System.EventHandler(this.QuickAccessListItem_Click);
            this.MouseEnter += new System.EventHandler(this.QuickAccessListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.QuickAccessListItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel pnlIconBackground;
        private System.Windows.Forms.Panel pnlUnderline;
    }
}
