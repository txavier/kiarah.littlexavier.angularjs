﻿using Kiarah.LittleXavier.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kiarah.LittleXavier.Models
{
    public class BlogEntryViewModel
    {
        public int blogEntryId { get; set; }

        public int categoryId { get; set; }

        [Required]
        [StringLength(256)]
        public string messageTitle { get; set; }

        [Required]
        public string messageBody { get; set; }

        [Required]
        [StringLength(256)]
        public string userName { get; set; }

        public DateTime date { get; set; }

        public virtual category category { get; set; }
    }
}