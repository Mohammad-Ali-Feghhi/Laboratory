using System;
using System.Windows.Forms;
using DataAccess;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace Laboratory.Forms.Tests
{
    public partial class frmNewTestRange : Form
    {
        #region UtilityFunctions
        private void ClearForm()
        {
            foreach (var ctrl in Controls)
            {
                if (ctrl is TextBox t)
                {
                    t.Text = "";
                }
            }

            ckbStar.Checked = false;
            ckbEmergency.Checked = false;
            txtTestName.Focus();
        }

        #endregion

        #region GlobalVariables

        private readonly TestRepository _testRepo;
        private readonly TestRangeRepository _testRangeRepo;
        private int _testId;

        #endregion

        #region DataBinders
        private void BindTestListBox()
        {
            lstTestName.DataSource = _testRepo.GetAllTests();
            lstTestName.DisplayMember = "TestName";
            lstTestName.ValueMember = "TestId";
        }
        private void SearchTest(string phrase)
        {
            var tests = _testRepo.TestSearch(phrase);
            lstTestName.DisplayMember = "TestName";
            lstTestName.ValueMember = "TestId";
            lstTestName.DataSource = tests;
        }

        #endregion
        public frmNewTestRange()
        {
            this._testRepo = new TestRepository();
            this._testRangeRepo = new TestRangeRepository();
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (lstTestName.SelectedIndex < 0)
            {
                err.SetError(txtTestName, "نام آزمایش الزامی است");
                return;
            }
            err.Clear();
            if (string.IsNullOrWhiteSpace(txtFrom.Text))
            {
                err.SetError(txtFrom, "بازه الزامی است");
                return;
            }
            err.Clear();
            if (string.IsNullOrWhiteSpace(txtTo.Text))
            {
                err.SetError(txtTo, "بازه الزامی است");
                return;
            }
            err.Clear();

            var newTestRange = new TestRange
            {
                TestId = _testId,
                FromValue = Convert.ToDouble(txtFrom.Text),
                ToValue = Convert.ToDouble(txtTo.Text),
                HasStar = ckbStar.Checked,
                IsEmergency = ckbEmergency.Checked,
                Description = txtDescription.Text
            };

            var result = _testRangeRepo.AddNewTestRange(newTestRange);
            if (result.IsSuccess)
            {
                MessageBox.Show("با موفقیت ثبت شد.", "پیام",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                ClearForm();
                return;
            }

            if (result.ErrorCode == ErrorCode.ValidationError)
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
                                MessageBoxIcon.Error);
            }
        }

        private void frmNewTestRange_Load(object sender, EventArgs e)
        {
            ClearForm();
            BindTestListBox();
        }

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if(char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.')
            {
                if (txtFrom.Text.Length == 0)
                {
                    e.Handled = true;
                    return;
                }

                if (txtFrom.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
                return;
            }

            e.Handled = true;
        }

        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if(char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.')
            {
                if (txtTo.Text.Length == 0)
                {
                    e.Handled = true;
                    return;
                }

                if (txtTo.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
                return;
            }

            e.Handled = true;
        }

        private void lstTestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTestName.SelectedItem != null)
            {
                if (lstTestName.SelectedItem is TestSearchListItem item)
                {
                    _testId = item.TestId;
                }
                else if (lstTestName.SelectedItem is Test test)
                {
                    _testId = test.TestId;
                }
            }
        }

        private void txtTestName_TextChanged(object sender, EventArgs e)
        {
            if (txtTestName.Text.Length >= 1)
            {
                SearchTest(txtTestName.Text);
            }
            else
            {
                BindTestListBox();
            }
        }

        private void lstTestName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (lstTestName.SelectedIndex < lstTestName.Items.Count - 1)
                {
                    lstTestName.SelectedIndex++;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (lstTestName.SelectedIndex > 0)
                {
                    lstTestName.SelectedIndex--;
                }
            }
        }
    }
}
