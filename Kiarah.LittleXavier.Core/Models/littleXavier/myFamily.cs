namespace Kiarah.LittleXavier.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("myFamily")]
    public partial class myFamily
    {
        public int myFamilyId { get; set; }

        [StringLength(256)]
        public string messageTitle { get; set; }

        [Required]
        public string messageBody { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }
    }
}
