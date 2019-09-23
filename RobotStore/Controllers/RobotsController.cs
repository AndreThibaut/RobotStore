using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RobotStore.Data;
using RobotStore.Models;

namespace RobotStore.Controllers
{
    public class RobotsController : Controller
    {
        private readonly StoreContext _context;

        public RobotsController(StoreContext context)
        {
            _context = context;
        }

        // GET: Robots
        public async Task<IActionResult> Index(string sortOrder, TaskList searchString)
        {
            ViewData["TaskSortParm"] = String.IsNullOrEmpty(sortOrder) ? "task_desc" : "";
            ViewData["ModeSortParm"] = sortOrder == "Mode" ? "mode_desc" : "Mode";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["AvailableSortParm"] = sortOrder == "Available" ? "available_desc" : "Available";
            //ViewData["CurrentFilter"] = searchString;


            var robots = from s in _context.Robots
                           select s;

            //if (searchString != )
            //{
            //    robots = robots.Where(s => s.Task.C
            //                           || s.Mode.Contains(searchString));
            //}

            switch (sortOrder)
            {
                case "task_desc":
                    robots = robots.OrderByDescending(s => s.Task);
                    break;
                case "mode_desc":
                    robots = robots.OrderByDescending(s => s.Mode);
                    break;
                case "price_desc":
                    robots = robots.OrderByDescending(s => s.Price);
                    break;
                case "available_desc":
                    robots = robots.OrderByDescending(s => s.Available);
                    break;
                default:
                    robots = robots.OrderBy(s => s.Task);
                    break;
            }
            return View(await robots.AsNoTracking().ToListAsync());
        }

        // GET: Robots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robot = await _context.Robots
                .FirstOrDefaultAsync(m => m.RobotID == id);
            if (robot == null)
            {
                return NotFound();
            }

            return View(robot);
        }

        // GET: Robots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Robots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RobotID,Task,Mode,Price,Available")] Robot robot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(robot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(robot);
        }

        // GET: Robots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robot = await _context.Robots.FindAsync(id);
            if (robot == null)
            {
                return NotFound();
            }
            return View(robot);
        }

        // POST: Robots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RobotID,Task,Mode,Price,Available")] Robot robot)
        {
            if (id != robot.RobotID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(robot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RobotExists(robot.RobotID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(robot);
        }

        // GET: Robots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robot = await _context.Robots
                .FirstOrDefaultAsync(m => m.RobotID == id);
            if (robot == null)
            {
                return NotFound();
            }

            return View(robot);
        }

        // POST: Robots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var robot = await _context.Robots.FindAsync(id);
            _context.Robots.Remove(robot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RobotExists(int id)
        {
            return _context.Robots.Any(e => e.RobotID == id);
        }
    }
}
