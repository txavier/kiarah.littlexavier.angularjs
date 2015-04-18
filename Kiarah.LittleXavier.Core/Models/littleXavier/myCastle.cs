using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Kiarah.LittleXavier.Core.Models
{
    public class myCastle
    {
        public int myCastleId { get; set; }

        [StringLength(256)]
        public string messageTitle { get; set; }

        [Required]
        public string messageBody { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }
    }
}
