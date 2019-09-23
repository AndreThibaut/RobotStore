using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotStore.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }

        public ICollection<Robot> Robots { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }

    }
}
