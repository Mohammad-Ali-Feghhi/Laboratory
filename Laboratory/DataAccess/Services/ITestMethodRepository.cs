using System.Collections.Generic;
using DomainModel.Models;

namespace DataAccess.Services
{
    public interface ITestMethodRepository
    {
        List<TestMethod> GetAllTestMethods();
    }
}