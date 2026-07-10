namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestRange")]
    public partial class TestRange
    {
        public int TestRangeId { get; set; }

        public int TestId { get; set; }

        public double FromValue { get; set; }

        public double ToValue { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public bool HasStar { get; set; }

        public bool IsEmergency { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Test Test { get; set; }
    }
}
