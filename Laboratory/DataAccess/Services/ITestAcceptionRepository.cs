using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess.Services
{
    public interface ITestAcceptionRepository
    {
        Result<TestAcceptionHeader> AddNewTestAcceptionHeader(TestAcceptionHeader ta);
        List<TestAcceptionHeader> GetAllTestAcceptionHeaders();
    }
}
