using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Services;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess
{
    public class TestAcceptionRepository : ITestAcceptionRepository
    {
        private readonly LabContext _db;

        public TestAcceptionRepository()
        {
            this._db = new LabContext();
        }
        public Result<TestAcceptionHeader> AddNewTestAcceptionHeader(TestAcceptionHeader ta)
        {
            try
            {
                if (ta.AcceptionDate == DateTime.MinValue)
                {
                    const string errorMsg = "تاریخ ثبت آزمایش الزامیست!";
                    return Result<TestAcceptionHeader>.Fail(ErrorCode.ValidationError, errorMsg);
                }

                if (ta.DoctorId <= 0)
                {
                    const string errorMsg = "پزشک معالج الزامیست!";
                    return Result<TestAcceptionHeader>.Fail(ErrorCode.ValidationError, errorMsg);
                }

                if (ta.PatientId == 0)
                {
                    const string errorMsg = "نام بیمار الزامیست!";
                    return Result<TestAcceptionHeader>.Fail(ErrorCode.ValidationError, errorMsg);
                }

                if (ta.PatientAge <= 0)
                {
                    const string errorMsg = "سن بیمار الزامیست!";
                    return Result<TestAcceptionHeader>.Fail(ErrorCode.ValidationError, errorMsg);
                }

                _db.TestAcceptionHeader.Add(ta);
                _db.SaveChanges();
                return Result<TestAcceptionHeader>.Success(ta);
            }
            catch (Exception ex)
            {
                return Result<TestAcceptionHeader>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public List<TestAcceptionHeader> GetAllTestAcceptionHeaders()
        {
            return _db.TestAcceptionHeader.Where(x => x.IsDeleted == false)
                                          .OrderByDescending(x => x.AcceptionDate)
                                          .ToList();
        }
    }
}
