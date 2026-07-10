using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccess;
using DomainModel.BussinessModel;
using Framework;

namespace Laboratory.Forms.Patients
{
    public partial class frmPatientTestAcceptionList : Form
    {
        #region GlobalVariables
        public int PatientId { get; }
        private int _testAcceptionHeaderId;
        private readonly PatientRepository _repo;

        #endregion

        #region DataBinders

        private void BindGrid(int patientId)
        {
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            var patientTestListItem = new List<PatientTestListItem>();
            var testList = _repo.GetPatientTestListByPatientId(patientId);
            foreach (var item in testList)
            {
                var list = new PatientTestListItem
                {
                    TestAcceptionHeaderId = item.TestAcceptionHeaderId,
                    DoctorId = item.DoctorId,
                    DoctorName = item.DoctorName,
                    RegistrationEmployeeId = item.RegistrationEmployeeId,
                    RegistrationEmployeeName = item.RegistrationEmployeeName,
                    AcceptionDate = item.AcceptionDate,
                    AcceptionDatePersianDateTime = PersianDateTime.ConvertDateTimeToPersianDateTime(item.AcceptionDate)
                };
                patientTestListItem.Add(list);
            }

            if (!patientTestListItem.Any())
            {
                DataGrid.DataSource = null;
                DataGrid.AllowUserToAddRows = false;
            }
            else
            {
                DataGrid.DataSource = patientTestListItem;
            }
        }

        #endregion
        public frmPatientTestAcceptionList()
        {
            InitializeComponent();
        }

        public frmPatientTestAcceptionList(int patientId)
        {
            InitializeComponent();
            this.PatientId = patientId;
            this._repo = new PatientRepository();
        }

        private void frmPatientTestAcceptionList_Load(object sender, EventArgs e)
        {
            BindGrid(PatientId);
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _testAcceptionHeaderId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[0].Value);

            if (e.ColumnIndex == 6) // Show Test Information
            {
                
            }

            if (e.ColumnIndex == 7) // Edit
            {
                
            }

            if (e.ColumnIndex == 8) // Delete
            {
                
            }
        }
    }
}
