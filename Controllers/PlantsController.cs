using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenMonitoring.Data;
using GardenMonitoring.Models;

namespace GardenMonitoring.Controllers
{
    public class PlantsController : Controller
    {
        private readonly PlantContext _context;

        public PlantsController(PlantContext context)
        {
            _context = context;
        }

        // GET: Plants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plant.ToListAsync());
        }

        // GET: Plants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.Plant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        
        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plant = await _context.Plant.FindAsync(id);
            if (plant != null)
            {
                _context.Plant.Remove(plant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Helper(string? name)
        {
			if (name == null)
			{
				return View();
			}

			var plant = await _context.Plant
				.FirstOrDefaultAsync(plant => plant.Name == name);
			return plant == null ? View() : View("Helper", plant);
        }

        private bool PlantExists(int id)
        {
            return _context.Plant.Any(e => e.Id == id);
        }
    }
}
