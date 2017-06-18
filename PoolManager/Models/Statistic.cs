using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PoolManager.Models
{
    public class Statistic
    {

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public int SetsDone { get; set; }

        public int DrillsDone { get; set; }

        public int DrillsFailed { get; set; }

        public int DrillSetsFailed { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual IEnumerable<ApplicationUser> AspNetUsers { get; set; }
        [Required]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }

    }
}