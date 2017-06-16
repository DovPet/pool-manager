using System;
using System.Collections.Generic;
using System.ComponentModel;
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

       
        [Required]
        [DefaultValue("false")]
        public bool Completed { get; set; }

        public virtual IEnumerable<Statistic> Statistics { get; set; }

        public virtual DrillSet DrillSet { get; set; }
        [Required]
        public int DrillSetId { get; set; }
    }
}