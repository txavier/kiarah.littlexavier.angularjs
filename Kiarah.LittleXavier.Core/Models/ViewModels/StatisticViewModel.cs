using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kiarah.LittleXavier.Core.Models
{
    public class StatisticViewModel
    {
        public int statisticId { get; set; }

        [Required]
        [StringLength(50)]
        public string statisticKey { get; set; }

        [Required]
        public string statisticValue { get; set; }
    }
}
