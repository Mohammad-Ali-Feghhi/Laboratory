namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Unit")]
    public partial class Unit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unit()
        {
            Test = new HashSet<Test>();
        }

        public int UnitId { get; set; }

        [Required]
        [StringLength(100)]
        public string UnitName { get; set; }

        [StringLength(800)]
        public string Description { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> Test { get; set; }
    }
}
