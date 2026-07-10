using System.Collections.Generic;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess.Services
{
    public interface ITestRepository
    {
        Result<Test> AddNewTest(Test newTest);
        bool HasExistTestName(string testName);
        List<Test> GetAllTests();
        List<TestSearchListItem> TestSearch(string phrase);
    }
}