using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess;
using DomainModel.Models;
using DomainModel.Results;
using Framework;

namespace Laboratory.Forms.Employees
{
    public partial class frmNewPassword : Form
    {
        #region GlobalVariables

        private readonly Employee _currentEmployee;
        private readonly EmployeeRepository _repo;
        private readonly HashingUtility _hashing;

        #endregion
        public frmNewPassword()
        {
            InitializeComponent();
        }

        public frmNewPassword(Employee currentEmployee)
        {
            InitializeComponent();
            this._currentEmployee = currentEmployee;
            this._repo = new EmployeeRepository();
            this._hashing = new HashingUtility();
        }

        private void frmNewPassword_Load(object sender, EventArgs e)
        {
            txtNewPassword.Focus();
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtConfirmPassword_KeyUp(object sender, KeyEventArgs e)
        {
            txtConfirmPassword.BackColor = txtConfirmPassword.Text != txtNewPassword.Text ? Color.LightPink : Color.White;
        }

        private void btnAddNewPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("رمز عبور اشتباه است!", "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                txtConfirmPassword.Focus();
            }
            else
            {
                var hashingPass = _hashing.HashPasswordWithKey(txtNewPassword.Text);
                var result = _repo.ChangePassword(_currentEmployee.EmployeeId, hashingPass);
                if (result.IsSuccess)
                {
                    MessageBox.Show("رمز جدید با موفقیت ثبت شد.", "پیام",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    this.Hide();
                }
                else if (result.ErrorCode == ErrorCode.UserNotFound)
                {
                    MessageBox.Show(result.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                }
                else if (result.ErrorCode == ErrorCode.ValidationError)
                {
                    MessageBox.Show(result.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                }
                else if (result.ErrorCode == ErrorCode.InvalidPassword)
                {
                    MessageBox.Show(result.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                }
                else if(result.ErrorCode == ErrorCode.DatabaseError)
                {
                    MessageBox.Show(result.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
