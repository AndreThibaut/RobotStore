using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotStore.Models
{
    public class Robot
    {
        public int RobotID { get; set; }
        public TaskList? Task { get; set; }
        public ModesList? Mode { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }

        public Order Bill { get; set; }
    }
}
