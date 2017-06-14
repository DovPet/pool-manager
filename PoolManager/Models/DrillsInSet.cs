using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoolManager.Models
{
    public class DrillsInSet
    {
        public int Id { get; set; }
        public bool Completed { get; set; }

        public int DrillId { get; set; }
        public int DrillSetId { get; set; }


        public virtual Drill Drill { get; set; }
        public virtual DrillSet DrillSet { get; set; }
    }
}