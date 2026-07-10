using System.Collections.Generic;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess.Services
{
    public interface ITestRangeRepository
    {
        Result<TestRange> AddNewTestRange(TestRange newTestRange);
        List<TestRange> GetAllTestRanges();
    }
}