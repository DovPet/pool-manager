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

        public Drill Drill { get; set; }
        public DrillSet DrillSet { get; set; }
    }
}