using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using DataAccess.Services;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess
{
    public class TestRepository : ITestRepository
    {
        private readonly LabContext _db;

        public TestRepository()
        {
            _db = new LabContext();
        }
        public Result<Test> AddNewTest(Test newTest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newTest.TestName))
                {
                    return Result<Test>.Fail(ErrorCode.ValidationError, "نام آزمایش الزامی است!");
                }

                if (newTest.UnitId == 0 || newTest.UnitId == -1)
                {
                    return Result<Test>.Fail(ErrorCode.ValidationError, "واحد اندازه گیری الزامی است!");
                }

                if (newTest.SamplyeTypeId == 0 || newTest.SamplyeTypeId == -1)
                {
                    return Result<Test>.Fail(ErrorCode.ValidationError, "نوع نمونه الزامی است!");
                }

                if (newTest.TestMethodId == 0 || newTest.TestMethodId == -1)
                {
                    return Result<Test>.Fail(ErrorCode.ValidationError, "روش انجام آزمایش الزامی است!");
                }

                if (newTest.TestCategoryId == 0 || newTest.TestCategoryId == -1)
                {
                    return Result<Test>.Fail(ErrorCode.ValidationError, "گروه آزمایش الزامی است!");
                }

                if (newTest.ResponseTypeId == 0 || newTest.ResponseTypeId == -1)
                {
                    return Result<Test>.Fail(ErrorCode.ValidationError, "نوع پاسخ الزامی است!");
                }

                _db.Test.Add(newTest);
                _db.SaveChanges();
                return Result<Test>.Success(newTest);
            }
            catch (Exception ex)
            {
                return Result<Test>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }

        public Result<Test> GetByTestId(int testId)
        {
            try
            {
                var test = _db.Test.FirstOrDefault(x => x.TestId == testId && x.IsDeleted == false);
                return test == null ? Result<Test>.Fail(ErrorCode.UserNotFound, "پارامتر مورد نظر پیدا نشد!") :
                                      Result<Test>.Success(test);
            }
            catch (Exception ex)
            {
                return Result<Test>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }

        public Result<TestAcceptionItemViewModel> GetTestItemsByTestId(int testId)
        {
            try
            {
                var test = _db.Test.Where(x => x.TestId == testId && x.IsDeleted == false)
                    .Select(x => new TestAcceptionItemViewModel
                    {
                        TestId = x.TestId,
                        TestName = x.TestName,
                        TestMethodId = x.TestMethodId,
                        TestMethodName = x.TestMethod.TestMethodName,
                        UnitId = x.UnitId,
                        UnitName = x.Unit.UnitName
                    })
                    .FirstOrDefault();

                if (test == null)
                {
                    const string errorMsg = "پارامتر مورد نظر یافت نشد!";
                    return Result<TestAcceptionItemViewModel>.Fail(ErrorCode.UserNotFound, errorMsg);
                }
                return Result<TestAcceptionItemViewModel>.Success(test);
            }
            catch (Exception ex)
            {
                return Result<TestAcceptionItemViewModel>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }

        public bool HasExistTestName(string testName)
        {
            return _db.Test.Any(x => x.TestName == testName);
        }

        public List<Test> GetAllTests()
        {
            return _db.Test.Where(x => x.IsDeleted == false).OrderBy(x => x.TestName).ToList();
        }

        public List<TestSearchListItem> TestSearch(string phrase)
        {
            var q = from t in _db.Test
                where t.TestName.StartsWith(phrase) &&
                      t.IsDeleted == false
                select new TestSearchListItem
                {
                    TestId = t.TestId,
                    TestName = t.TestName
                };
            return q.OrderBy(x => x.TestName).ToList();
        }
    }
}
