using System;
using System.Windows.Forms;
using DataAccess;
using DomainModel.Models;
using Framework;

namespace Laboratory.Forms.Employees
{
    public partial class frmOldPassword : Form
    {
        #region GlobalVariables

        private readonly Employee _currentUser;
        private readonly EmployeeRepository _repo;
        private readonly HashingUtility _hashing;
        private int _wrongPasswordCount = 0;

        #endregion
        public frmOldPassword()
        {
            InitializeComponent();
        }

        public frmOldPassword(Employee currentUser)
        {
            InitializeComponent();
            this._currentUser = currentUser;
            this._repo = new EmployeeRepository();
            this._hashing = new HashingUtility();
        }

        private void frmOldPassword_Load(object sender, EventArgs e)
        {
            txtOldPassword.Focus();
        }

        private void btnCheckPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text))
            {
                MessageBox.Show("لطفا رمز عبور فعلی خود را وارد نمائید.", "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                txtOldPassword.Focus();
                return;
            }

            var employeeById = _repo.GetEmployeeByEmployeeId(_currentUser.EmployeeId);
            var hashOldPassword = _hashing.HashPasswordWithKey(txtOldPassword.Text);
            if (employeeById.Password != hashOldPassword)
            {
                MessageBox.Show("رمز عبور اشتباه است!", "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                txtOldPassword.Text = "";
                txtOldPassword.Focus();
                _wrongPasswordCount += 1;
            }
            else
            {
                var newForm = new frmNewPassword(_currentUser);
                this.Hide();
                newForm.Show();
            }

            if (_wrongPasswordCount >= 3)
            {
                var result = _repo.ValidateLoginAttempt(_currentUser.EmployeeId);
                if (result)
                {
                    const string msgError = @"نام کاربری شما مسدود شد." + "\n" +
                                            "جهت رفع مشکل با پشتیبانی تماس بگیرید.";
                    MessageBox.Show(msgError, @"هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                }
                else
                {
                    const string msgError = @"خطای تعریف نشده رخ داده است!" + "\n" +
                                            "با پشتیبانی تماس بگیرید.";
                    MessageBox.Show(msgError, @"هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                }

                var mainForm = (frmMainBoard) Application.OpenForms["frmMainBoard"];
                mainForm.ForceClose = true;
                Application.Exit();
            }
        }

        private void txtOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
