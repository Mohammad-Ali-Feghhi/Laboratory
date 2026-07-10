using System;
using System.Windows.Forms;
using DataAccess;
using DomainModel.Results;
using Framework;

namespace Laboratory.Forms
{
    public partial class frmLogin : Form
    {
        #region GlobalVariables

        private readonly EmployeeRepository _repo;
        private readonly HashingUtility _secret;
        private int _wrongPasswordCount = 0;
        

        #endregion
        public frmLogin()
        {
            InitializeComponent();
            _repo = new EmployeeRepository();
            _secret = new HashingUtility();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || 
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                err.SetError(txtUsername, "نام کاربری را وارد نمائید");
                return;
            }
            err.Clear();

            if (string.IsNullOrEmpty(txtPassword.Text) || 
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                err.SetError(txtPassword, "رمز عبور را وارد نمائید");
                return;
            }
            err.Clear();

            var hashPassword = _secret.HashPasswordWithKey(txtPassword.Text);
            var isLoggedIn = _repo.Login(txtUsername.Text.ToLower(), hashPassword);

            if (isLoggedIn.IsSuccess)
            {
                this.Hide();
                frmMainBoard frm = new frmMainBoard(isLoggedIn.Data);
                frm.Show();
                _repo.AddToLoginHistory(txtUsername.Text.ToLower());
            }
            else if (!isLoggedIn.IsSuccess)
            {
                switch (isLoggedIn.ErrorCode)
                {
                    case ErrorCode.ValidationError:
                        MessageBox.Show(isLoggedIn.Message, @"هشدار",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
                        break;
                    case ErrorCode.UserNotFound:
                        MessageBox.Show(isLoggedIn.Message, @"هشدار",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
                        break;
                    case ErrorCode.DatabaseError:
                        MessageBox.Show(isLoggedIn.Message, @"هشدار",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                        break;
                    case ErrorCode.InvalidPassword:
                        _wrongPasswordCount += 1;
                        MessageBox.Show(isLoggedIn.Message, @"هشدار",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);

                        txtPassword.Text = "";
                        txtPassword.Focus();

                        if (_wrongPasswordCount >= 3)
                        {
                            var employee = _repo.GetEmployeeByUsername(txtUsername.Text.ToLower());
                            var result = _repo.ValidateLoginAttempt(employee.EmployeeId);
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
                            Application.Exit();
                        }
                        break;
                }
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
    }
}
