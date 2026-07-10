using System;
using System.Windows.Forms;
using DomainModel.Models;
using Framework;

namespace Laboratory.Forms.Employees
{
    public partial class frmShowInfoEmployee : Form
    {
        private readonly Employee _currentEmployee;
        public frmShowInfoEmployee()
        {
            InitializeComponent();
        }

        public frmShowInfoEmployee(Employee currentEmployee)
        {
            InitializeComponent();
            this._currentEmployee = currentEmployee;
        }

        private void frmShowInfoEmployee_Load(object sender, EventArgs e)
        {
            txtEmployeeName.Text = _currentEmployee.EmployeeName;
            txtUsername.Text = _currentEmployee.Username;
            txtPhoneNumber.Text = _currentEmployee.PhoneNumber;
            txtTel.Text = _currentEmployee.Tel;
            txtAddress.Text = _currentEmployee.Address;
            txtBirthDate.Text = PersianDateTime.ConvertDateTimeToPersianDateTime(_currentEmployee.BirthDate);
            if ((bool) _currentEmployee.IsEnabled)
            {
                rdbEnable.Checked = true;
            }
            else
            {
                rdbDisable.Checked = true;
            }
        }
    }
}
