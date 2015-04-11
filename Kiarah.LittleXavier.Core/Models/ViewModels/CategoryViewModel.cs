using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kiarah.LittleXavier.Core.Models
{
    public class CategoryViewModel
    {
        public int categoryId { get; set; }

        [Required]
        public string name { get; set; }

        public IEnumerable<Kiarah.LittleXavier.Core.Models.BlogEntryViewModel> blogEntries { get; set; }
    }
}
