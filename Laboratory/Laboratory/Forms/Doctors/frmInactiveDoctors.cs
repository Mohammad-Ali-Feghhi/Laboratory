using System;
using System.Windows.Forms;
using DataAccess;
using DomainModel.Results;

namespace Laboratory.Forms.Doctors
{
    public partial class frmInactiveDoctors : Form
    {
        #region GlobalVariables

        private readonly DoctorRepository _repo;
        private int _doctorId;

        #endregion

        #region DataBinders

        private void BindGrid()
        {
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            DataGrid.DataSource = _repo.GetAllDeactiveDoctors();
        }

        #endregion
        public frmInactiveDoctors()
        {
            InitializeComponent();
            this._repo = new DoctorRepository();
        }

        private void frmInactiveDoctors_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _doctorId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[0].Value);
            if (e.ColumnIndex == 4)
            {
                var result = _repo.EnableDoctor(_doctorId);
                if (result.IsSuccess)
                {
                    BindGrid();
                }

                if (result.ErrorCode == ErrorCode.UserNotFound)
                {
                    MessageBox.Show(result.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    return;
                }

                if (result.ErrorCode == ErrorCode.DatabaseError)
                {
                    MessageBox.Show(result.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
