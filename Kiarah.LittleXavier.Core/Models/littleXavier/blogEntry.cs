namespace Kiarah.LittleXavier.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blogEntry")]
    public partial class blogEntry
    {
        public blogEntry()
        {
            blogEntryComments = new HashSet<blogEntryComment>();
        }

        public int blogEntryId { get; set; }

        public int categoryId { get; set; }

        [StringLength(256)]
        public string messageTitle { get; set; }

        [Required]
        public string messageBody { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public virtual category category { get; set; }

        public virtual ICollection<blogEntryComment> blogEntryComments { get; set; }
    }
}
