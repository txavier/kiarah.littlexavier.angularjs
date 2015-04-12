namespace Kiarah.LittleXavier.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blogEntryComment")]
    public partial class blogEntryComment
    {
        public int blogEntryCommentId { get; set; }

        public int blogEntryId { get; set; }

        [Required]
        public string comment { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime dateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime dateModified { get; set; }

        public virtual blogEntry blogEntry { get; set; }
    }
}
