using System.Collections.Generic;

namespace RobotStore.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}