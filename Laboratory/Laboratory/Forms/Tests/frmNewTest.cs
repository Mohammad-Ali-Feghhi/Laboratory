using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccess;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;
using Framework;
using Laboratory.Forms.Patients;

namespace Laboratory.Forms.Tests
{
    public partial class frmNewTest : Form
    {
        #region GlobalVariables

        private readonly TestRepository _testRepo;
        private readonly PatientRepository _patientRepo;
        private readonly DoctorRepository _doctorRepo;
        private readonly UnitRepository _unitRepo;
        private readonly TestAcceptionRepository _testAcceptionRepo;
        private readonly TestMethodRepository _testMethodRepo;
        public int PatientId { get; private set; }
        private int _testId;
        private int _testMethodId;
        private int _unitId;
        private int _testAcceptionHeaderId;
        public bool IsTestPatientForm { get; } = false;
        private readonly bool _isPatientForm;
        private AddNewPatientTestItem _newPatientTest;
        private readonly Employee _currentEmployee;
        private BindingList<TestParameterTemp> _TestParametersTemp = new BindingList<TestParameterTemp>();
        private Guid? _editingTempId = null;
        private bool _suppress;

        #endregion

        #region UtilityFunction

        private void NewPatientSaved(Patient patient)
        {
            txtSearchPatient.Text = patient.PatientName;
            txtSearchPatient.ReadOnly = true;
            lstPatient.Visible = false;
            var age = new PersianDateTime();
            txtPatientAge.Text = age.GetAge((DateTime) patient.BirthDate).ToString();
            btnAddNewPatient.Visible = false;
            btnTestAcceptionHeader.Visible = true;
            var textForm = $"فرم ثبت آزمایش جدید بیمار {patient.PatientName}";
            this.Text = textForm;
        }

        private void GoToAddTestParameterMode()
        {
            cmbDoctor.Enabled = false;
            cmbTestMethod.Enabled = true;
            cmbUnit.Enabled = true;
            grbTestParameters.Enabled = true;
            btnAddTestAcceptionItem.BackColor = UiHelper.AppColors.Primary;
            btnAddTestAcceptionItem.ForeColor = Color.White;
            btnAddParameters.BackColor = UiHelper.AppColors.Success;
            btnAddParameters.ForeColor = Color.White;
        }

        private void GoToAddBaseInfo()
        {
            cmbDoctor.Enabled = true;
            cmbDoctor.SelectedIndex = 0;
            cmbTestMethod.Enabled = false;
            cmbUnit.Enabled = false;
            grbTestParameters.Enabled = false;
            txtSearchPatient.ReadOnly = false;
            dtpAcceptionDate.Enabled = true;
            grbBaseInfo.Enabled = true;
        }

        private void HasSelectedPatient(string patient)
        {
            if (string.IsNullOrWhiteSpace(patient)) return;
            btnTestAcceptionHeader.Visible = true;
            btnAddNewPatient.Visible = false;
        }

        private static void ClearFormTextBox(Control parent)
        {
            foreach (var control in parent.Controls)
            {
                if (control is TextBox t)
                {
                    t.Clear();
                }
            }
        }

        private void GoToAddMode()
        {
            btnAddTestAcceptionItem.Enabled = true;
            btnAddTestAcceptionItem.Text = "افزودن پارامتر";
            btnAddTestAcceptionItem.BackColor = UiHelper.AppColors.Primary;
            btnAddTestAcceptionItem.ForeColor = Color.White;
            //btnAddTestAcceptionItem.FlatStyle = FlatStyle.Flat;
            btnCancel.Enabled = false;
            btnAddParameters.Enabled = true;
            lstTestParameter.Visible = false;
            ClearFormTextBox(grbTestParameters);
        }

        private void GoToEditMode()
        {
            btnAddTestAcceptionItem.Enabled = true;
            btnAddTestAcceptionItem.Text = "ثبت تغییرات";
            //btnAddTestAcceptionItem.FlatStyle = FlatStyle.Flat;
            btnAddTestAcceptionItem.BackColor = UiHelper.AppColors.Warning;
            btnAddTestAcceptionItem.ForeColor = Color.Black;
            btnAddParameters.Enabled = false;
            btnCancel.Enabled = true;
        }

        private void UiButton()
        {
            btnAddTestAcceptionItem.BackColor = UiHelper.AppColors.Primary;
            btnAddTestAcceptionItem.ForeColor = Color.White;
            btnCancel.BackColor = UiHelper.AppColors.Secondary;
            btnCancel.ForeColor = Color.White;
            btnAddParameters.BackColor = UiHelper.AppColors.Success;
            btnAddParameters.ForeColor = Color.White;
        }

