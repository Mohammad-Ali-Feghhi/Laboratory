using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess;
using DomainModel.Models;
using DomainModel.Results;

namespace Laboratory.Forms.Doctors
{
    public partial class frmDoctors : Form
    {
        #region GlobalVariables

        private readonly DoctorRepository _repo;
        private int _doctorId;
        private string _doctorName;

        #endregion

        #region DataBinders

        private void BindGrid()
        {
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            DataGrid.DataSource = _repo.GetAllDoctors();
        }

        private void BindGrid(string phrase)
        {
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            DataGrid.DataSource = _repo.SearchDoctor(phrase.Trim());
        }

        private void UpdateDoctor()
        {
            var newDoctor = new Doctor
            {
                DoctorId = _doctorId,
                DoctorName = txtDoctorName.Text,
                MedicalLicenseNumber = txtLicenseNumber.Text,
                Description = txtDescription.Text,
                IsEnabled = rdbEnable.Checked,
                UpdateTime = DateTime.Now,
                IsUpdated = true
            };

            var resultUpdate = _repo.UpdateDoctor(newDoctor);
            if (resultUpdate.IsSuccess)
            {
                MessageBox.Show("اطلاعات با موفقیت بروز رسانی شد.", "پیام",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                GotoCancelMode();
                ClearForm();
            }

            else if (resultUpdate.ErrorCode == ErrorCode.ValidationError)
            {
                MessageBox.Show(resultUpdate.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }

            else if (resultUpdate.ErrorCode == ErrorCode.UserNotFound)
            {
                MessageBox.Show(resultUpdate.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }

            else if (resultUpdate.ErrorCode == ErrorCode.DatabaseError)
            {
                MessageBox.Show(resultUpdate.Message, "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }
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

            rdbEnable.Checked = false;
            rdbDisable.Checked = false;
            txtDoctorName.Focus();
        }

        private void GoToEditMode()
        {
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void GotoCancelMode()
        {
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
        }

        #endregion
        public frmDoctors()
        {
            InitializeComponent();
            this._repo = new DoctorRepository();
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _doctorId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[0].Value);
            _doctorName = DataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (e.ColumnIndex == 5) //Edit
            {
                var doctor = _repo.GetDoctorByDoctorId(_doctorId);
                if (doctor.ErrorCode == ErrorCode.UserNotFound)
                {
                    MessageBox.Show(doctor.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                    return;
                }

                if (doctor.ErrorCode == ErrorCode.DatabaseError)
                {
                    MessageBox.Show(doctor.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    return;
                }

                if (doctor.IsSuccess)
                {
                    txtDoctorName.Text = doctor.Data.DoctorName;
                    txtLicenseNumber.Text = doctor.Data.MedicalLicenseNumber;
                    txtDescription.Text = doctor.Data.Description;
                    if ((bool) doctor.Data.IsEnabled)
                    {
                        rdbEnable.Checked = true;
                    }
                    else
                    {
                        rdbDisable.Checked = true;
                    }

                    GoToEditMode();
                }
            }

            if (e.ColumnIndex == 6) //Delete
            {
                var msg = $"آیا از حذف دکتر {_doctorName} مطمئن هستید؟";
                if (MessageBox.Show(msg, "هشدار",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    var result = _repo.DeleteDoctor(_doctorId);
                    if (result.IsSuccess)
                    {
                        BindGrid();
                        GotoCancelMode();
                        ClearForm();
                    }

                    else if (result.ErrorCode == ErrorCode.ValidationError)
                    {
                        MessageBox.Show(result.Message, "هشدار",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
                    }
                    else if (result.ErrorCode == ErrorCode.UserNotFound)
                    {
                        MessageBox.Show(result.Message, "هشدار",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
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

        private void frmDoctors_Load(object sender, EventArgs e)
        {
            BindGrid();
            ClearForm();
            GotoCancelMode();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GotoCancelMode();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorName.Text) || txtDoctorName.Text.Length < 3)
            {
                err.SetError(txtDoctorName, "نام پزشک الزامیست");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text) || txtLicenseNumber.Text.Length < 5)
            {
                err.SetError(txtLicenseNumber, "شماره نظام پزشکی الزامیست");
                return;
            }
            err.Clear();

            var existLicenseNumber = _repo.GetDoctorByDoctorId(_doctorId);
            if (existLicenseNumber.Data.MedicalLicenseNumber == txtLicenseNumber.Text)
            {
               UpdateDoctor();
               BindGrid();
            }
            else
            {
                var doctor = _repo.HasExistMedicalLicenseNumber(txtLicenseNumber.Text);
                if (doctor.IsSuccess)
                {
                    UpdateDoctor();
                    BindGrid();
                }
                else if (doctor.ErrorCode == ErrorCode.ValidationError)
                {
                    MessageBox.Show(doctor.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                }
                else if (doctor.ErrorCode == ErrorCode.DatabaseError)
                {
                    MessageBox.Show(doctor.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
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

        private void txtLicenseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                BindGrid();
            }
            else if (txtSearch.Text.Length > 1)
            {
                BindGrid(txtSearch.Text);
            }
        }
    }
}
