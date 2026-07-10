using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Services;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess
{
    public class TestRangeRepository : ITestRangeRepository
    {
        private readonly LabContext _db;

        public TestRangeRepository()
        {
            _db = new LabContext();
        }
        public Result<TestRange> AddNewTestRange(TestRange newTestRange)
        {
            try
            {
                if (newTestRange.TestId == 0)
                {
                    return Result<TestRange>.Fail(ErrorCode.ValidationError, "نام آزمایش الزامی است!");
                }

                if (newTestRange.FromValue <= 0)
                {
                    return Result<TestRange>.Fail(ErrorCode.ValidationError, "حد پایین الزامی است!");
                }

                if (newTestRange.ToValue <= 0)
                {
                    return Result<TestRange>.Fail(ErrorCode.ValidationError, "حد بالا الزامی است!");
                }
                _db.TestRange.Add(newTestRange);
                _db.SaveChanges();
                return Result<TestRange>.Success(newTestRange);
            }
            catch (Exception ex)
            {
                return Result<TestRange>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }

        public List<TestRange> GetAllTestRanges()
        {
            return _db.TestRange.Where(x => x.IsDeleted == false).ToList();
        }
    }
}
