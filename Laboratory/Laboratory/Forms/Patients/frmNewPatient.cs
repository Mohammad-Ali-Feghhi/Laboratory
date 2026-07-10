using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace Laboratory.Forms.Patients
{
    public partial class frmNewPatient : Form
    {
        #region GlobalVariables

        private readonly PatientRepository _repo;
        private readonly EmployeeRepository _empRepository;
        private readonly Employee _currentUser;
        public event Action<Patient> NewPatient;
        public bool AddNewPatientFromTest = false;

        #endregion

        #region UtilityFunctions
        private void ClearForm()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox t)
                {
                    t.Text = "";
                }
            }

            dateTimeSelector.Value = null;
            txtPatientName.Focus();
        }

        #endregion

        public frmNewPatient()
        {
            InitializeComponent();
            this._repo = new PatientRepository();
            this._empRepository = new EmployeeRepository();
        }

        public frmNewPatient(Employee currentUser)
        {
            InitializeComponent();
            this._repo = new PatientRepository();
            this._empRepository = new EmployeeRepository();
            this._currentUser = currentUser;
        }

        private void frmNewPatient_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                err.SetError(txtPatientName, "نام بیمار الزامیست");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                err.SetError(txtNationalCode, "کد ملی الزامیست");
                return;
            }

            if (dateTimeSelector.Value == null)
            {
                err.SetError(dateTimeSelector, "تاریخ تولد الزامیست");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                err.SetError(txtMobile, "تلفن همراه الزامیست");
                return;
            }
            err.Clear();

            var checkingValidation = new PatientCheckingValidationItem
            {
                NationalCode = txtNationalCode.Text,
                Mobile = txtMobile.Text
            };
            var resultCheckingValidation = _repo.PatientCheckingValidation(checkingValidation);
            if (resultCheckingValidation.IsSuccess)
            {
                var newPatient = new Patient
                {
                    PatientName = txtPatientName.Text,
                    NationalCode = txtNationalCode.Text,
                    BirthDate = dateTimeSelector.Value,
                    Mobile = txtMobile.Text,
                    Description = txtDescription.Text
                };

                var result = _repo.AddNewPatient(newPatient);
                if (result.IsSuccess)
                {
                    if (AddNewPatientFromTest)
                    {
                        NewPatient?.Invoke(result.Data);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("اطلاعات بیمار با موفقیت ثبت شد.", "پیام",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
                        ClearForm();
                        return;
                    }
                }

                if (result.ErrorCode == ErrorCode.ValidationError)
                {
                    MessageBox.Show(result.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                    txtPatientName.Focus();
                    return;
                }

                if (result.ErrorCode == ErrorCode.DatabaseError)
                {
                    var log = new LoginHistory
                    {
                        EmployeeId = _currentUser.EmployeeId,
                        Username = _currentUser.Username,
                        LoginDate = DateTime.Now,
                        Message = result.Message
                    };

                    _empRepository.AddToLoginHistoryDatabaseError(log);
                    ClearForm();
                    MessageBox.Show(result.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }

            if (resultCheckingValidation.ErrorCode == ErrorCode.ValidationError)
            {
                MessageBox.Show(resultCheckingValidation.Message, "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading);
                txtNationalCode.Focus();
                return;
            }

            if (resultCheckingValidation.ErrorCode == ErrorCode.DatabaseError)
            {
                var log = new LoginHistory
                {
                    EmployeeId = _currentUser.EmployeeId,
                    Username = _currentUser.Username,
                    LoginDate = DateTime.Now,
                    Message = resultCheckingValidation.Message
                };

                _empRepository.AddToLoginHistoryDatabaseError(log);
                ClearForm();
                MessageBox.Show(resultCheckingValidation.Message, "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNationalCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                txtNationalCode.BackColor = Color.White;
            }
            else
            {
                txtNationalCode.BackColor = txtNationalCode.Text.Length < 10 ? Color.LightPink : Color.White;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMobile_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                txtMobile.BackColor = Color.White;
            }
            else
            {
                txtMobile.BackColor = txtMobile.Text.Length < 11 ? Color.LightPink : Color.White;
            }
        }
    }
}