        /* private bool? GetResponseBoolean()
         {
             if (rdbPositive.Checked)
             {
                 return true;
             }
 
             if (rdbNegative.Checked)
             {
                 return false;
             }
 
             return null;
         } */

        #endregion

        #region DataBinders

        private void BindPatientList(string phrase)
        {
            var term = phrase.Trim();
            if (term.Length > 1)
            {
                var patientSearchList = _patientRepo.SearchPatient(term) ??
                                        new List<PatientSearchListItem>();
                _suppress = true;
                lstPatient.DisplayMember = "PatientFullInfo";
                lstPatient.ValueMember = "PatientId";
                lstPatient.DataSource = patientSearchList;
                _suppress = false;
                lstPatient.Visible = patientSearchList.Any();
            }
            else if (term.Length < 2)
            {
                lstPatient.Visible = false;
                lstPatient.DataSource = null;
            }
            else if (string.IsNullOrEmpty(term))
            {
                lstPatient.Visible = false;
                lstPatient.DataSource = null;
            }
        }

        private void BindTestParameterList(string phrase)
        {
            var term = phrase.Trim();
            if (term.Length > 1)
            {
                var testSearchList = _testRepo.TestSearch(term) ??
                                     new List<TestSearchListItem>();
                _suppress = true;
                lstTestParameter.DisplayMember = "TestName";
                lstTestParameter.ValueMember = "testId";
                lstTestParameter.DataSource = testSearchList;
                _suppress = false;
                lstTestParameter.Visible = testSearchList.Any();
            }
            else if (term.Length < 2)
            {
                lstTestParameter.Visible = false;
                lstTestParameter.DataSource = null;
            }
            else if (string.IsNullOrEmpty(term))
            {
                lstTestParameter.Visible = false;
                lstTestParameter.DataSource = null;
            }
        }

        private void BindDoctorList()
        {
            var doctorList = _doctorRepo.GetAllDoctors();
            doctorList.Insert(0, new Doctor
            {
                DoctorName = "...انتخاب کنید...",
                DoctorId = -1
            });
            cmbDoctor.DisplayMember = "DoctorName";
            cmbDoctor.ValueMember = "DoctorId";
            cmbDoctor.DataSource = doctorList;
        }

        private void BindDataGrid(IReadOnlyCollection<TestParameterTemp> testParameters)
        {
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            DataGrid.DataSource = testParameters;
        }

        #endregion

        public frmNewTest(Employee currentEmployee)
        {
            this._testRepo = new TestRepository();
            this._patientRepo = new PatientRepository();
            this._doctorRepo = new DoctorRepository();
            this._testAcceptionRepo = new TestAcceptionRepository();
            this._testMethodRepo = new TestMethodRepository();
            this._unitRepo = new UnitRepository();
            this._isPatientForm = false;
            this._currentEmployee = currentEmployee;

            InitializeComponent();

            DataGrid.AutoGenerateColumns = false;
            DataGrid.AllowUserToAddRows = false;
            DataGrid.DataSource = _TestParametersTemp;
            lstPatient.SelectedIndexChanged -= lstPatient_SelectedIndexChanged;
            lstPatient.SelectedIndexChanged += lstPatient_SelectedIndexChanged;
            lstPatient.Visible = false;
        }

        public frmNewTest(int patientId, AddNewPatientTestItem newPatientTest, Employee currentEmployee)
        {
            this._testRepo = new TestRepository();
            this._patientRepo = new PatientRepository();
            this._doctorRepo = new DoctorRepository();
            this._testAcceptionRepo = new TestAcceptionRepository();
            this._testMethodRepo = new TestMethodRepository();
            this._unitRepo = new UnitRepository();
            this._currentEmployee = currentEmployee;
            this._isPatientForm = true;
            this.PatientId = patientId;
            this._newPatientTest = newPatientTest;

            InitializeComponent();

            DataGrid.AutoGenerateColumns = false;
            DataGrid.AllowUserToAddRows = false;
            DataGrid.DataSource = _TestParametersTemp;
            lstPatient.SelectedIndexChanged -= lstPatient_SelectedIndexChanged;
            lstPatient.SelectedIndexChanged += lstPatient_SelectedIndexChanged;
            txtSearchPatient.ReadOnly = true;
            txtSearchPatient.Text = newPatientTest.PatientName;
            txtPatientAge.Text = newPatientTest.PatientAge.ToString();
            lstPatient.Visible = false;
        }

