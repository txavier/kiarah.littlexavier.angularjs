using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kiarah.LittleXavier.Core.Models
{
    public class PagePartEntryViewModel
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

        public DateTime dateCreated { get; set; }

        public DateTime dateModified { get; set; }

        public PageEntryViewModel pageEntry { get; set; }
    }
}
