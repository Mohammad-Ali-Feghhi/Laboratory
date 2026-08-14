using System.Collections.Generic;
using System.ComponentModel;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess.Services
{
    public interface ITestAcceptionRepository
    {
        Result<TestAcceptionHeader> AddNewTestAcceptionHeader(TestAcceptionHeader ta);
        Result<TestAcceptionItem> AddNewTestAcceptionItem(TestAcceptionItem ta);
        Result<TestAcceptionItem> AddNewTestAcceptionItems(BindingList<TestParameterTemp> temps);
        Result<TestAcceptionItem> GetItemByTestAcceptionItemId(int testAcceptionItemId);
        List<TestAcceptionHeader> GetAllTestAcceptionHeaders();
        List<TestAcceptionListItem> GetAllTestAcceptionItems(int testAcceptionHeaderId);
        Result<TestAcceptionItem> DeleteTestAcceptionItem(int testAcceptionItemId);
        Result<TestAcceptionItem> UpdateTestAcceptionItem(TestAcceptionItem ta);
        Result<TestAcceptionItem> HasExistTestAcceptionItem(int testAcceptionHeaderId, int testId);
    }
}
