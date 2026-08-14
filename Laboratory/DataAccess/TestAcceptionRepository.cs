using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Services;
using DomainModel.BussinessModel;
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

                if (ta.PatientId <= 0)
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

        public Result<TestAcceptionItem> AddNewTestAcceptionItem(TestAcceptionItem ta)
        {
            try
            {
                _db.TestAcceptionItem.Add(ta);
                _db.SaveChanges();
                return Result<TestAcceptionItem>.Success(ta);
            }
            catch (Exception ex)
            {
                return Result<TestAcceptionItem>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }

        public Result<TestAcceptionItem> AddNewTestAcceptionItems(BindingList<TestParameterTemp> temps)
        {
            try
            {
                var entries = temps.Select(x => new TestAcceptionItem
                {
                    TestAcceptionHeaderId = x.TestAcceptionHeaderId,
                    TestId = x.TestId,
                    TestMethodId = x.TestMethodId,
                    UnitId = x.UnitId,
                    
                }).ToList();

                _db.TestAcceptionItem.AddRange(entries);
                _db.SaveChanges();

                return Result<TestAcceptionItem>.Success(default);
            }
            catch (Exception ex)
            {
                return Result<TestAcceptionItem>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }

        public Result<TestAcceptionItem> GetItemByTestAcceptionItemId(int testAcceptionItemId)
        {
            try
            {
                var findTestAcceptionListItem =
                    _db.TestAcceptionItem.FirstOrDefault(x => x.TestAcceptionItemId == testAcceptionItemId &&
                                                              x.IsDeleted == false);
                if (findTestAcceptionListItem == null)
                {
                    return Result<TestAcceptionItem>.Fail(ErrorCode.ValidationError, "آیتم مورد نظر پیدا نشد!");
                }
                return Result<TestAcceptionItem>.Success(findTestAcceptionListItem);
            }
            catch (Exception ex)
            {
                return Result<TestAcceptionItem>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }

        public List<TestAcceptionHeader> GetAllTestAcceptionHeaders()
        {
            return _db.TestAcceptionHeader.Where(x => x.IsDeleted == false)
                                          .OrderByDescending(x => x.AcceptionDate)
                                          .ToList();
        }

        public List<TestAcceptionListItem> GetAllTestAcceptionItems(int testAcceptionHeaderId)
        {
            var query = from testAcceptionItem in _db.TestAcceptionItem
                        join method in _db.TestMethod on testAcceptionItem.TestMethodId equals method.TestMethodId
                        join unit in _db.Unit on testAcceptionItem.UnitId equals unit.UnitId
                        where testAcceptionItem.TestAcceptionHeaderId == testAcceptionHeaderId &&
                              testAcceptionItem.IsDeleted == false
                        select new TestAcceptionListItem
                        {
                            TestAcceptionItemId = testAcceptionItem.TestAcceptionItemId,
                            TestAcceptionHeaderId = testAcceptionItem.TestAcceptionHeaderId,
                            TestId = testAcceptionItem.TestId,
                            TestName = testAcceptionItem.Test.TestName,
                            TestMethodId = testAcceptionItem.TestMethodId,
                            TestMethodName = method.TestMethodName,
                            UnitId = testAcceptionItem.UnitId,
                            UnitName = unit.UnitName,
                            ResponseNumber = testAcceptionItem.ResponseNumber,
                            ResponseNumberText = testAcceptionItem.ResponseNumber.HasValue 
                                                ?testAcceptionItem.ResponseNumber.Value.ToString() : "کیفی",
                            ResponseDescription = testAcceptionItem.ResponseDescription,
                            ResponseBoolean = testAcceptionItem.ResponseBoolean,
                            ResponseText = testAcceptionItem.ResponseBoolean.HasValue
                                         ?(testAcceptionItem.ResponseBoolean.Value ? "Positive" : "Negative") : "عددی",
                            HasStar = testAcceptionItem.HasStar,
                            IsEmergency = testAcceptionItem.IsEmergency,
                        };
            return query.ToList();
        }

        public Result<TestAcceptionItem> DeleteTestAcceptionItem(int testAcceptionItemId)
        {
            try
            {
                var testAcceptionItem = _db.TestAcceptionItem
                                           .FirstOrDefault(x => x.TestAcceptionItemId == testAcceptionItemId && 
                                                                x.IsDeleted == false);
                if (testAcceptionItem == null)
                {
                    return Result<TestAcceptionItem>.Fail(ErrorCode.UserNotFound, "آیتم مورد نظر یافت نشد!");
                }

                testAcceptionItem.IsDeleted = true;
                _db.SaveChanges();
                return Result<TestAcceptionItem>.Success(testAcceptionItem);
            }
            catch (Exception ex)
            {
                return Result<TestAcceptionItem>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }

        public Result<TestAcceptionItem> UpdateTestAcceptionItem(TestAcceptionItem ta)
        {
            try
            {
                var oldItem =
                    _db.TestAcceptionItem.FirstOrDefault(x => x.TestAcceptionItemId == ta.TestAcceptionItemId &&
                                                              x.IsDeleted == false);
                if (oldItem == null)
                {
                    return Result<TestAcceptionItem>.Fail(ErrorCode.UserNotFound, "آیتم مورد نظر پیدا نشد!");
                }

                oldItem.TestAcceptionHeaderId = ta.TestAcceptionHeaderId;
                oldItem.TestId = ta.TestId;
                oldItem.TestMethodId = ta.TestMethodId;
                oldItem.UnitId = ta.UnitId;
                oldItem.ResponseNumber = ta.ResponseNumber;
                oldItem.ResponseDescription = ta.ResponseDescription;
                oldItem.ResponseBoolean = ta.ResponseBoolean;
                oldItem.HasStar = ta.HasStar;
                oldItem.IsEmergency = ta.IsEmergency;
                oldItem.UpdateTime = ta.UpdateTime;
                oldItem.IsUpdated = ta.IsUpdated;
                _db.SaveChanges();
                return Result<TestAcceptionItem>.Success(ta);
            }
            catch (Exception ex)
            {
                return Result<TestAcceptionItem>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }

        public Result<TestAcceptionItem> HasExistTestAcceptionItem(int testAcceptionHeaderId, int testId)
        {
            try
            {
                var existTestItem = _db.TestAcceptionItem.Any(x => x.TestAcceptionHeaderId == testAcceptionHeaderId && 
                                                                   x.TestId == testId && 
                                                                   x.IsDeleted == false);
                const string errorMsg = "این آیتم قبلا ثبت شده است!";
                return !existTestItem ? Result<TestAcceptionItem>.Success(null) : 
                                        Result<TestAcceptionItem>.Fail(ErrorCode.ValidationError, errorMsg);
            }
            catch (Exception ex)
            {
                return Result<TestAcceptionItem>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
    }
}
