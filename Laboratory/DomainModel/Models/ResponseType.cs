namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResponseType")]
    public partial class ResponseType
    {
        public int ResponseTypeId { get; set; }

        [Required]
        [StringLength(200)]
        public string ResponseTypeName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
