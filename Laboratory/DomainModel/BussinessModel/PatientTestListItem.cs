using System;

namespace DomainModel.BussinessModel
{
    public class PatientTestListItem
    {
        public int TestAcceptionHeaderId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AcceptionDate { get; set; }
        public string AcceptionDatePersianDateTime { get; set; }
        public int RegistrationEmployeeId { get; set; }
        public string RegistrationEmployeeName { get; set; }
    }
}
