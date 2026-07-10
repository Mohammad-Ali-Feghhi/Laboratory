using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Services;
using DomainModel.Models;

namespace DataAccess
{
    public class UnitRepository : IUnitRepository
    {
        private readonly LabContext _db;

        public UnitRepository()
        {
            _db = new LabContext();
        }
        public List<Unit> GetAllUnits()
        {
            return _db.Unit.Where(x => x.IsDeleted == false)
                           .OrderBy(x => x.UnitName)
                           .ToList();
        }
    }
}
