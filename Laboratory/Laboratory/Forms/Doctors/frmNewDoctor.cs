using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess;
using DomainModel.Models;
using DomainModel.Results;

namespace Laboratory.Forms.Doctors
{
    public partial class frmNewDoctor : Form
    {
        #region GlobalVariables

        private readonly DoctorRepository _repo;

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

            txtDoctorName.Focus();
            rdbEnable.Checked = true;
            rdbDisable.Checked = false;
        }

        #endregion
        public frmNewDoctor()
        {
            InitializeComponent();
            this._repo = new DoctorRepository();
        }

        private void frmNewDoctor_Load(object sender, EventArgs e)
        {
            txtDoctorName.Focus();
        }

        private void txtLicenseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLicenseNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text) ||
                string.IsNullOrEmpty(txtLicenseNumber.Text))
            {
                txtLicenseNumber.BackColor = Color.White;
                return;
            }
            txtLicenseNumber.BackColor = txtLicenseNumber.TextLength < 4 ? Color.LightPink : Color.White;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorName.Text))
            {
                err.SetError(txtDoctorName, "نام دکتر الزامیست");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                err.SetError(txtLicenseNumber, "شماره نظام پزشکی الزامیست");
                return;
            }
            err.Clear();

            var existDoctor = _repo.HasExistMedicalLicenseNumber(txtLicenseNumber.Text);
            if (existDoctor.ErrorCode == ErrorCode.ValidationError)
            {
                MessageBox.Show(existDoctor.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                return;
            }
            if (existDoctor.ErrorCode == ErrorCode.DatabaseError)
            {
                MessageBox.Show(existDoctor.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            var newDoctor = new Doctor
            {
                DoctorName = txtDoctorName.Text,
                MedicalLicenseNumber = txtLicenseNumber.Text,
                Description = txtDescription.Text,
                IsEnabled = rdbEnable.Checked
            };
            var result = _repo.AddNewDoctor(newDoctor);
            if (result.IsSuccess)
            {
                var successMsg = $"اطلاعات دکتر {result.Data.DoctorName} با موفقیت ثبت شد.";
                MessageBox.Show(successMsg, "پیام",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                ClearForm();
            }
            else if (result.ErrorCode == ErrorCode.ValidationError)
            {
                MessageBox.Show(result.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }
            else if (result.ErrorCode == ErrorCode.DatabaseError)
            {
                MessageBox.Show(result.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }
        }
    }
}
