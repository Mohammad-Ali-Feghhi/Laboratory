using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.BussinessModel
{
    public class PatientSearchListItem
    {
        public string PatientFullInfo { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
