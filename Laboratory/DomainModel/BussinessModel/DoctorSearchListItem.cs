using System;

namespace DomainModel.BussinessModel
{
    public class DoctorSearchListItem
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public string MedicalLicenseNumber { get; set; }

        public string Description { get; set; }

        public bool? IsEnabled { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
