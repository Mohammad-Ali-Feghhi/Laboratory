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
using DomainModel.Results;

namespace Laboratory.Forms.Employees
{
    public partial class frmInactiveEmployee : Form
    {
        #region GlobalVariables

        private readonly EmployeeRepository _repo;
        private int _employeeId;

        #endregion

        #region DataBinders

        private void BindGrid()
        {
            DataGrid.AutoGenerateColumns = false;
            DataGrid.DataSource = null;
            DataGrid.DataSource = _repo.GetAllInactiveEmployees();
        }
        
        #endregion
        public frmInactiveEmployee()
        {
            InitializeComponent();
            this._repo = new EmployeeRepository();
        }

        private void frmInactiveEmployee_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _employeeId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells[0].Value);
            if (e.ColumnIndex == 5)
            {
                var employee = _repo.EnableEmployee(_employeeId);
                if (employee.IsSuccess)
                {
                    BindGrid();
                }

                if(employee.ErrorCode == ErrorCode.UserNotFound)
                {
                    MessageBox.Show(employee.Message, "هشدار",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                    return;
                }

                if(employee.ErrorCode == ErrorCode.DatabaseError)
                {
                    MessageBox.Show(employee.Message, "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
