using RobotStore.Models;
using System.Linq;

namespace RobotStore.Data
{
    public class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();

            //Look if Robots exist in DB
            if (context.Robots.Any()) { return; }

            //Add Sample Robots
            var robots = new Robot[] {
                new Robot{Task = TaskList.Transport, Mode = ModesList.Ground, Price = 3000, Available = true},
                new Robot{Task = TaskList.Transport, Mode = ModesList.Ground, Price = 3000, Available = true},
                new Robot{Task = TaskList.Transport, Mode = ModesList.Ground, Price = 3000, Available = true},
                new Robot{Task = TaskList.Patrol, Mode = ModesList.Air, Price = 2500, Available = true},
                new Robot{Task = TaskList.Maintenance, Mode = ModesList.Sea, Price = 2000, Available = false}
            };

             foreach (Robot r in robots)
            {
                context.Add(r);
            }

            context.SaveChanges();

            //Add Sample Clients
            var clients = new Client[] {
                new Client{Name = "Metti Geiss", HouseNumber = "12", StreetName = "Am Bongert", CityName = "Clemency"},
                new Client{Name = "Carlo Hoffmann", HouseNumber = "134", StreetName = "Ave de Luxembourg", CityName = "Bascharage"},
                new Client{Name = "Steve Aoki", HouseNumber = "14c", StreetName = "Zonong Industriel", CityName = "Soleuvre"}
            };

            foreach (Client c in clients) {
                context.Add(c);
            }
            context.SaveChanges();

            //Add Sample Employees
            var employees = new Employee[] {
                new Employee{Name = "Arno Schiltz", Function = EmployeeFunctionList.Vendor, Title= "Head Of Sales"},
                new Employee{Name = "Marco Pütz", Function = EmployeeFunctionList.Management, Title= "Team Coordination Manager"}
            };

            foreach (Employee e in employees)
            {
                context.Add(e);
                context.SaveChanges();
            }

        }
    }
}
