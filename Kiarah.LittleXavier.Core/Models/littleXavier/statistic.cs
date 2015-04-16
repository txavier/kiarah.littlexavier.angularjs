namespace Kiarah.LittleXavier.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("statistic")]
    public partial class statistic
    {
        public int statisticId { get; set; }

        [Required]
        [StringLength(50)]
        public string statisticKey { get; set; }

        [Required]
        public string statisticValue { get; set; }

        public string statisticUnit { get; set; }

        public DateTime date { get; set; }
    }
}
