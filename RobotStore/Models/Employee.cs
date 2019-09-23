using System.Collections.Generic;

namespace RobotStore.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public EmployeeFunctionList? Function { get; set; }
        public string Title { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}