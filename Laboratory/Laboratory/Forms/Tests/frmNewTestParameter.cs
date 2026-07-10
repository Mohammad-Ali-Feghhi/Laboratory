using System;
using System.Windows.Forms;
using DataAccess;
using DomainModel.Models;
using DomainModel.Results;

namespace Laboratory.Forms.Tests
{
    public partial class frmNewTestParameter : Form
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

            cmbUnit.SelectedIndex = 0;
            cmbResponseType.SelectedIndex = 0;
            cmbSampleType.SelectedIndex = 0;
            cmbTestCategory.SelectedIndex = 0;
            cmbTestMethod.SelectedIndex = 0;
            txtTestName.Focus();
        }

        #endregion

        #region DataBinders

        private void BindUnitComboBox()
        {
            var units = _unitRepo.GetAllUnits();
            units.Insert(0, new Unit
            {
                UnitName = @"...انتخاب کنید...", 
                UnitId = -1
            });
            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.ValueMember = "UnitId";
            cmbUnit.DataSource = units;
        }
        private void BindSampleTypeComboBox()
        {
            var sampleTypes = _sampleTypeRepo.GetAllSampleTypes();
            sampleTypes.Insert(0, new SampleType
            {
                SampleTypeName = @"...انتخاب کنید...", 
                SampleTypeId = -1
            });
            cmbSampleType.DisplayMember = "SampleTypeName";
            cmbSampleType.ValueMember = "SampleTypeId";
            cmbSampleType.DataSource = sampleTypes;
        }
        private void BindTestMethodComboBox()
        {
            var testMethods = _testMethodRepo.GetAllTestMethods();
            testMethods.Insert(0, new TestMethod
            {
                TestMethodName = "...انتخاب کنید...", 
                TestMethodId = -1
            });
            cmbTestMethod.DisplayMember = "TestMethodName";
            cmbTestMethod.ValueMember = "TestMethodId";
            cmbTestMethod.DataSource = testMethods;
        }
        private void BindTestCategoryComboBox()
        {
            var testCategories = _testCategoryRepo.GetAllTestCategories();
            testCategories.Insert(0, new TestCategory
            {
                TestCategoryName = "...انتخاب کنید...", 
                TestCategoryId = -1
            });
            cmbTestCategory.DisplayMember = "TestCategoryName";
            cmbTestCategory.ValueMember = "TestCategoryId";
            cmbTestCategory.DataSource = testCategories;
        }
        private void BindResponseTypeComboBox()
        {
            var responseTypes = _responseTypeRepo.GetAllResponseTypes();
            responseTypes.Insert(0, new ResponseType
            {
                ResponseTypeName = "...انتخاب کنید...",
                ResponseTypeId = -1
            });
            cmbResponseType.DisplayMember = "ResponseTypeName";
            cmbResponseType.ValueMember = "ResponseTypeId";
            cmbResponseType.DataSource = responseTypes;
        }

        #endregion

        #region GlobalVariables

        private readonly TestRepository _testRepo;
        private readonly UnitRepository _unitRepo;
        private readonly SampleTypeRepository _sampleTypeRepo;
        private readonly TestMethodRepository _testMethodRepo;
        private readonly TestCategoryRepository _testCategoryRepo;
        private readonly ResponseTypeRepository _responseTypeRepo;

        #endregion

        public frmNewTestParameter()
        {
            this._testRepo = new TestRepository();
            this._unitRepo = new UnitRepository();
            this._sampleTypeRepo = new SampleTypeRepository();
            this._testMethodRepo = new TestMethodRepository();
            this._testCategoryRepo = new TestCategoryRepository();
            this._responseTypeRepo = new ResponseTypeRepository();
            InitializeComponent();
        }

        private void frmNewTestParameter_Load(object sender, EventArgs e)
        {
            BindUnitComboBox();
            BindSampleTypeComboBox();
            BindTestMethodComboBox();
            BindTestCategoryComboBox();
            BindResponseTypeComboBox();
            txtTestName.Focus();
        }

        private void btnAddNewTestParameter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestName.Text))
            {
                err.SetError(txtTestName, "نام آزمایش الزامیست");
                return;
            }
            err.Clear();

            if (cmbUnit.SelectedIndex == 0)
            {
                err.SetError(cmbUnit, "واحد اندازه گیری الزامیست");
                return;
            }
            err.Clear();

            if (cmbSampleType.SelectedIndex == 0)
            {
                err.SetError(cmbSampleType, "نوع نمونه الزامیست");
                return;
            }
            err.Clear();

            if (cmbTestMethod.SelectedIndex == 0)
            {
                err.SetError(cmbTestMethod, "روش انجام آزمایش الزامیست");
                return;
            }
            err.Clear();

            if (cmbTestCategory.SelectedIndex == 0)
            {
                err.SetError(cmbTestCategory, "گروه آزمایش الزامیست");
                return;
            }
            err.Clear();

            if (cmbResponseType.SelectedIndex == 0)
            {
                err.SetError(cmbResponseType, "نوع پاسخ الزامیست");
                return;
            }
            err.Clear();

            var existTestName = _testRepo.HasExistTestName(txtTestName.Text);
            if (existTestName)
            {
                MessageBox.Show("نام آزمایش تکراری است!", "هشدار",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                txtTestName.Text = "";
                txtTestName.Focus();
                return;
            }

            var newTest = new Test
            {
                TestName = txtTestName.Text,
                UnitId = Convert.ToInt32(cmbUnit.SelectedValue),
                SamplyeTypeId = Convert.ToInt32(cmbSampleType.SelectedValue),
                TestMethodId = Convert.ToInt32(cmbTestMethod.SelectedValue),
                TestCategoryId = Convert.ToInt32(cmbTestCategory.SelectedValue),
                ResponseTypeId = Convert.ToInt32(cmbResponseType.SelectedValue),
                Description = txtDescription.Text
            };

            var result = _testRepo.AddNewTest(newTest);
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
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            if (result.IsSuccess)
            {
                MessageBox.Show("نام آزمایش با موفقیت ثبت شد.", "پیام",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                ClearForm();
            }
        }
    }
}
