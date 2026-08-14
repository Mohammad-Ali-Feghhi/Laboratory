using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DomainModel.Models;
using Framework;
using Laboratory.Forms.Doctors;
using Laboratory.Forms.Employees;
using Laboratory.Forms.Patients;
using Laboratory.Forms.Tests;
using Laboratory.Properties;
using Laboratory.Quick_Access;

namespace Laboratory
{
    public partial class frmMainBoard : Form
    {
        #region GlobalVariables

        private readonly Employee _currentUser;
        public bool ForceClose { get; set; } = false;
        private readonly List<QuickAccessItem> _quickAccessListItem = new List<QuickAccessItem>();

        #endregion

        #region QuickAccessMenu

        private void OpenNewTest()
        {
            ثبتآزمایشجدیدToolStripMenuItem1_Click(null, EventArgs.Empty);
        }
        #endregion

        #region UtilityFunctions

        public void RefreshUsername(string username)
        {
            lblUsername.Text = username;
        }

        private void QuickAccessListItems()
        {
            flpLeft.Controls.Clear();
            foreach (var item in _quickAccessListItem)
            {
                var control = new QuickAccessListItem
                {
                    Title = item.Title, 
                    Description = item.Description, 
                    Icon = item.Icon, 
                    OpenForm = item.OpenForm
                };
                control.ItemClicked += QuickItem_click;
                flpLeft.Controls.Add(control);
            }
        }

        private void QuickItem_click(object sender, EventArgs e)
        {
            var control = (QuickAccessListItem) sender;
            control.OpenForm?.Invoke();
        }

        private void OpenMdiForm(Form frm)
        {
            flpLeft.Visible = false;
            pnlRight.Visible = false;
            frm.FormClosed += (s, e) =>
            {
                flpLeft.Visible = true;
                pnlRight.Visible = true;
            };
            frm.Show();
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
            this._quickAccessListItem = new List<QuickAccessItem>
            {
                new QuickAccessItem
                {
                    Id = 1,
                    Title = "پذیرش بیمار",
                    Description = "در این بخش اطلاعات بیمار و آزمایش‌های مورد نظر ثبت اولیه می‌شود.",
                    Icon = Resources.Patient_Admission,
                    OpenForm = OpenNewTest
                },
                new QuickAccessItem
                {
                    Id = 2,
                    Title = "ثبت نتیجه",
                    Description = "در این بخش می‌توان جواب آزمایش بیمار را ثبت و یا ویرایش کرد.",
                    Icon = Resources.Lab_Report
                },
            };
            QuickAccessListItems();
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
                OpenMdiForm(frm);
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
                    MdiParent = this,
                    MinimizeBox = false,
                    MaximizeBox = false,
                    ControlBox = true
                };
                OpenMdiForm(frm);
            }
        }
    }
}
