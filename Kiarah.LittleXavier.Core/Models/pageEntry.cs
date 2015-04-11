namespace Kiarah.LittleXavier.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pageEntry")]
    public partial class pageEntry
    {
        public pageEntry()
        {
            pagePartEntries = new HashSet<pagePartEntry>();
        }

        public int pageEntryId { get; set; }

        [Required]
        [StringLength(256)]
        public string pageTitle { get; set; }

        [Required]
        public string pageBody { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime dateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime dateModified { get; set; }

        public virtual ICollection<pagePartEntry> pagePartEntries { get; set; }
    }
}
