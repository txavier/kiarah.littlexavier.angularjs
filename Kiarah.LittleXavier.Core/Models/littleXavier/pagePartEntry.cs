namespace Kiarah.LittleXavier.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pagePartEntry")]
    public partial class pagePartEntry
    {
        public int pagePartEntryId { get; set; }

        public int pageEntryId { get; set; }

        [Required]
        [StringLength(256)]
        public string pagePartTitle { get; set; }

        [Required]
        public string pagePartBody { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime dateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime dateModified { get; set; }

        public virtual pageEntry pageEntry { get; set; }
    }
}
