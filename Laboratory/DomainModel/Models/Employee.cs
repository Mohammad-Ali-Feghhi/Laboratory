namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            LoginHistory = new HashSet<LoginHistory>();
            TestAcceptionHeader = new HashSet<TestAcceptionHeader>();
        }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(400)]
        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? IsEnabled { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoginHistory> LoginHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestAcceptionHeader> TestAcceptionHeader { get; set; }
    }
}
