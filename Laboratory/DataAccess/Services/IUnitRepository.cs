using System;
using System.Collections.Generic;
using DomainModel.Models;

namespace DataAccess.Services
{
    public interface IUnitRepository
    {
        List<Unit> GetAllUnits();
    }
}
