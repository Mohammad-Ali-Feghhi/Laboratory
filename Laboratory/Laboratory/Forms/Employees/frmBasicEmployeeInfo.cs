using System;
using System.Drawing;
using System.Windows.Forms;
using DomainModel.BussinessModel;
using DomainModel.Models;

namespace Laboratory.Forms.Employees
{
    public partial class frmBasicEmployeeInfo : Form
    {
        #region GlobalVariables
        private Employee _currentEmployee;
        private readonly UserPassEmployee _currentUserPassEmployee;

        #endregion
        #region UtilityFunctions
        private void CheckNullInputs()
        {
            btnNext.Enabled = !string.IsNullOrWhiteSpace(txtFullName.Text) &&
                              !string.IsNullOrWhiteSpace(txtMobile.Text) &&
                              !string.IsNullOrWhiteSpace(txtTel.Text) &&
                              !string.IsNullOrWhiteSpace(txtAddress.Text) &&
                              birthDateSelector.Value != null;
        }

        #endregion
        public frmBasicEmployeeInfo()
        {
            InitializeComponent();

            txtMobile.TextChanged += (s, e) => CheckNullInputs();
            txtFullName.TextChanged += (s, e) => CheckNullInputs();
            txtTel.TextChanged += (s, e) => CheckNullInputs();
            txtAddress.TextChanged += (s, e) => CheckNullInputs();
            birthDateSelector.ValueChanged += (s, e) => CheckNullInputs();
        }

        public frmBasicEmployeeInfo(Employee currentEmployee, UserPassEmployee userPassEmployee)
        {
            InitializeComponent();

            txtMobile.TextChanged += (s, e) => CheckNullInputs();
            txtFullName.TextChanged += (s, e) => CheckNullInputs();
            txtTel.TextChanged += (s, e) => CheckNullInputs();
            txtAddress.TextChanged += (s, e) => CheckNullInputs();
            birthDateSelector.ValueChanged += (s, e) => CheckNullInputs();

            this._currentEmployee = currentEmployee;
            this._currentUserPassEmployee = userPassEmployee;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentUserPassEmployee == null)
            {
                _currentEmployee = new Employee
                {
                    EmployeeName = txtFullName.Text,
                    PhoneNumber = txtMobile.Text,
                    Tel = txtTel.Text,
                    BirthDate = birthDateSelector.Value,
                    Address = txtAddress.Text,
                    IsEnabled = rdbEnable.Checked
                };

                var frm = new frmUserPassEmployee(_currentEmployee);
                frm.Show();
                this.Hide();
            }
            else
            {
                _currentEmployee = new Employee
                {
                    EmployeeName = txtFullName.Text,
                    PhoneNumber = txtMobile.Text,
                    Tel = txtTel.Text,
                    Username = _currentUserPassEmployee.Username,
                    Password = _currentUserPassEmployee.Password,
                    BirthDate = birthDateSelector.Value,
                    Address = txtAddress.Text,
                    IsEnabled = rdbEnable.Checked
                };
                var frm = new frmUserPassEmployee(_currentEmployee);
                frm.Show();
                this.Hide();
            }
        }

        private void txtMobile_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobile.Text) ||
                string.IsNullOrEmpty(txtMobile.Text))
            {
                txtMobile.BackColor = Color.White;
                return;
            }

            txtMobile.BackColor = txtMobile.TextLength < 11 ? Color.LightPink : Color.White;
        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) ||
                char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) ||
                char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTel.Text) ||
                string.IsNullOrEmpty(txtTel.Text))
            {
                txtTel.BackColor = Color.White;
                return;
            }

            txtTel.BackColor = txtTel.TextLength < 11 ? Color.LightPink : Color.White;
        }

        private void frmBasicEmployeeInfo_Load(object sender, EventArgs e)
        {
            txtFullName.Focus();

            if (_currentEmployee != null)
            {
                txtFullName.Text = _currentEmployee.EmployeeName;
                txtMobile.Text = _currentEmployee.PhoneNumber;
                txtTel.Text = _currentEmployee.Tel;
                birthDateSelector.Value = _currentEmployee.BirthDate;
                txtAddress.Text = _currentEmployee.Address;
                rdbEnable.Checked = (bool) _currentEmployee.IsEnabled;
            }
        }
    }
}