        private void frmNewTest_Load(object sender, EventArgs e)
        {
            BindDoctorList();
            UiButton();
            dtpAcceptionDate.Value = DateTime.Now;

            if (IsTestPatientForm)
            {
                grbTestParameters.Enabled = true;
                btnTestAcceptionHeader.Visible = true;
                btnTestAcceptionHeader.Enabled = false;
                btnAddNewPatient.Visible = false;
            }
            else if (!IsTestPatientForm)
            {
                if (_isPatientForm)
                {
                    btnTestAcceptionHeader.Visible = true;
                    btnAddNewPatient.Visible = false;
                }
                else if (!_isPatientForm)
                {
                    btnTestAcceptionHeader.Visible = false;
                    btnAddNewPatient.Visible = true;
                }
            }
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            var frm = new frmNewPatient(_currentEmployee)
            {
                AddNewPatientFromTest = true
            };
            frm.NewPatient += NewPatientSaved;
            frm.ShowDialog();
        }

        private void txtSearchPatient_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchPatient.Text))
            {
                btnTestAcceptionHeader.Visible = false;
                btnAddNewPatient.Visible = true;
                txtPatientAge.Text = "";
                cmbDoctor.SelectedIndex = 0;
            }
            else
            {
                BindPatientList(txtSearchPatient.Text);
            }
        }

        private void lstPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppress) return;
            if (lstPatient.SelectedValue == null) return;

            if (!int.TryParse(lstPatient.SelectedValue.ToString(), out var selectedPatientId)) return;

            var p = _patientRepo.GetPatientByPatientId(selectedPatientId);
            if (p == null) return;

            _suppress = true;

            var age = new PersianDateTime();
            txtPatientAge.Text = age.GetAge((DateTime) p.Data.BirthDate).ToString();
            txtSearchPatient.Text = p.Data.PatientName;
            HasSelectedPatient(txtSearchPatient.Text);
            PatientId = p.Data.PatientId;
            txtSearchPatient.Focus();
            lstPatient.Visible = false;
            lstPatient.DataSource = null;
            _suppress = false;
        }

        private void btnTestAcceptionHeader_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientAge.Text))
            {
                err.SetError(txtPatientAge, "سن بیمار الزامیست");
                return;
            }

            err.Clear();

            if (string.IsNullOrWhiteSpace(dtpAcceptionDate.Value.ToString()))
            {
                err.SetError(dtpAcceptionDate, "تاریخ الزامیست");
                return;
            }

            err.Clear();

            if (cmbDoctor.SelectedIndex <= 0)
            {
                err.SetError(cmbDoctor, "نام پزشک معالج الزامیست");
                return;
            }

            err.Clear();

            if (string.IsNullOrEmpty(PatientId.ToString()))
            {
                MessageBox.Show("لطفا بیمار را انتخاب نمائید!", "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading);
                return;
            }

            var testAcceptionHeader = new TestAcceptionHeader
            {
                AcceptionDate = (DateTime) dtpAcceptionDate.Value,
                PatientAge = Convert.ToInt32(txtPatientAge.Text),
                PatientId = PatientId,
                DoctorId = Convert.ToInt32(cmbDoctor.SelectedValue.ToString()),
                RegistrationEmployeeId = _currentEmployee.EmployeeId
            };

            var addNewTestAcceptionHeader = _testAcceptionRepo.AddNewTestAcceptionHeader(testAcceptionHeader);
            if (addNewTestAcceptionHeader.IsSuccess)
            {
                txtTestAcceptionHeaderId.Text = addNewTestAcceptionHeader.Data.TestAcceptionHeaderId.ToString();
                _testAcceptionHeaderId = addNewTestAcceptionHeader.Data.TestAcceptionHeaderId;
                btnAddNewPatient.Visible = false;
                btnTestAcceptionHeader.Enabled = false;
                txtSearchPatient.ReadOnly = true;
                dtpAcceptionDate.Enabled = false;
                cmbDoctor.Enabled = false;
                GoToAddTestParameterMode();
            }
            else if (addNewTestAcceptionHeader.ErrorCode == ErrorCode.ValidationError)
            {
                MessageBox.Show(addNewTestAcceptionHeader.Message, "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading);
            }
            else if (addNewTestAcceptionHeader.ErrorCode == ErrorCode.DatabaseError)
            {
                MessageBox.Show(addNewTestAcceptionHeader.Message, "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtSearchTestParameter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchTestParameter.Text))
            {
                txtTestMethod.Text = "";
                txtUnit.Text = "";
            }
            else
            {
                BindTestParameterList(txtSearchTestParameter.Text);
            }
        }

        private void btnAddTestAcceptionItem_Click(object sender, EventArgs e)
        {
            if (_editingTempId.HasValue)
            {
                var item = _TestParametersTemp.FirstOrDefault(x => x.TempId == _editingTempId.Value);
                if(item == null) return;

                // جلوگیری از انتخاب پارامتر تکراری
                var duplicate = _TestParametersTemp.Any(x => x.TestId == _testId && x.TempId != _editingTempId.Value);
                if (duplicate)
                {
                    MessageBox.Show("این پارامتر قبلاً در لیست وجو دارد!", "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    return;
                }

                item.TestId = _testId;
                item.TestMethodId = _testMethodId;
                item.UnitId = _unitId;
                item.TestAcceptionHeaderId = _testAcceptionHeaderId;
                item.TestName = txtSearchTestParameter.Text;
                item.TestMethodName = txtTestMethod.Text;
                item.UnitName = txtUnit.Text;

                // تازه سازی Grid
                _TestParametersTemp.ResetBindings();

                //خروج از حالت ویرایش
                _editingTempId = null;
                GoToAddMode();
                ClearFormTextBox(grbTestParameters);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtSearchTestParameter.Text))
                {
                    err2.SetError(txtSearchTestParameter, "پارامتر آزمایش الزامیست");
                    return;
                }
                err2.Clear();

                if (_TestParametersTemp != null)
                {
                    var alreadyExists = _TestParametersTemp.Any(x => x.TestId == _testId);
                    if (alreadyExists)
                    {
                        MessageBox.Show("این آزمایش قبلاً به لیست اضافه شده است!", "هشدار",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
                        return;
                    }
                }

                var newItem = new TestParameterTemp
                {
                    TestAcceptionHeaderId = _testAcceptionHeaderId,
                    TestId = _testId,
                    TestMethodId = _testMethodId,
                    UnitId = _unitId,
                    TestName = txtSearchTestParameter.Text,
                    TestMethodName = txtTestMethod.Text,
                    UnitName = txtUnit.Text
                };
                _TestParametersTemp?.Add(newItem);
                ClearFormTextBox(grbTestParameters);
                txtSearchTestParameter.Focus();
            }
        }

        private void lstTestParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppress) return;
            if (lstTestParameter.SelectedValue == null) return;

            if (!int.TryParse(lstTestParameter.SelectedValue.ToString(), out var selectedTestId)) return;

            var t = _testRepo.GetTestItemsByTestId(selectedTestId);
            if (t == null) return;

            _suppress = true;

            _testId = t.Data.TestId;
            txtSearchTestParameter.Text = t.Data.TestName;
            _testMethodId = t.Data.TestMethodId;
            txtTestMethod.Text = t.Data.TestMethodName;
            _unitId = t.Data.UnitId;
            txtUnit.Text = t.Data.UnitName;
            txtSearchTestParameter.Focus();

            lstTestParameter.Visible = false;
            lstTestParameter.DataSource = null;
            _suppress = false;
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var tempId = (Guid) DataGrid.Rows[e.RowIndex].Cells["clmnTempId"].Value;
            switch (e.ColumnIndex)
            {
                case 8: // Update Row
                    var editItem = _TestParametersTemp.FirstOrDefault(x => x.TempId == tempId);
                    if (editItem != null)
                    {
                        _editingTempId = editItem.TempId;
                        _testId = editItem.TestId;
                        txtSearchTestParameter.Text = editItem.TestName;
                        txtTestMethod.Text = editItem.TestMethodName;
                        txtUnit.Text = editItem.UnitName;
                        GoToEditMode();
                    }
                    break;

                case 9: // Delete Row
                    var item = _TestParametersTemp.FirstOrDefault(x => x.TempId == tempId);
                    if (item != null)
                    {
                        var msgDelete = $"از حذف پارامتر {item.TestName} مطمئن هستید؟";
                        var result = MessageBox.Show(msgDelete, "هشدار",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2,
                            MessageBoxOptions.RtlReading);

                        if (result != DialogResult.Yes) return;
                        _TestParametersTemp.Remove(item);
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFormTextBox(grbTestParameters);
            GoToAddMode();
        }

        private void btnAddParameters_Click(object sender, EventArgs e)
        {
            if (_TestParametersTemp.Count == 0)
            {
                MessageBox.Show("حداقل یک پارامتر را وارد نمائید!", "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }
            else
            {
                var result = _testAcceptionRepo.AddNewTestAcceptionItems(_TestParametersTemp);
                if (result.IsSuccess)
                {
                    MessageBox.Show("پارامتر(های) آزمایش با موفقیت ثبت شد.", "پیام",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);

                    ClearFormTextBox(grbTestParameters);
                    ClearFormTextBox(grbBaseInfo);
                    GoToAddBaseInfo();
                    _TestParametersTemp.Clear();

                }
                else if (result.ErrorCode == ErrorCode.DatabaseError)
                {
                    MessageBox.Show(result.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("خطای نامشخص! - با پشتیبانی تماس بگیرید.", "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                }
            }
        }
    }
}
