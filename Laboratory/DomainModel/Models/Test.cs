namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Test")]
    public partial class Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test()
        {
            TestAcceptionItem = new HashSet<TestAcceptionItem>();
            TestRange = new HashSet<TestRange>();
        }

        public int TestId { get; set; }

        [Required]
        [StringLength(100)]
        public string TestName { get; set; }

        public int UnitId { get; set; }

        public int SamplyeTypeId { get; set; }

        public int TestMethodId { get; set; }

        public int TestCategoryId { get; set; }

        public int ResponseTypeId { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }

        public virtual SampleType SampleType { get; set; }

        public virtual TestCategory TestCategory { get; set; }

        public virtual TestMethod TestMethod { get; set; }

        public virtual Unit Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestAcceptionItem> TestAcceptionItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestRange> TestRange { get; set; }
    }
}
