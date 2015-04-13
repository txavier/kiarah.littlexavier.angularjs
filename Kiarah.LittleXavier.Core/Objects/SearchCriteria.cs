using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiarah.LittleXavier.Core.Objects
{
    public class SearchCriteria
    {
        public int? currentPage { get; set; }

        public int? itemsPerPage { get; set; }

        public string searchText { get; set; }

        public string orderBy { get; set; }

        public IEnumerable<SearchParam> searchParams { get; set; }

        public string includeProperties { get; set; }

        public DateTime? startDateTime { get; set; }

        public DateTime? endDateTime { get; set; }

        public string blogEntryTitle { get; set; }

        public int? year { get; set; }

        public int? month { get; set; }
    }
}
