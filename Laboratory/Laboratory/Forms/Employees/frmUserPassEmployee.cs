using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;
using Framework;

namespace Laboratory.Forms.Employees
{
    public partial class frmUserPassEmployee : Form
    {
        #region GlobalVariables

        private readonly Employee _currentEmployee;
        private UserPassEmployee _currentUserPassEmployee;

        #endregion

        #region UtilityFunctions
        private void CheckNullInputs()
        {
            btnAddEmployee.Enabled = !string.IsNullOrWhiteSpace(txtUsername.Text) &&
                                     !string.IsNullOrWhiteSpace(txtPassword.Text) &&
                                     !string.IsNullOrWhiteSpace(txtConfirmPassword.Text);
        }

        #endregion
        public frmUserPassEmployee()
        {
            InitializeComponent();
        }

        public frmUserPassEmployee(Employee currentEmployee)
        {
            InitializeComponent();

            this._currentEmployee = currentEmployee;

            txtUsername.TextChanged += (s, e) => CheckNullInputs();
            txtPassword.TextChanged += (s, e) => CheckNullInputs();
            txtConfirmPassword.TextChanged += (s, e) => CheckNullInputs();
        }

        private void frmUserPassEmployee_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();

            if (!string.IsNullOrWhiteSpace(_currentEmployee.Username) && 
                !string.IsNullOrWhiteSpace(_currentEmployee.Password))
            {
                txtUsername.Text = _currentEmployee.Username;
                txtPassword.Text = _currentEmployee.Password;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != '_' &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (char.IsLetter(e.KeyChar) && e.KeyChar > 127)
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != '_' &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (char.IsLetter(e.KeyChar) && e.KeyChar > 127)
            {
                e.Handled = true;
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != '_' &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (char.IsLetter(e.KeyChar) && e.KeyChar > 127)
            {
                e.Handled = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && 
                !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                _currentUserPassEmployee = new UserPassEmployee
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };
                var frm = new frmBasicEmployeeInfo(_currentEmployee, _currentUserPassEmployee);
                frm.Show();
                this.Hide();
            }
            else
            {
                var frm = new frmBasicEmployeeInfo(_currentEmployee, _currentUserPassEmployee);
                frm.Show();
                this.Hide();
            }
        }

        private void txtConfirmPassword_KeyUp(object sender, KeyEventArgs e)
        {
            txtConfirmPassword.BackColor = txtConfirmPassword.Text != txtPassword.Text ? Color.LightPink : Color.White;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("رمز عبور اشتباه است!", "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                txtConfirmPassword.Focus();
            }

            var repo = new EmployeeRepository();
            var hasExistUsername = repo.HasExistUsername(txtUsername.Text.ToLower());
            if (hasExistUsername.ErrorCode == ErrorCode.ValidationError)
            {
                MessageBox.Show(hasExistUsername.Message, "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading);
                txtUsername.Focus();
            }

            if (hasExistUsername.ErrorCode == ErrorCode.DatabaseError)
            {
                MessageBox.Show(hasExistUsername.Message, "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading);
            }

            var hashing = new HashingUtility();
            var newEmployee = new Employee
            {
                EmployeeName = _currentEmployee.EmployeeName,
                Address = _currentEmployee.Address,
                BirthDate = _currentEmployee.BirthDate,
                IsEnabled = _currentEmployee.IsEnabled,
                PhoneNumber = _currentEmployee.PhoneNumber,
                Tel = _currentEmployee.Tel,
                Username = txtUsername.Text.ToLower(),
                Password = hashing.HashPasswordWithKey(txtPassword.Text)
            };

            var result = repo.AddNewEmployee(newEmployee);
            if (result.IsSuccess)
            {
                MessageBox.Show("کاربر جدید با موفقیت ثبت شد.", "پیام", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                var frm = new frmBasicEmployeeInfo();
                frm.Show();
                this.Hide();
            }

            if (result.ErrorCode == ErrorCode.ValidationError)
            {
                MessageBox.Show(result.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }

            if (result.ErrorCode == ErrorCode.DatabaseError)
            {
                MessageBox.Show(result.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            var usernameText = txtUsername.Text.Trim();
            usernameText = System.Text.RegularExpressions
                .Regex
                .Replace(usernameText, @"[\u0600-\u06FF]", "");
            if (txtUsername.Text != usernameText)
            {
                var pos = txtUsername.SelectionStart;
                txtUsername.Text = usernameText;
                txtUsername.SelectionStart = Math.Min(pos, txtUsername.Text.Length);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            var passwordText = txtPassword.Text.Trim();
            passwordText = System.Text.RegularExpressions
                .Regex
                .Replace(passwordText, @"[\u0600-\u06FF]", "");
            if (txtPassword.Text != passwordText)
            {
                var pos = txtPassword.SelectionStart;
                txtPassword.Text = passwordText;
                txtPassword.SelectionStart = Math.Min(pos, txtPassword.Text.Length);
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            var confirmPasswordText = txtConfirmPassword.Text.Trim();
            confirmPasswordText = System.Text.RegularExpressions
                .Regex
                .Replace(confirmPasswordText, @"[\u0600-\u06FF]", "");
            if (txtConfirmPassword.Text != confirmPasswordText)
            {
                var pos = txtConfirmPassword.SelectionStart;
                txtConfirmPassword.Text = confirmPasswordText;
                txtConfirmPassword.SelectionStart = Math.Min(pos, txtConfirmPassword.Text.Length);
            }
        }
    }
}
