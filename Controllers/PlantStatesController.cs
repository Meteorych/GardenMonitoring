using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenMonitoring.Data;
using GardenMonitoring.Models;

namespace GardenMonitoring.Controllers
{
    public class PlantStatesController : Controller
    {
        private readonly PlantContext _context;

        public PlantStatesController(PlantContext context)
        {
            _context = context;
        }

        // GET: PlantStates
        public async Task<IActionResult> Index()
        {
	        var plantStates = _context.PlantState
		        .Include(d => d.Plant)
		        .AsNoTracking();
            return View(await plantStates.ToListAsync());
        }

      
        // GET: PlantStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantState = await _context.PlantState.FindAsync(id);
            if (plantState == null)
            {
                return NotFound();
            }
            return View(plantState);
        }

        // POST: PlantStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantState = await _context.PlantState.FindAsync(id);
            if (plantState != null)
            {
                _context.PlantState.Remove(plantState);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantStateExists(int id)
        {
            return _context.PlantState.Any(e => e.PlantId == id);
        }
    }
}
