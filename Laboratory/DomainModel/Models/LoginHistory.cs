namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginHistory")]
    public partial class LoginHistory
    {
        public long LoginHistoryId { get; set; }

        public DateTime LoginDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        public int EmployeeId { get; set; }

        [StringLength(1000)]
        public string Message { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
