using System;

namespace DomainModel.BussinessModel
{
    public class EmployeeSearchListItem
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Tel { get; set; }

        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? IsEnabled { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
