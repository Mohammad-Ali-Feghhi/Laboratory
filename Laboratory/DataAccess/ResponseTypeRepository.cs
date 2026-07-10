using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Services;
using DomainModel.Models;

namespace DataAccess
{
    public class ResponseTypeRepository : IResponseTypeRepository
    {
        private readonly LabContext _db;

        public ResponseTypeRepository()
        {
            this._db = new LabContext();
        }
        public List<ResponseType> GetAllResponseTypes()
        {
            return _db.ResponseType.Where(x => x.IsDeleted == false)
                                   .OrderBy(x => x.ResponseTypeName)
                                   .ToList();
        }
    }
}
