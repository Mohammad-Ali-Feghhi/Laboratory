using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.BussinessModel
{
    public class TestParameterTemp
    {
        public Guid TempId { get; set; } = Guid.NewGuid();
        public int TestAcceptionHeaderId { get; set; }
        public int TestId { get; set; }
        public int TestMethodId { get; set; }
        public int UnitId { get; set; }
        public string TestName { get; set; }
        public string TestMethodName { get; set; }
        public string UnitName { get; set; }
    }
}
