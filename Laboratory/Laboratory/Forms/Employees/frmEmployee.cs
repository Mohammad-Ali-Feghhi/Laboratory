using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using DomainModel.Models;
using DomainModel.Results;

namespace Laboratory.Forms.Employees
{
    public partial class frmEmployee : Form
    {
        #region GlobalVariables

        private readonly EmployeeRepository _repo;
        private readonly Employee _currentUser;
        private int _employeeId;
        private string _employeeName;

        #endregion

        #region DataBinders

        private void BindGrid()
        {
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            DataGrid.DataSource = _repo.GetAllEmployees();
        }

        private void BindGrid(string phrase)
        {
            var term = phrase.Trim();
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            DataGrid.DataSource = _repo.SearchEmployee(term);
        }

        private void UpdateEmployee()
        {
            var newEmployee = new Employee
            {
                EmployeeId = _employeeId,
                EmployeeName = txtEmployeeName.Text,
                Username = txtUsername.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Tel = txtTel.Text,
                Address = txtAddress.Text,
                BirthDate = dateTimePicker.Value,
                IsEnabled = rdbEnable.Checked,
                UpdateTime = DateTime.Now,
                IsUpdated = true
            };
            var resultUpdate = _repo.UpdateEmployee(newEmployee);
            if (resultUpdate.IsSuccess)
            {
                if (!rdbEnable.Checked && _currentUser.EmployeeId == _employeeId)
                {
                    MessageBox.Show("کاربر جاری سیستم غیر فعال شد.", "پیام",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    var mainForm = (frmMainBoard)Application.OpenForms["frmMainBoard"];
                    mainForm.ForceClose = true;
                    Application.Exit();
                }
                else if(_currentUser.EmployeeId == _employeeId)
                {
                    MessageBox.Show("اطلاعات کاربر جاری سیستم با موفقیت ویرایش شد.", "پیام",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    var frm = (frmMainBoard)this.MdiParent;
                    frm.RefreshUsername(txtUsername.Text);
                    BindGrid();
                    GoToCancelMode();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("اطلاعات با موفقیت ویرایش شد.", "پیام",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    BindGrid();
                    GoToCancelMode();
                    ClearForm();
                }
            }

            switch (resultUpdate.ErrorCode)
            {
                case ErrorCode.ValidationError:
                    MessageBox.Show(resultUpdate.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    break;
                case ErrorCode.UserNotFound:
                    MessageBox.Show(resultUpdate.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    break;
                case ErrorCode.DatabaseError:
                    MessageBox.Show(resultUpdate.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                    break;
            }
        }

        #endregion

        #region UtilityFunctions
        private void ClearForm()
        {
            dateTimePicker.Value = null;
            rdbEnable.Checked = false;
            rdbDisable.Checked = false;

            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox t)
                {
                    t.Text = "";
                }
            }

            err.Clear();
            txtEmployeeName.Focus();
        }

        private void GoToEditMode()
        {
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void GoToCancelMode()
        {
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
        }

        #endregion
        public frmEmployee()
        {
            InitializeComponent();
            this._repo = new EmployeeRepository();
        }

        public frmEmployee(Employee currentUser)
        {
            InitializeComponent();
            this._repo = new EmployeeRepository();
            this._currentUser = currentUser;
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            BindGrid();
            GoToCancelMode();
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _employeeId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[0].Value);
            _employeeName = DataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (e.ColumnIndex == 5) // ShowInfoEmployee
            {
                GoToCancelMode();
                ClearForm();
                var employee = _repo.GetEmployeeByEmployeeId(_employeeId);
                var frm = new frmShowInfoEmployee(employee);
                frm.ShowDialog();
            }

            if (e.ColumnIndex == 6) // Update
            {
                var employee = _repo.GetEmployeeByEmployeeId(_employeeId);
                txtEmployeeName.Text = employee.EmployeeName;
                txtUsername.Text = employee.Username;
                txtPhoneNumber.Text = employee.PhoneNumber;
                txtTel.Text = employee.Tel;
                dateTimePicker.Value = employee.BirthDate;
                txtAddress.Text = employee.Address;
                if ((bool) employee.IsEnabled)
                {
                    rdbEnable.Checked = true;
                }
                else
                {
                    rdbDisable.Checked = true;
                }

                GoToEditMode();
            }

            if (e.ColumnIndex == 7) //Delete
            {
                if (_currentUser.EmployeeId == _employeeId)
                {
                    var msgError = $"کاربر {_currentUser.Username} وارد سامانه شده و امکان حذف وجود ندارد!";
                    MessageBox.Show(msgError, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    return;
                }
                var msg = $"آیا از حذف کاربر {_employeeName} مطمئن هستید؟";
                if (MessageBox.Show(msg, @"هشدار",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    GoToCancelMode();
                    ClearForm();
                    var employee = _repo.DeleteEmployee(_employeeId);
                    if (employee.IsSuccess)
                    {
                        BindGrid();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GoToCancelMode();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                err.SetError(txtEmployeeName, "نام و نام خانوادگی الزامیست");
            }

            else if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                err.SetError(txtUsername, "نام کاربری الزامیست");
            }

            else if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                err.SetError(txtPhoneNumber, "شماره همراه الزامیست");
            }

            else if (string.IsNullOrWhiteSpace(txtTel.Text))
            {
                err.SetError(txtTel, "تلفن منزل الزامیست");
            }

            else if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                err.SetError(txtAddress, "آدرس الزامیست");
            }

            else if (dateTimePicker.Value == null)
            {
                err.SetError(dateTimePicker, "تاریخ تولد الزامیست");
            }
            else
            {
                err.Clear();
                var employee = _repo.GetEmployeeByEmployeeId(_employeeId);
                if (txtUsername.Text == employee.Username)
                {
                    UpdateEmployee();
                }
                else
                {
                    var existUsername = _repo.HasExistUsername(txtUsername.Text);
                    if (existUsername.IsSuccess)
                    {
                        UpdateEmployee();
                    }

                    switch (existUsername.ErrorCode)
                    {
                        case ErrorCode.ValidationError:
                            MessageBox.Show(existUsername.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                            txtUsername.Focus();
                            break;
                        case ErrorCode.DatabaseError:
                            MessageBox.Show(existUsername.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                            break;
                    }
                }
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
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

        private void txtPhoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                txtPhoneNumber.BackColor = Color.White;
                return;
            }

            txtPhoneNumber.BackColor = txtPhoneNumber.TextLength < 11 ? Color.LightPink : Color.White;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text.Length < 2)
            {
                BindGrid();
            }
            else if (txtSearch.Text.Length > 2)
            {
                BindGrid(txtSearch.Text);
            }
        }
    }
}
