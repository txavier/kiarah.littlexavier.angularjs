using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kiarah.LittleXavier.Core.Models
{
    public class PageEntryViewModel
    {
        public int pageEntryId { get; set; }

        [Required]
        [StringLength(256)]
        public string pageTitle { get; set; }

        [Required]
        public string pageBody { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        public DateTime dateCreated { get; set; }

        public DateTime dateModified { get; set; }

        public IEnumerable<PagePartEntryViewModel> pagePartEntries { get; set; }
    }
}
