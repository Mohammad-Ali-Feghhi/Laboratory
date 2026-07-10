using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Services;
using DomainModel.Models;

namespace DataAccess
{
    public class TestCategoryRepository : ITestCategoryRepository
    {
        private readonly LabContext _db;

        public TestCategoryRepository()
        {
            _db = new LabContext();
        }
        public List<TestCategory> GetAllTestCategories()
        {
            return _db.TestCategory.Where(x => x.IsDeleted == false)
                                   .OrderBy(x => x.TestCategoryName)
                                   .ToList();
        }
    }
}
