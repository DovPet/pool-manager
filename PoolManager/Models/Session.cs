using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PoolManager.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Heading { get; set; }

        public Statistic Statistics { get; set; }

        public IEnumerable<DrillSet> DrillSets { get; set; }

    }
}