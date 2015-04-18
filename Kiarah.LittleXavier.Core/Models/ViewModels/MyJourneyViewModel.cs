using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kiarah.LittleXavier.Core.Models
{
    public class MyJourneyViewModel
    {
        public int myJourneyId { get; set; }

        [StringLength(256)]
        public string messageTitle { get; set; }

        [Required]
        public string messageBody { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        public DateTime date { get; set; }
    }
}
