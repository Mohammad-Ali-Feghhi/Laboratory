using System;
using System.Windows.Forms;
using DomainModel.Models;
using Framework;
using Laboratory.Forms.Doctors;
using Laboratory.Forms.Employees;
using Laboratory.Forms.Patients;
using Laboratory.Forms.Tests;

namespace Laboratory
{
    public partial class frmMainBoard : Form
    {
        #region GlobalVariables

        private readonly Employee _currentUser;
        public bool ForceClose { get; set; } = false;

        #endregion

        #region UtilityFunctions

        public void RefreshUsername(string username)
        {
            lblUsername.Text = username;
        }


        #endregion
        public frmMainBoard()
        {
            InitializeComponent();
        }

        public frmMainBoard(Employee currentUser)
        {
            InitializeComponent();
            this._currentUser = currentUser;
        }

        private void frmMainBoard_Load(object sender, EventArgs e)
        {
            lblUsername.Text = _currentUser.Username;
            lblTime.Text = PersianDateTime.GetPersianTime();
            lblDate.Text = PersianDateTime.GetPersianDate();
        }

        private void frmMainBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ForceClose)
            {
                return;
            }

            const string msg = @"از بستن نرم افزار مطمئن هستی؟";
            if (MessageBox.Show(msg, "هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                ForceClose = true;
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = PersianDateTime.GetPersianTime();
        }

        private void ثبتکارمندجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInMyParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmBasicEmployeeInfo)
                {
                    mdiChild.Activate();
                    isAlreadyInMyParent = true;
                }
            }

            if (!isAlreadyInMyParent)
            {
                var frm = new frmBasicEmployeeInfo
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void تغییررمزعبورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInMyParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmOldPassword)
                {
                    mdiChild.Activate();
                    isAlreadyInMyParent = true;
                }
            }

            if (!isAlreadyInMyParent)
            {
                var frm = new frmOldPassword(_currentUser)
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void لیستکارمندانغیرفعالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInMyParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmInactiveEmployee)
                {
                    mdiChild.Activate();
                    isAlreadyInMyParent = true;
                }
            }

            if (!isAlreadyInMyParent)
            {
                var frm = new frmInactiveEmployee()
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void جستجووویرایشکارمندToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInMyParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmEmployee)
                {
                    mdiChild.Activate();
                    isAlreadyInMyParent = true;
                }
            }

            if (!isAlreadyInMyParent)
            {
                var frm = new frmEmployee(_currentUser)
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void ثبتپزشکجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInMyParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmNewDoctor)
                {
                    mdiChild.Activate();
                    isAlreadyInMyParent = true;
                }
            }

            if (!isAlreadyInMyParent)
            {
                var frm = new frmNewDoctor
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void لیستپزشکانغیرفعالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInMyParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmInactiveDoctors)
                {
                    mdiChild.Activate();
                    isAlreadyInMyParent = true;
                }
            }

            if (!isAlreadyInMyParent)
            {
                var frm = new frmInactiveDoctors
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void جستجووویرایشپزشکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInMyParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmDoctors)
                {
                    mdiChild.Activate();
                    isAlreadyInMyParent = true;
                }
            }

            if (!isAlreadyInMyParent)
            {
                var frm = new frmDoctors
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void ثبتمشتریجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInMyParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmNewPatient)
                {
                    mdiChild.Activate();
                    isAlreadyInMyParent = true;
                }
            }

            if (!isAlreadyInMyParent)
            {
                var frm = new frmNewPatient(_currentUser)
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void جستجووویرایشمشتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInMyParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmPatients)
                {
                    mdiChild.Activate();
                    isAlreadyInMyParent = true;
                }
            }

            if (!isAlreadyInMyParent)
            {
                var frm = new frmPatients(_currentUser)
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void ثبتپارامترهایآزمایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmNewTestParameter)
                {
                    mdiChild.Activate();
                    isAlreadyInParent = true;
                }
            }

            if (!isAlreadyInParent)
            {
                var frm = new frmNewTestParameter
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void ثبتبازهمرجعجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isAlreadyInParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmNewTestRange)
                {
                    mdiChild.Activate();
                    isAlreadyInParent = true;
                } 
            }

            if (!isAlreadyInParent)
            {
                var frm = new frmNewTestRange
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void ثبتآزمایشجدیدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var isAlreadyInParent = false;
            foreach (var mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmNewTest)
                {
                    mdiChild.Activate();
                    isAlreadyInParent = true;
                }
            }

            if (!isAlreadyInParent)
            {
                var frm = new frmNewTest(_currentUser)
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }
    }
}
