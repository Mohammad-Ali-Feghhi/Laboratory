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
using DomainModel.BussinessModel;
using DomainModel.Models;
using Framework;
using Laboratory.Forms.Patients;

namespace Laboratory.Forms.Tests
{
    public partial class frmNewTest : Form
    {
        #region GlobalVariables

        private readonly PatientRepository _patientRepo;
        private readonly DoctorRepository _doctorRepo;
        private readonly TestAcceptionRepository _testAcceptionRepo;
        public int PatientId { get; }
        private readonly bool _isPatientForm;
        private AddNewPatientTestItem _newPatientTest;
        private readonly Employee _currentEmployee;
        private bool _suppress;

        #endregion

        #region UtilityFunction

        private void NewPatientSaved(Patient patient)
        {
            txtSearchPatient.Text = patient.PatientName;
            txtSearchPatient.ReadOnly = true;
            lstPatient.Visible = false;
            var age = new PersianDateTime();
            txtPatientAge.Text = age.GetAge((DateTime)patient.BirthDate).ToString();
            btnAddNewPatient.Visible = false;
            btnRegisterTest.Visible = true;
            var textForm = $"فرم ثبت آزمایش جدید بیمار {patient.PatientName}";
            this.Text = textForm;
        }

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

        #endregion
        public frmNewTest(Employee currentEmployee)
        {
            this._patientRepo = new PatientRepository();
            this._doctorRepo = new DoctorRepository();
            this._testAcceptionRepo = new TestAcceptionRepository();
            this._isPatientForm = false;
            this._currentEmployee = currentEmployee;

            InitializeComponent();

            lstPatient.SelectedIndexChanged -= lstPatient_SelectedIndexChanged;
            lstPatient.SelectedIndexChanged += lstPatient_SelectedIndexChanged;
            lstPatient.Visible = false;
        }

        public frmNewTest(int patientId, AddNewPatientTestItem newPatientTest)
        {
            this._patientRepo = new PatientRepository();
            this._doctorRepo = new DoctorRepository();
            this._testAcceptionRepo = new TestAcceptionRepository();
            this._isPatientForm = true;
            this.PatientId = patientId;
            this._newPatientTest = newPatientTest;

            InitializeComponent();

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
            dtpAcceptionDate.Value = DateTime.Now;

            if (_isPatientForm)
            {
                btnRegisterTest.Visible = true;
                btnAddNewPatient.Visible = false;
            }
            else if (!_isPatientForm)
            {
                btnRegisterTest.Visible = false;
                btnAddNewPatient.Visible = true;
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
            BindPatientList(txtSearchPatient.Text);
        }

        private void lstPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppress) return;
            if (lstPatient.SelectedValue == null) return;

            if(!int.TryParse(lstPatient.SelectedValue.ToString(), out var selectedPatientId)) return;

            var p = _patientRepo.GetPatientByPatientId(selectedPatientId);
            if (p == null) return;

            _suppress = true;

            var age = new PersianDateTime();
            txtPatientAge.Text = age.GetAge((DateTime)p.Data.BirthDate).ToString();
            txtSearchPatient.Text = p.Data.PatientName;
            txtSearchPatient.Focus();

            lstPatient.Visible = false;
            lstPatient.DataSource = null;
            _suppress = false;
        }
    }
}
