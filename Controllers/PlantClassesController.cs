using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenMonitoring.Data;
using GardenMonitoring.Models;

namespace GardenMonitoring.Controllers
{
    public class PlantClassesController : Controller
    {
        private readonly PlantContext _context;

        public PlantClassesController(PlantContext context)
        {
            _context = context;
        }

        // GET: PlantClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlantClass.ToListAsync());
        }

        // GET: PlantClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantClass = await _context.PlantClass.FindAsync(id);
            if (plantClass == null)
            {
                return NotFound();
            }
            return View(plantClass);
        }

        // POST: PlantClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PlantClass plantClass)
        {
            if (id != plantClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantClassExists(plantClass.Id))
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
            return View(plantClass);
        }

        // POST: PlantClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantClass = await _context.PlantClass.FindAsync(id);
            if (plantClass != null)
            {
                _context.PlantClass.Remove(plantClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantClassExists(int id)
        {
            return _context.PlantClass.Any(e => e.Id == id);
        }
    }
}
