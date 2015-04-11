namespace Kiarah.LittleXavier.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("category")]
    public partial class category
    {
        public category()
        {
            blogEntries = new HashSet<blogEntry>();
        }

        public int categoryId { get; set; }

        [Required]
        public string name { get; set; }

        public virtual ICollection<blogEntry> blogEntries { get; set; }
    }
}
