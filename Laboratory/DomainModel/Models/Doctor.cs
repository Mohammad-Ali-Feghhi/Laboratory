namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Doctor")]
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            TestAcceptionHeader = new HashSet<TestAcceptionHeader>();
        }

        public int DoctorId { get; set; }

        [Required]
        [StringLength(150)]
        public string DoctorName { get; set; }

        [StringLength(100)]
        public string MedicalLicenseNumber { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public bool? IsEnabled { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestAcceptionHeader> TestAcceptionHeader { get; set; }
    }
}
