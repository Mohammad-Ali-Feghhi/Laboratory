using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Services;
using DomainModel.Models;

namespace DataAccess
{
    public class SampleTypeRepository : ISampleTypeRepository
    {
        private readonly LabContext _db;

        public SampleTypeRepository()
        {
            _db = new LabContext();
        }
        public List<SampleType> GetAllSampleTypes()
        {
            return _db.SampleType.Where(x => x.IsDeleted == false)
                                 .OrderBy(x => x.SampleTypeName)
                                 .ToList();
        }
    }
}
