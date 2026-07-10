namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestAcceptionItem")]
    public partial class TestAcceptionItem
    {
        public int TestAcceptionItemId { get; set; }

        public int TestAcceptionHeaderId { get; set; }

        public int TestId { get; set; }

        public int TestMethodId { get; set; }

        public int UnitId { get; set; }

        public double? ResponseNumber { get; set; }

        [StringLength(500)]
        public string ResponseDescription { get; set; }

        public bool? ResponseBoolean { get; set; }

        public bool HasStar { get; set; }

        public bool IsEmergency { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Test Test { get; set; }

        public virtual TestAcceptionHeader TestAcceptionHeader { get; set; }
    }
}
