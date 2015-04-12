using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kiarah.LittleXavier.Core.Models
{
    public class BlogEntryCommentViewModel
    {
        public int blogEntryCommentId { get; set; }

        public int blogEntryId { get; set; }

        [Required]
        public string comment { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        public DateTime dateCreated { get; set; }

        public DateTime dateModified { get; set; }
    }
}
