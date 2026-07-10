namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestAcceptionHeader")]
    public partial class TestAcceptionHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestAcceptionHeader()
        {
            TestAcceptionItem = new HashSet<TestAcceptionItem>();
        }

        public int TestAcceptionHeaderId { get; set; }

        public DateTime AcceptionDate { get; set; }

        public int PatientAge { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int RegistrationEmployeeId { get; set; }

        public int? ConfirmationEmployeeId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Patient Patient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestAcceptionItem> TestAcceptionItem { get; set; }
    }
}
