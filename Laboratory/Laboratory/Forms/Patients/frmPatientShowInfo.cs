using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel.Models;
using Framework;

namespace Laboratory.Forms.Patients
{
    public partial class frmPatientShowInfo : Form
    {
        #region GlobalVariables

        public Patient CurrentPatient { get; }

        #endregion

        #region UtilityFunctions

        private void ReadonlyTextBox()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox t)
                {
                    t.ReadOnly = true;
                }
            }
        }

        #endregion
        public frmPatientShowInfo()
        {
            InitializeComponent();
        }

        public frmPatientShowInfo(Patient currentPatient)
        {
            InitializeComponent();
            this.CurrentPatient = currentPatient;
        }

        private void frmPatientShowInfo_Load(object sender, EventArgs e)
        {
            ReadonlyTextBox();
            txtPatientName.Text = CurrentPatient.PatientName;
            txtNationalCode.Text = CurrentPatient.NationalCode;
            txtMobile.Text = CurrentPatient.Mobile;
            txtBirthDate.Text = PersianDateTime.ConvertDateTimeToPersianDateTime(CurrentPatient.BirthDate);
            txtDescription.Text = CurrentPatient.Description;
        }
    }
}
