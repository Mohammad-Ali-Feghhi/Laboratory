
namespace Laboratory.Forms.Employees
{
    partial class frmInactiveEmployee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.clmnEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIsEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEnable = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnEmployeeId,
            this.clmnEmployeeName,
            this.clmnUsername,
            this.clmnPhoneNumber,
            this.clmnIsEnabled,
            this.btnEnable});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataGrid.Name = "DataGrid";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGrid.RowTemplate.Height = 35;
            this.DataGrid.Size = new System.Drawing.Size(743, 464);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            // 
            // clmnEmployeeId
            // 
            this.clmnEmployeeId.DataPropertyName = "EmployeeId";
            this.clmnEmployeeId.HeaderText = "کد کارمند";
            this.clmnEmployeeId.Name = "clmnEmployeeId";
            this.clmnEmployeeId.ReadOnly = true;
            this.clmnEmployeeId.Visible = false;
            // 
            // clmnEmployeeName
            // 
            this.clmnEmployeeName.DataPropertyName = "EmployeeName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnEmployeeName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmnEmployeeName.HeaderText = "نام کارمند";
            this.clmnEmployeeName.MinimumWidth = 200;
            this.clmnEmployeeName.Name = "clmnEmployeeName";
            this.clmnEmployeeName.ReadOnly = true;
            this.clmnEmployeeName.Width = 200;
            // 
            // clmnUsername
            // 
            this.clmnUsername.DataPropertyName = "Username";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmnUsername.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmnUsername.HeaderText = "نام کاربری";
            this.clmnUsername.MinimumWidth = 200;
            this.clmnUsername.Name = "clmnUsername";
            this.clmnUsername.ReadOnly = true;
            this.clmnUsername.Width = 200;
            // 
            // clmnPhoneNumber
            // 
            this.clmnPhoneNumber.DataPropertyName = "PhoneNumber";
            this.clmnPhoneNumber.HeaderText = "تلفن همراه";
            this.clmnPhoneNumber.MaxInputLength = 20;
            this.clmnPhoneNumber.MinimumWidth = 200;
            this.clmnPhoneNumber.Name = "clmnPhoneNumber";
            this.clmnPhoneNumber.ReadOnly = true;
            this.clmnPhoneNumber.Width = 200;
            // 
            // clmnIsEnabled
            // 
            this.clmnIsEnabled.DataPropertyName = "IsEnabled";
            this.clmnIsEnabled.HeaderText = "فعال";
            this.clmnIsEnabled.Name = "clmnIsEnabled";
            this.clmnIsEnabled.Visible = false;
            // 
            // btnEnable
            // 
            this.btnEnable.HeaderText = "";
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Text = "فعال کردن";
            this.btnEnable.UseColumnTextForButtonValue = true;
            // 
            // frmInactiveEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 464);
            this.Controls.Add(this.DataGrid);
            this.Font = new System.Drawing.Font("Kalameh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInactiveEmployee";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست کارمندان غیر فعال";
            this.Load += new System.EventHandler(this.frmInactiveEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPhoneNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnIsEnabled;
        private System.Windows.Forms.DataGridViewButtonColumn btnEnable;
    }
}