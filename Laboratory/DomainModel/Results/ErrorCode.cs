using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Results
{
    public enum ErrorCode
    {
        None = 0,
        UserNotFound = 1,
        InvalidPassword = 2,
        DatabaseError = 3,
        ValidationError = 4
    }
}
