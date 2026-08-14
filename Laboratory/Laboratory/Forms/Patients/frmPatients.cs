using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataAccess;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;
using Framework;
using Laboratory.Forms.Tests;

namespace Laboratory.Forms.Patients
{
    public partial class frmPatients : Form
    {
        #region GlobalVariables

        private readonly PatientRepository _repo;
        private readonly EmployeeRepository _employeeRepo;
        private readonly Employee _currentUser;
        private int _patientId;
        private int _patientAge;
        private string _patientName;
        private Patient _currentPatient;

        #endregion

        #region DataBinders

        private void BindGrid()
        {
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            DataGrid.DataSource = _repo.GetAllPatients();
        }
        private void BindGrid(string phrase)
        {
            var patientList = _repo.SearchPatient(phrase.Trim()) ?? 
                              new List<PatientSearchListItem>();
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            DataGrid.DataSource = patientList;
        }

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

        private void OpenTestFormList(int patientId, string patientName)
        {
            foreach (var frm in this.MdiParent.MdiChildren)
            {
                if (frm is frmPatientTestAcceptionList testForm)
                {
                    if (testForm.PatientId == patientId)
                    {
                        frm.Activate();
                        return;
                    }
                }
            }

            var formText = $"فرم لیست آزمایش‌های {patientName}";
            var newForm = new frmPatientTestAcceptionList(patientId)
            {
                Text = formText, 
                MdiParent = this.MdiParent
            };
            newForm.Show();
        }

        private void OpenPatientInformationForm(Patient currentPatient)
        {
            foreach (var frm in this.MdiParent.MdiChildren)
            {
                if (frm is frmPatientShowInfo infoForm)
                {
                    if (infoForm.CurrentPatient.PatientId == currentPatient.PatientId)
                    {
                        frm.Activate();
                        return;
                    }
                }
            }

            var formText = $"فرم اطلاعات {currentPatient.PatientName}";
            var newForm = new frmPatientShowInfo(currentPatient)
            {
                Text = formText,
                MdiParent = this.MdiParent
            };
            newForm.Show();
        }

        private void OpenAddNewTest(int patientId, AddNewPatientTestItem addNewTest)
        {
            foreach (var frm in this.MdiParent.MdiChildren)
            {
                if (frm is frmNewTest newTest)
                {
                    if (newTest.PatientId == patientId)
                    {
                        frm.Activate();
                        return;
                    }
                }
            }
            var formText = $"فرم ثبت آزمایش جدید بیمار {addNewTest.PatientName}";
            var newForm = new frmNewTest(_patientId, addNewTest, _currentUser)
            {
                Text = formText,
                MdiParent = this.MdiParent
            };
            newForm.Show();
        }

        #endregion
        public frmPatients()
        {
            InitializeComponent();
            this._repo = new PatientRepository();
        }

        public frmPatients(Employee currentUser)
        {
            InitializeComponent();
            this._repo = new PatientRepository();
            this._employeeRepo = new EmployeeRepository();
            this._currentUser = currentUser;
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            BindGrid();
            ClearForm();
            GoToCancelMode();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BindGrid();
            GoToCancelMode();
            ClearForm();
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

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _patientId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[0].Value);
            _patientName = DataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            var getAge = new PersianDateTime();
            _patientAge = getAge.GetAge(Convert.ToDateTime(DataGrid.Rows[e.RowIndex].Cells[4].Value));

            if (e.ColumnIndex == 5) // Patient Show Information
            {
                var patient = _repo.GetPatientByPatientId(_patientId);
                if (patient.IsSuccess)
                {
                    _currentPatient = patient.Data;
                    OpenPatientInformationForm(_currentPatient);
                }
                else if(patient.ErrorCode == ErrorCode.UserNotFound)
                {
                    MessageBox.Show(patient.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                }
                else if (patient.ErrorCode == ErrorCode.DatabaseError)
                {
                    var log = new LoginHistory
                    {
                        EmployeeId = _currentUser.EmployeeId,
                        Username = _currentUser.Username,
                        LoginDate = DateTime.Now,
                        Message = patient.Message
                    };
                    _employeeRepo.AddToLoginHistoryDatabaseError(log);
                    MessageBox.Show(patient.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                    ClearForm();
                    GoToCancelMode();
                }
            }
            else if (e.ColumnIndex == 6) // Add New Test
            {
                var newTest = new AddNewPatientTestItem
                {
                    PatientId = _patientId,
                    PatientName = _patientName,
                    RegistrationEmployeeId = _currentUser.EmployeeId,
                    RegistrationEmployeeName = _currentUser.EmployeeName,
                    PatientAge = _patientAge
                };
                OpenAddNewTest(_patientId, newTest);
            }
            else if (e.ColumnIndex == 7) // Test Lists
            {
                OpenTestFormList(_patientId, _patientName);
            }
            else if (e.ColumnIndex == 8) // Update
            {
                var patient = _repo.GetPatientByPatientId(_patientId);
                if (patient.IsSuccess)
                {
                    txtPatientName.Text = patient.Data.PatientName;
                    txtNationalCode.Text = patient.Data.NationalCode;
                    txtMobile.Text = patient.Data.Mobile;
                    dateTimeSelector.Value = patient.Data.BirthDate;
                    txtDescription.Text = patient.Data.Description;
                    GoToEditMode();
                }
                else if (patient.ErrorCode == ErrorCode.UserNotFound)
                {
                    MessageBox.Show(patient.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                }
                else if (patient.ErrorCode == ErrorCode.DatabaseError)
                {
                    var log = new LoginHistory
                    {
                        EmployeeId = _currentUser.EmployeeId,
                        Username = _currentUser.Username,
                        LoginDate = DateTime.Now,
                        Message = patient.Message
                    };
                    _employeeRepo.AddToLoginHistoryDatabaseError(log);
                }
            }
            else if (e.ColumnIndex == 9) // Delete
            {
                var deleteMessage = $"آیا از حذف {_patientName} مطمئن هستید؟";
                if (MessageBox.Show(deleteMessage, "هشدار",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button2,
                                    MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    var deleteResult = _repo.DeletePatient(_patientId);
                    if (deleteResult.IsSuccess)
                    {
                        BindGrid();
                        var successMessage = $"{_patientName} با موفقیت حذف شد.";
                        MessageBox.Show(successMessage, "پیام",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.RtlReading);
                        ClearForm();
                        GoToCancelMode();
                    }
                    else if (deleteResult.ErrorCode == ErrorCode.ValidationError)
                    {
                        MessageBox.Show(deleteResult.Message, "هشدار",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.RtlReading);
                        ClearForm();
                        GoToCancelMode();
                    }
                    else if (deleteResult.ErrorCode == ErrorCode.UserNotFound)
                    {
                        MessageBox.Show(deleteResult.Message, "هشدار",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.RtlReading);
                        ClearForm();
                        GoToCancelMode();
                    }
                    else if (deleteResult.ErrorCode == ErrorCode.DatabaseError)
                    {
                        var log = new LoginHistory
                        {
                            EmployeeId = _currentUser.EmployeeId,
                            Username = _currentUser.Username,
                            LoginDate = DateTime.Now,
                            Message = deleteResult.Message
                        };
                        _employeeRepo.AddToLoginHistoryDatabaseError(log);
                        MessageBox.Show(deleteResult.Message, "هشدار",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1);
                        BindGrid();
                        ClearForm();
                        GoToCancelMode();
                    }
                }
            }
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || 
                char.IsLetter(e.KeyChar) ||
                char.IsLower(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
