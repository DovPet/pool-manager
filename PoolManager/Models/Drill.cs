using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoolManager.Models
{
    public class Drill
    {
        public Drill()
        {
            DrillsInSets = new List<DrillsInSet>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Heading { get; set; }

        [Required]
        [AllowHtml]
        public string Description { get; set; }

        public ICollection<DrillsInSet> DrillsInSets { get; set; }

        }
}