using System;
using System.Collections.Generic;
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

        public IEnumerable<Session> Sessions { get; set; }

        public IEnumerable<DrillSet> DrillSets { get; set; }
    }
}