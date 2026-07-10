using System.Collections.Generic;
using System.Linq;
using DataAccess.Services;
using DomainModel.Models;

namespace DataAccess
{
    public class TestMethodRepository : ITestMethodRepository
    {
        private readonly LabContext _db;

        public TestMethodRepository()
        {
            _db = new LabContext();
        }
        public List<TestMethod> GetAllTestMethods()
        {
            return _db.TestMethod.Where(x => x.IsDeleted == false)
                                 .OrderBy(x => x.TestMethodName)
                                 .ToList();
        }
    }
}